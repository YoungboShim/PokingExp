namespace PokingExp
{
    partial class SecondaryTask
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
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timerPull = new System.Windows.Forms.Timer(this.components);
            this.timerDuration = new System.Windows.Forms.Timer(this.components);
            this.timerSS = new System.Windows.Forms.Timer(this.components);
            this.timerRandom = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerPull
            // 
            this.timerPull.Tick += new System.EventHandler(this.timerPull_Tick);
            // 
            // timerDuration
            // 
            this.timerDuration.Interval = 256;
            this.timerDuration.Tick += new System.EventHandler(this.timerDuration_Tick);
            // 
            // timerSS
            // 
            this.timerSS.Interval = 128;
            this.timerSS.Tick += new System.EventHandler(this.timerSS_Tick);
            // 
            // timerRandom
            // 
            this.timerRandom.Tick += new System.EventHandler(this.timerRandom_Tick);
            // 
            // SecondaryTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "SecondaryTask";
            this.Text = "SecondaryTask";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SecondaryTask_FormClosing);
            this.Load += new System.EventHandler(this.SecondaryTask_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SecondaryTask_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.SecondaryTask_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timerPull;
        private System.Windows.Forms.Timer timerDuration;
        private System.Windows.Forms.Timer timerSS;
        private System.Windows.Forms.Timer timerRandom;
    }
}
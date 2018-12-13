namespace PokingExp
{
    partial class Exp1Training
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exp1Training));
            this.timerSS = new System.Windows.Forms.Timer(this.components);
            this.timerTraining = new System.Windows.Forms.Timer(this.components);
            this.timerDuration = new System.Windows.Forms.Timer(this.components);
            this.labelWait = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.labelTrial = new System.Windows.Forms.Label();
            this.timerPull = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerSS
            // 
            this.timerSS.Interval = 128;
            this.timerSS.Tick += new System.EventHandler(this.timerSS_Tick);
            // 
            // timerTraining
            // 
            this.timerTraining.Interval = 300000;
            this.timerTraining.Tick += new System.EventHandler(this.timerTraining_Tick);
            // 
            // timerDuration
            // 
            this.timerDuration.Interval = 256;
            this.timerDuration.Tick += new System.EventHandler(this.timerDuration_Tick);
            // 
            // labelWait
            // 
            this.labelWait.AutoSize = true;
            this.labelWait.BackColor = System.Drawing.Color.Black;
            this.labelWait.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWait.ForeColor = System.Drawing.Color.White;
            this.labelWait.Location = new System.Drawing.Point(1017, 261);
            this.labelWait.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelWait.Name = "labelWait";
            this.labelWait.Size = new System.Drawing.Size(232, 117);
            this.labelWait.TabIndex = 18;
            this.labelWait.Text = "Wait";
            // 
            // buttonUp
            // 
            this.buttonUp.BackColor = System.Drawing.Color.Black;
            this.buttonUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUp.ForeColor = System.Drawing.Color.Black;
            this.buttonUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonUp.Image")));
            this.buttonUp.Location = new System.Drawing.Point(984, 418);
            this.buttonUp.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(294, 288);
            this.buttonUp.TabIndex = 12;
            this.buttonUp.UseVisualStyleBackColor = false;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.BackColor = System.Drawing.Color.Black;
            this.buttonLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLeft.ForeColor = System.Drawing.Color.Black;
            this.buttonLeft.Image = ((System.Drawing.Image)(resources.GetObject("buttonLeft.Image")));
            this.buttonLeft.Location = new System.Drawing.Point(692, 706);
            this.buttonLeft.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(294, 288);
            this.buttonLeft.TabIndex = 13;
            this.buttonLeft.UseVisualStyleBackColor = false;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.BackColor = System.Drawing.Color.Black;
            this.buttonRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRight.ForeColor = System.Drawing.Color.Black;
            this.buttonRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonRight.Image")));
            this.buttonRight.Location = new System.Drawing.Point(1277, 706);
            this.buttonRight.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(294, 288);
            this.buttonRight.TabIndex = 14;
            this.buttonRight.UseVisualStyleBackColor = false;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.BackColor = System.Drawing.Color.Black;
            this.buttonDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDown.ForeColor = System.Drawing.Color.Black;
            this.buttonDown.Image = ((System.Drawing.Image)(resources.GetObject("buttonDown.Image")));
            this.buttonDown.Location = new System.Drawing.Point(984, 994);
            this.buttonDown.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(294, 288);
            this.buttonDown.TabIndex = 15;
            this.buttonDown.UseVisualStyleBackColor = false;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.Color.Black;
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlay.ForeColor = System.Drawing.Color.White;
            this.buttonPlay.Location = new System.Drawing.Point(984, 706);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(294, 288);
            this.buttonPlay.TabIndex = 16;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // labelTrial
            // 
            this.labelTrial.AutoSize = true;
            this.labelTrial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelTrial.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrial.ForeColor = System.Drawing.Color.White;
            this.labelTrial.Location = new System.Drawing.Point(0, 1093);
            this.labelTrial.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTrial.Name = "labelTrial";
            this.labelTrial.Size = new System.Drawing.Size(240, 78);
            this.labelTrial.TabIndex = 17;
            this.labelTrial.Text = "Training";
            // 
            // timerPull
            // 
            this.timerPull.Tick += new System.EventHandler(this.timerPull_Tick);
            // 
            // Exp1Training
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1916, 1171);
            this.Controls.Add(this.labelWait);
            this.Controls.Add(this.labelTrial);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonUp);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Exp1Training";
            this.Text = "ExpProgram";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Exp1Training_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Exp1Training_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerSS;
        private System.Windows.Forms.Timer timerTraining;
        private System.Windows.Forms.Timer timerDuration;
        private System.Windows.Forms.Label labelWait;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Label labelTrial;
        private System.Windows.Forms.Timer timerPull;
    }
}
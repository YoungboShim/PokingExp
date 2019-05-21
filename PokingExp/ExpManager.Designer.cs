namespace PokingExp
{
    partial class ExpManager
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelSerial = new System.Windows.Forms.Panel();
            this.comboBoxSerials = new System.Windows.Forms.ComboBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxLogID = new System.Windows.Forms.TextBox();
            this.panelStart = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonReplace = new System.Windows.Forms.Button();
            this.buttonCalibration = new System.Windows.Forms.Button();
            this.comboBoxBlock = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTrainMain = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxShortLong = new System.Windows.Forms.ComboBox();
            this.panelSerial.SuspendLayout();
            this.panelStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSerial
            // 
            this.panelSerial.Controls.Add(this.comboBoxSerials);
            this.panelSerial.Controls.Add(this.buttonReset);
            this.panelSerial.Controls.Add(this.buttonConnect);
            this.panelSerial.Location = new System.Drawing.Point(10, 10);
            this.panelSerial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelSerial.Name = "panelSerial";
            this.panelSerial.Size = new System.Drawing.Size(276, 29);
            this.panelSerial.TabIndex = 22;
            // 
            // comboBoxSerials
            // 
            this.comboBoxSerials.FormattingEnabled = true;
            this.comboBoxSerials.Location = new System.Drawing.Point(71, 2);
            this.comboBoxSerials.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxSerials.Name = "comboBoxSerials";
            this.comboBoxSerials.Size = new System.Drawing.Size(106, 20);
            this.comboBoxSerials.TabIndex = 9;
            this.comboBoxSerials.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerials_SelectedIndexChanged);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(0, 2);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(66, 18);
            this.buttonReset.TabIndex = 10;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(182, 2);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(66, 18);
            this.buttonConnect.TabIndex = 11;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(355, 26);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(66, 18);
            this.buttonStart.TabIndex = 23;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxLogID
            // 
            this.textBoxLogID.Location = new System.Drawing.Point(28, 2);
            this.textBoxLogID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxLogID.Name = "textBoxLogID";
            this.textBoxLogID.Size = new System.Drawing.Size(67, 21);
            this.textBoxLogID.TabIndex = 24;
            // 
            // panelStart
            // 
            this.panelStart.Controls.Add(this.comboBoxShortLong);
            this.panelStart.Controls.Add(this.label6);
            this.panelStart.Controls.Add(this.buttonReplace);
            this.panelStart.Controls.Add(this.buttonCalibration);
            this.panelStart.Controls.Add(this.comboBoxBlock);
            this.panelStart.Controls.Add(this.label5);
            this.panelStart.Controls.Add(this.label2);
            this.panelStart.Controls.Add(this.comboBoxTrainMain);
            this.panelStart.Controls.Add(this.label1);
            this.panelStart.Controls.Add(this.textBoxLogID);
            this.panelStart.Controls.Add(this.buttonStart);
            this.panelStart.Location = new System.Drawing.Point(12, 45);
            this.panelStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelStart.Name = "panelStart";
            this.panelStart.Size = new System.Drawing.Size(454, 54);
            this.panelStart.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(311, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 12);
            this.label6.TabIndex = 40;
            this.label6.Text = "Short/Long";
            // 
            // buttonReplace
            // 
            this.buttonReplace.Location = new System.Drawing.Point(203, 26);
            this.buttonReplace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(66, 18);
            this.buttonReplace.TabIndex = 26;
            this.buttonReplace.Text = "Init";
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
            // 
            // buttonCalibration
            // 
            this.buttonCalibration.Location = new System.Drawing.Point(275, 26);
            this.buttonCalibration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCalibration.Name = "buttonCalibration";
            this.buttonCalibration.Size = new System.Drawing.Size(74, 18);
            this.buttonCalibration.TabIndex = 39;
            this.buttonCalibration.Text = "Calibration";
            this.buttonCalibration.UseVisualStyleBackColor = true;
            this.buttonCalibration.Click += new System.EventHandler(this.buttonCalibration_Click);
            // 
            // comboBoxBlock
            // 
            this.comboBoxBlock.FormattingEnabled = true;
            this.comboBoxBlock.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBoxBlock.Location = new System.Drawing.Point(269, 2);
            this.comboBoxBlock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxBlock.Name = "comboBoxBlock";
            this.comboBoxBlock.Size = new System.Drawing.Size(36, 20);
            this.comboBoxBlock.TabIndex = 32;
            this.comboBoxBlock.SelectedIndexChanged += new System.EventHandler(this.comboBoxBlock_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "Block";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "Type";
            // 
            // comboBoxTrainMain
            // 
            this.comboBoxTrainMain.FormattingEnabled = true;
            this.comboBoxTrainMain.Items.AddRange(new object[] {
            "Train",
            "Main"});
            this.comboBoxTrainMain.Location = new System.Drawing.Point(139, 2);
            this.comboBoxTrainMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxTrainMain.Name = "comboBoxTrainMain";
            this.comboBoxTrainMain.Size = new System.Drawing.Size(79, 20);
            this.comboBoxTrainMain.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "ID";
            // 
            // comboBoxShortLong
            // 
            this.comboBoxShortLong.FormattingEnabled = true;
            this.comboBoxShortLong.Items.AddRange(new object[] {
            "Short",
            "Long"});
            this.comboBoxShortLong.Location = new System.Drawing.Point(384, 2);
            this.comboBoxShortLong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxShortLong.Name = "comboBoxShortLong";
            this.comboBoxShortLong.Size = new System.Drawing.Size(67, 20);
            this.comboBoxShortLong.TabIndex = 41;
            this.comboBoxShortLong.SelectedIndexChanged += new System.EventHandler(this.comboBoxShortLong_SelectedIndexChanged);
            // 
            // ExpManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 106);
            this.Controls.Add(this.panelStart);
            this.Controls.Add(this.panelSerial);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ExpManager";
            this.Text = "Form1";
            this.panelSerial.ResumeLayout(false);
            this.panelStart.ResumeLayout(false);
            this.panelStart.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSerial;
        private System.Windows.Forms.ComboBox comboBoxSerials;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonConnect;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxLogID;
        private System.Windows.Forms.Panel panelStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTrainMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxBlock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCalibration;
        private System.Windows.Forms.Button buttonReplace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxShortLong;
    }
}


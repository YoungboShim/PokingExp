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
            this.comboBoxSpatial = new System.Windows.Forms.ComboBox();
            this.labelSpatial = new System.Windows.Forms.Label();
            this.comboBoxBlock = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDepth = new System.Windows.Forms.ComboBox();
            this.comboBoxTrainMain = new System.Windows.Forms.ComboBox();
            this.comboBoxSS = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDepth = new System.Windows.Forms.Label();
            this.labelSS = new System.Windows.Forms.Label();
            this.panelStart2 = new System.Windows.Forms.Panel();
            this.buttonStart2 = new System.Windows.Forms.Button();
            this.comboBoxLevel = new System.Windows.Forms.ComboBox();
            this.labelLevel = new System.Windows.Forms.Label();
            this.comboBoxTactile = new System.Windows.Forms.ComboBox();
            this.labelTactile = new System.Windows.Forms.Label();
            this.labelID2 = new System.Windows.Forms.Label();
            this.textBoxID2 = new System.Windows.Forms.TextBox();
            this.panelSerial.SuspendLayout();
            this.panelStart.SuspendLayout();
            this.panelStart2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSerial
            // 
            this.panelSerial.Controls.Add(this.comboBoxSerials);
            this.panelSerial.Controls.Add(this.buttonReset);
            this.panelSerial.Controls.Add(this.buttonConnect);
            this.panelSerial.Location = new System.Drawing.Point(12, 12);
            this.panelSerial.Name = "panelSerial";
            this.panelSerial.Size = new System.Drawing.Size(316, 36);
            this.panelSerial.TabIndex = 22;
            // 
            // comboBoxSerials
            // 
            this.comboBoxSerials.FormattingEnabled = true;
            this.comboBoxSerials.Location = new System.Drawing.Point(81, 3);
            this.comboBoxSerials.Name = "comboBoxSerials";
            this.comboBoxSerials.Size = new System.Drawing.Size(121, 23);
            this.comboBoxSerials.TabIndex = 9;
            this.comboBoxSerials.SelectedIndexChanged += new System.EventHandler(this.comboBoxSerials_SelectedIndexChanged);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(0, 3);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 10;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(208, 2);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 11;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(297, 66);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 23;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxLogID
            // 
            this.textBoxLogID.Location = new System.Drawing.Point(29, 3);
            this.textBoxLogID.Name = "textBoxLogID";
            this.textBoxLogID.Size = new System.Drawing.Size(102, 25);
            this.textBoxLogID.TabIndex = 24;
            // 
            // panelStart
            // 
            this.panelStart.Controls.Add(this.comboBoxSpatial);
            this.panelStart.Controls.Add(this.labelSpatial);
            this.panelStart.Controls.Add(this.comboBoxBlock);
            this.panelStart.Controls.Add(this.label5);
            this.panelStart.Controls.Add(this.label2);
            this.panelStart.Controls.Add(this.comboBoxDepth);
            this.panelStart.Controls.Add(this.comboBoxTrainMain);
            this.panelStart.Controls.Add(this.comboBoxSS);
            this.panelStart.Controls.Add(this.label1);
            this.panelStart.Controls.Add(this.labelDepth);
            this.panelStart.Controls.Add(this.labelSS);
            this.panelStart.Controls.Add(this.textBoxLogID);
            this.panelStart.Controls.Add(this.buttonStart);
            this.panelStart.Location = new System.Drawing.Point(14, 56);
            this.panelStart.Name = "panelStart";
            this.panelStart.Size = new System.Drawing.Size(380, 98);
            this.panelStart.TabIndex = 25;
            // 
            // comboBoxSpatial
            // 
            this.comboBoxSpatial.FormattingEnabled = true;
            this.comboBoxSpatial.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboBoxSpatial.Location = new System.Drawing.Point(236, 36);
            this.comboBoxSpatial.Name = "comboBoxSpatial";
            this.comboBoxSpatial.Size = new System.Drawing.Size(40, 23);
            this.comboBoxSpatial.TabIndex = 34;
            // 
            // labelSpatial
            // 
            this.labelSpatial.AutoSize = true;
            this.labelSpatial.Location = new System.Drawing.Point(179, 42);
            this.labelSpatial.Name = "labelSpatial";
            this.labelSpatial.Size = new System.Drawing.Size(51, 15);
            this.labelSpatial.TabIndex = 33;
            this.labelSpatial.Text = "Spatial";
            // 
            // comboBoxBlock
            // 
            this.comboBoxBlock.FormattingEnabled = true;
            this.comboBoxBlock.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBoxBlock.Location = new System.Drawing.Point(332, 37);
            this.comboBoxBlock.Name = "comboBoxBlock";
            this.comboBoxBlock.Size = new System.Drawing.Size(40, 23);
            this.comboBoxBlock.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(282, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 31;
            this.label5.Text = "Block";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "Type";
            // 
            // comboBoxDepth
            // 
            this.comboBoxDepth.FormattingEnabled = true;
            this.comboBoxDepth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "vib"});
            this.comboBoxDepth.Location = new System.Drawing.Point(54, 36);
            this.comboBoxDepth.Name = "comboBoxDepth";
            this.comboBoxDepth.Size = new System.Drawing.Size(40, 23);
            this.comboBoxDepth.TabIndex = 26;
            // 
            // comboBoxTrainMain
            // 
            this.comboBoxTrainMain.FormattingEnabled = true;
            this.comboBoxTrainMain.Items.AddRange(new object[] {
            "Train",
            "Main",
            "VibTrain",
            "VibMain"});
            this.comboBoxTrainMain.Location = new System.Drawing.Point(206, 3);
            this.comboBoxTrainMain.Name = "comboBoxTrainMain";
            this.comboBoxTrainMain.Size = new System.Drawing.Size(90, 23);
            this.comboBoxTrainMain.TabIndex = 12;
            // 
            // comboBoxSS
            // 
            this.comboBoxSS.FormattingEnabled = true;
            this.comboBoxSS.Items.AddRange(new object[] {
            "X",
            "O"});
            this.comboBoxSS.Location = new System.Drawing.Point(133, 37);
            this.comboBoxSS.Name = "comboBoxSS";
            this.comboBoxSS.Size = new System.Drawing.Size(40, 23);
            this.comboBoxSS.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "ID";
            // 
            // labelDepth
            // 
            this.labelDepth.AutoSize = true;
            this.labelDepth.Location = new System.Drawing.Point(3, 42);
            this.labelDepth.Name = "labelDepth";
            this.labelDepth.Size = new System.Drawing.Size(45, 15);
            this.labelDepth.TabIndex = 28;
            this.labelDepth.Text = "Depth";
            // 
            // labelSS
            // 
            this.labelSS.AutoSize = true;
            this.labelSS.Location = new System.Drawing.Point(100, 42);
            this.labelSS.Name = "labelSS";
            this.labelSS.Size = new System.Drawing.Size(27, 15);
            this.labelSS.TabIndex = 29;
            this.labelSS.Text = "SS";
            // 
            // panelStart2
            // 
            this.panelStart2.Controls.Add(this.buttonStart2);
            this.panelStart2.Controls.Add(this.comboBoxLevel);
            this.panelStart2.Controls.Add(this.labelLevel);
            this.panelStart2.Controls.Add(this.comboBoxTactile);
            this.panelStart2.Controls.Add(this.labelTactile);
            this.panelStart2.Controls.Add(this.labelID2);
            this.panelStart2.Controls.Add(this.textBoxID2);
            this.panelStart2.Location = new System.Drawing.Point(12, 163);
            this.panelStart2.Name = "panelStart2";
            this.panelStart2.Size = new System.Drawing.Size(382, 100);
            this.panelStart2.TabIndex = 26;
            // 
            // buttonStart2
            // 
            this.buttonStart2.Location = new System.Drawing.Point(299, 74);
            this.buttonStart2.Name = "buttonStart2";
            this.buttonStart2.Size = new System.Drawing.Size(75, 23);
            this.buttonStart2.TabIndex = 35;
            this.buttonStart2.Text = "Start";
            this.buttonStart2.UseVisualStyleBackColor = true;
            this.buttonStart2.Click += new System.EventHandler(this.buttonStart2_Click);
            // 
            // comboBoxLevel
            // 
            this.comboBoxLevel.FormattingEnabled = true;
            this.comboBoxLevel.Items.AddRange(new object[] {
            "None",
            "Easy",
            "Difficult"});
            this.comboBoxLevel.Location = new System.Drawing.Point(51, 36);
            this.comboBoxLevel.Name = "comboBoxLevel";
            this.comboBoxLevel.Size = new System.Drawing.Size(74, 23);
            this.comboBoxLevel.TabIndex = 38;
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Location = new System.Drawing.Point(3, 39);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(42, 15);
            this.labelLevel.TabIndex = 37;
            this.labelLevel.Text = "Level";
            // 
            // comboBoxTactile
            // 
            this.comboBoxTactile.FormattingEnabled = true;
            this.comboBoxTactile.Items.AddRange(new object[] {
            "None",
            "Poke",
            "Vib"});
            this.comboBoxTactile.Location = new System.Drawing.Point(184, 36);
            this.comboBoxTactile.Name = "comboBoxTactile";
            this.comboBoxTactile.Size = new System.Drawing.Size(90, 23);
            this.comboBoxTactile.TabIndex = 35;
            // 
            // labelTactile
            // 
            this.labelTactile.AutoSize = true;
            this.labelTactile.Location = new System.Drawing.Point(131, 39);
            this.labelTactile.Name = "labelTactile";
            this.labelTactile.Size = new System.Drawing.Size(49, 15);
            this.labelTactile.TabIndex = 35;
            this.labelTactile.Text = "Tactile";
            // 
            // labelID2
            // 
            this.labelID2.AutoSize = true;
            this.labelID2.Location = new System.Drawing.Point(5, 6);
            this.labelID2.Name = "labelID2";
            this.labelID2.Size = new System.Drawing.Size(20, 15);
            this.labelID2.TabIndex = 36;
            this.labelID2.Text = "ID";
            // 
            // textBoxID2
            // 
            this.textBoxID2.Location = new System.Drawing.Point(27, 3);
            this.textBoxID2.Name = "textBoxID2";
            this.textBoxID2.Size = new System.Drawing.Size(77, 25);
            this.textBoxID2.TabIndex = 35;
            // 
            // ExpManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 275);
            this.Controls.Add(this.panelStart2);
            this.Controls.Add(this.panelStart);
            this.Controls.Add(this.panelSerial);
            this.Name = "ExpManager";
            this.Text = "Form1";
            this.panelSerial.ResumeLayout(false);
            this.panelStart.ResumeLayout(false);
            this.panelStart.PerformLayout();
            this.panelStart2.ResumeLayout(false);
            this.panelStart2.PerformLayout();
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
        private System.Windows.Forms.ComboBox comboBoxSpatial;
        private System.Windows.Forms.Label labelSpatial;
        private System.Windows.Forms.ComboBox comboBoxBlock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxDepth;
        private System.Windows.Forms.ComboBox comboBoxSS;
        private System.Windows.Forms.Label labelDepth;
        private System.Windows.Forms.Label labelSS;
        private System.Windows.Forms.Panel panelStart2;
        private System.Windows.Forms.Button buttonStart2;
        private System.Windows.Forms.ComboBox comboBoxLevel;
        private System.Windows.Forms.Label labelLevel;
        private System.Windows.Forms.ComboBox comboBoxTactile;
        private System.Windows.Forms.Label labelTactile;
        private System.Windows.Forms.Label labelID2;
        private System.Windows.Forms.TextBox textBoxID2;
    }
}


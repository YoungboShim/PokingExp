using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace PokingExp
{
    public partial class ExpManager : Form
    {
        int[] depthCond = { 1, 2, 3 };   // depth condition
        string[] ssCond = { "X", "O" };   // sensory saltation condition
        string[] spCond = { "line", "point", "leftmost", "rightmost" }; // spatial pattern condition
        int depth = 20;
        int duration = 100;

        public ExpManager()
        {
            InitializeComponent();
            panelStart.Enabled = false;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            // Get available ports
            String[] ports = SerialPort.GetPortNames();
            // Display ports in combobox
            comboBoxSerials.Items.Clear();
            comboBoxSerials.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                comboBoxSerials.SelectedIndex = comboBoxSerials.Items.Count - 1;
                serialPort1.BaudRate = 115200;
                serialPort1.DtrEnable = true;
                serialPort1.RtsEnable = true;
            }
        }

        private void comboBoxSerials_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            //Connect to combobox selected serial port
            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = (String)comboBoxSerials.Items[comboBoxSerials.SelectedIndex];
                    serialPort1.Open();
                string line = serialPort1.ReadExisting();
                Console.WriteLine("Start");
                if (line == "Ready for command...")
                    buttonConnect.BackColor = Color.Orange;
                panelStart.Enabled = true;
                panelStart2.Enabled = true;
            }
            else
            {
                serialPort1.Close();
                buttonConnect.BackColor = SystemColors.ButtonFace;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int depthIdx = comboBoxDepth.SelectedIndex;
            int spIdx = comboBoxSpatial.SelectedIndex;
            int block = comboBoxBlock.SelectedIndex + 1;
            bool ss;
            if (comboBoxSS.SelectedIndex == 0)
                ss = false;
            else
                ss = true;
            if (comboBoxTrainMain.SelectedIndex == 0)
            {
                Exp1Training program = new Exp1Training();
                program.setExp1training(serialPort1, depthIdx, ss, spIdx);
                program.Show();
            }
            else if (comboBoxTrainMain.SelectedIndex == 1)
            {
                Exp1Main programMain = new Exp1Main();
                programMain.setExp1Main(serialPort1, depthIdx, ss, spIdx, block, textBoxLogID.Text);
                programMain.Show();
            }
            else if (comboBoxTrainMain.SelectedIndex == 2)
            {
                VibTraining programVibT = new VibTraining();
                programVibT.setVibTraining(serialPort1, true, ss, spIdx);
                programVibT.Show();
            }
            else if(comboBoxTrainMain.SelectedIndex == 3)
            {
                Exp1Vib programVibM = new Exp1Vib();
                programVibM.setExp1Vib(serialPort1, block, textBoxLogID.Text);
                programVibM.Show();
            }
        }

        private void buttonStart2_Click(object sender, EventArgs e)
        {
            String logID = textBoxID2.Text;
            bool tactileOn = true, pokeOn = true;
            int difficultyNum = 0;

            if (comboBoxLevel.SelectedIndex == 0)
                difficultyNum = 0;
            else if (comboBoxLevel.SelectedIndex == 1)
                difficultyNum = 16;
            else if (comboBoxLevel.SelectedIndex == 2)
                difficultyNum = 36;

            if (comboBoxTactile.SelectedIndex == 0)
                tactileOn = false;
            else if (comboBoxTactile.SelectedIndex == 1)
                pokeOn = true;
            else if (comboBoxTactile.SelectedIndex == 2)
                pokeOn = false;

            MainTask mainProgram = new MainTask();
            mainProgram.Start(difficultyNum, "Exp3_" + logID + "_" + difficultyNum.ToString() + "_" + comboBoxTactile.SelectedIndex.ToString() + ".txt");
            mainProgram.Show();
            if (tactileOn)
            {
                SecondaryTask secProgram = new SecondaryTask();
                secProgram.setSecondaryTask(serialPort1, pokeOn, logID, comboBoxLevel.SelectedIndex);
                secProgram.Show();
                secProgram.Focus();
            }
        }

        private void buttonCalibration_Click(object sender, EventArgs e)
        {
            Calibration calibProgram = new Calibration();
            calibProgram.setCalibration(serialPort1);
            calibProgram.Show();
            calibProgram.Focus();
        }
    }
}

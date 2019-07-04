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
                if (line == "Poke-Vibration Multimodal Tactile Display...")
                    buttonConnect.BackColor = Color.Orange;
                panelStart.Enabled = true;
            }
            else
            {
                serialPort1.Close();
                buttonConnect.BackColor = SystemColors.ButtonFace;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int block = comboBoxBlock.SelectedIndex + 1;
            int shortLong = comboBoxShortLong.SelectedIndex;    // short : 0, long : 1
            int velNum = comboBoxVelocity.SelectedIndex;

            if (comboBoxTrainMain.SelectedIndex == 0)
            {
                Exp1Training program = new Exp1Training();
                program.setExp1training(serialPort1, true, 1, shortLong, velNum);
                program.Show();
            }
            else if (comboBoxTrainMain.SelectedIndex == 1)
            {
                Exp1Main programMain = new Exp1Main();
                programMain.setExp1Main(serialPort1, true, 1, block, textBoxLogID.Text, shortLong, velNum);
                programMain.Show();
            }
        }

        private void buttonCalibration_Click(object sender, EventArgs e)
        {
            Calibration calibProgram = new Calibration();
            calibProgram.setCalibration(serialPort1, textBoxLogID.Text);
            calibProgram.Show();
            calibProgram.Focus();
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("z");
        }

        private void comboBoxBlock_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxShortLong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PokeSandbox sandbox = new PokeSandbox();
            sandbox.setSerialPort(serialPort1);
            sandbox.Show();
            sandbox.Focus();
        }
    }
}

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
using System.IO;

namespace PokingExp
{
    public partial class Calibration : Form
    {
        int[] idlePos = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        Button[] upBtns = new Button[9];
        Button[] downBtns = new Button[9];
        String filename;

        public Calibration()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;

            downBtns[0] = button1;
            upBtns[0] = button2;
            downBtns[1] = button3;
            upBtns[1] = button4;
            downBtns[2] = button5;
            upBtns[2] = button6;
            downBtns[3] = button7;
            upBtns[3] = button8;
            downBtns[4] = button9;
            upBtns[4] = button10;
            downBtns[5] = button11;
            upBtns[5] = button12;
            downBtns[6] = button13;
            upBtns[6] = button14;
            downBtns[7] = button15;
            upBtns[7] = button16;
            downBtns[8] = button17;
            upBtns[8] = button18;

            for(int i = 0; i < 9;i++)
            {
                upBtns[i].Enabled = false;
                downBtns[i].Enabled = true;
            }
        }

        public void setCalibration(SerialPort serialPort, String logId)
        {
            serialPort1 = serialPort;
            textBoxFilename.Text = logId;
        }

        private void tipDown(int moduleIdx)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine(String.Format("t{0}{1:d2}", moduleIdx + 1, ++idlePos[moduleIdx]));
                Console.WriteLine(serialPort1.ReadLine());
            }
            if (idlePos[moduleIdx] >= 70)
                downBtns[moduleIdx].Enabled = false;
            if (idlePos[moduleIdx] > 0)
                upBtns[moduleIdx].Enabled = true;
        }

        private void tipUp(int moduleIdx)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine(String.Format("t{0}{1:d2}", moduleIdx + 1, --idlePos[moduleIdx]));
                Console.WriteLine(serialPort1.ReadLine());
            }
            if (idlePos[moduleIdx] < 70)
                downBtns[moduleIdx].Enabled = true;
            if (idlePos[moduleIdx] <= 0)
                upBtns[moduleIdx].Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tipDown(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tipUp(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tipDown(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tipUp(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tipDown(2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tipUp(2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tipDown(3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tipUp(3);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tipDown(4);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tipUp(4);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tipDown(5);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tipUp(5);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tipDown(6);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tipUp(6);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            tipDown(7);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tipUp(7);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tipDown(8);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tipUp(8);
        }

        private void textBoxFilename_TextChanged(object sender, EventArgs e)
        {
            filename = textBoxFilename.Text;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(filename != null)
            {
                TextWriter tw;
                tw = new StreamWriter(filename + ".txt", true);

                String config = "";
                for(int i=0;i<9;i++)
                {
                    config += String.Format("{0:D2} ", idlePos[i]);
                }

                tw.WriteLine(config);

                tw.Close();
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            String strConfig = textBoxLoadString.Text;
            String[] configs = strConfig.Split(' ');

            for(int i=0;i<9;i++)
            {
                serialPort1.WriteLine(String.Format("t{0}{1}", i + 1, configs[i]));
            }
        }
    }
}

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
    public partial class Exp1Training : Form
    {
        enum pattern { up, down, left, right };
        string[,,] patternCmd = { { {"p4", "p5", "p6" },
                                    {"p6", "p5", "p4" },
                                    {"p2", "p5", "p8" },
                                    {"p8", "p5", "p2" } },
                                  { {"p7", "p8", "p9" },
                                    {"p9", "p8", "p7" },
                                    {"p2", "p5", "p8" },
                                    {"p8", "p5", "p2" } },
                                  { {"p1", "p2", "p3" },
                                    {"p3", "p2", "p1" },
                                    {"p2", "p5", "p8" },
                                    {"p8", "p5", "p2" } } };
                                /*{ { {"m4", "m5", "m6" },
                                    {"m6", "m5", "m4" },
                                    {"m2", "m5", "m8" },
                                    {"m8", "m5", "m2" } },
                                  { {"m7", "m8", "m9" },
                                    {"m9", "m8", "m7" },
                                    {"m2", "m5", "m8" },
                                    {"m8", "m5", "m2" } },
                                  { {"m1", "m2", "m3" },
                                    {"m3", "m2", "m1" },
                                    {"m2", "m5", "m8" },
                                    {"m8", "m5", "m2" } } };*/
        string[,,] patternLineCmd = { { {"p7", "p4", "p1" },
                                        {"p8", "p5", "p2" },
                                        {"p9", "p6", "p3" } },
                                      { {"p9", "p6", "p3" },
                                        {"p8", "p5", "p2" },
                                        {"p7", "p4", "p1" } },
                                      { {"p3", "p2", "p1" },
                                        {"p6", "p5", "p4" },
                                        {"p9", "p8", "p7" } },
                                      { {"p9", "p8", "p7" },
                                        {"p6", "p5", "p4" },
                                        {"p3", "p2", "p1" } } };
                                    /*{ { {"m7", "m4", "m1" },
                                        {"m8", "m5", "m2" },
                                        {"m9", "m6", "m3" } },
                                      { {"m9", "m6", "m3" },
                                        {"m8", "m5", "m2" },
                                        {"m7", "m4", "m1" } },
                                      { {"m3", "m2", "m1" },
                                        {"m6", "m5", "m4" },
                                        {"m9", "m8", "m7" } },
                                      { {"m9", "m8", "m7" },
                                        {"m6", "m5", "m4" },
                                        {"m3", "m2", "m1" } } };*/
        int[] depthCond = { 1, 2, 3, 4 };   // depth condition
        int patternNum = 4;
        int repeatNum = 12;
        int conditionNum;
        float depth = 1.5f;
        int duration = 250;
        int pullDuration = 100;
        int patternPositionIdx = 0;
        int spIdx = 0;
        float pokeSpeed = 0.06f;
        float pullTime;
        pattern currPattern = pattern.up;
        bool traningEnd = false;
        bool answerMode = false;
        bool ssFlag = false;
        bool lineFlag = false;

        public Exp1Training()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            /*
            buttonUp.PreviewKeyDown += button_PreviewKeyDown;
            buttonDown.PreviewKeyDown += button_PreviewKeyDown;
            buttonLeft.PreviewKeyDown += button_PreviewKeyDown;
            buttonRight.PreviewKeyDown += button_PreviewKeyDown;
            buttonPlay.PreviewKeyDown += button_PreviewKeyDown;

            buttonUp.KeyDown += button_KeyDown;
            buttonDown.KeyDown += button_KeyDown;
            buttonLeft.KeyDown += button_KeyDown;
            buttonRight.KeyDown += button_KeyDown;
            buttonPlay.KeyDown += button_KeyDown;

            buttonUp.KeyPress += button_KeyPress;
            buttonDown.KeyPress += button_KeyPress;
            buttonLeft.KeyPress += button_KeyPress;
            buttonRight.KeyPress += button_KeyPress;
            buttonPlay.KeyPress += button_KeyPress;
            */

            labelWait.Text = "";
        }

        public void getSerialPort(SerialPort port)
        {
            serialPort1 = port;
        }

        public void setExp1training(SerialPort port, int pokingDepthIdx, bool sensorySaltation, int spatialPattern)
        {
            serialPort1 = port;
            /*
            depth = depthCond[pokingDepthIdx];
            if (depth == 1)
            {
                serialPort1.WriteLine("q");
                pullTime = (depth + 0.25f) / pokeSpeed;
            }
            else if (depth == 2)
            {
                serialPort1.WriteLine("w");
                pullTime = (depth + 0.25f) / pokeSpeed;
            }
            else if (depth == 3)
            {
                serialPort1.WriteLine("e");
                pullTime = (depth + 0.25f) / pokeSpeed;
            }
            else if (depth == 4)
            {
                pullTime = 80;
            }
            */
            pullTime = (depth + 0.25f) / pokeSpeed;
            ssFlag = sensorySaltation;
            spIdx = spatialPattern;
            lineFlag = (spatialPattern == 0);
            timerTraining.Enabled = true;
        }

        private void playPattern()
        {
            int tmpIdx;
            if (ssFlag)
            {
                tmpIdx = patternPositionIdx / 2;
            }
            else
            {
                tmpIdx = patternPositionIdx;
            }
            if (lineFlag)
            {
                serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 0]);
                serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 1]);
                serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 2]);
            }
            else
            {
                serialPort1.WriteLine(patternCmd[(spIdx - 1), (int)currPattern, tmpIdx]);
            }
            timerPull.Interval = (int)pullTime;
            timerPull.Enabled = true;
            timerDuration.Interval = (int)duration;
            timerDuration.Enabled = true;
            if (ssFlag)
            {
                timerSS.Interval = (int)duration / 2;
                timerSS.Enabled = true;
            }
            serialPort1.ReadExisting();
        }

        private void timerPull_Tick(object sender, EventArgs e)
        {
            int tmpIdx;
            if (ssFlag)
            {
                tmpIdx = patternPositionIdx / 2;
            }
            else
            {
                tmpIdx = patternPositionIdx;
            }
            if (lineFlag)
            {
                serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 0]);
                serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 1]);
                serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 2]);
            }
            else
            {
                serialPort1.WriteLine(patternCmd[(spIdx - 1), (int)currPattern, tmpIdx]);
            }
            patternPositionIdx++;
            timerPull.Enabled = false;
        }

        private void timerDuration_Tick(object sender, EventArgs e)
        {
            if ((patternPositionIdx >= 3 && !ssFlag) || (patternPositionIdx >= 6 && ssFlag))
            {
                patternPositionIdx = 0;
                timerDuration.Enabled = false;
                labelWait.Text = "";
                buttonUp.Enabled = true;
                buttonDown.Enabled = true;
                buttonLeft.Enabled = true;
                buttonRight.Enabled = true;
                if(!answerMode)
                    buttonPlay.Enabled = true;
            }
            else
            {
                playPattern();
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (answerMode)
            {
                buttonUp.BackColor = Color.Red;
                switch(currPattern)
                {
                    case pattern.up:
                        buttonUp.BackColor = Color.Green;
                        break;
                    case pattern.down:
                        buttonDown.BackColor = Color.Green;
                        break;
                    case pattern.left:
                        buttonLeft.BackColor = Color.Green;
                        break;
                    case pattern.right:
                        buttonRight.BackColor = Color.Green;
                        break;
                    default:
                        break;
                }
                Delay(1000);
                buttonUp.BackColor = Color.Black;
                buttonDown.BackColor = Color.Black;
                buttonLeft.BackColor = Color.Black;
                buttonRight.BackColor = Color.Black;
                answerMode = false;
                buttonPlay.Enabled = true;
            }
            else
            {
                currPattern = pattern.up;
                labelWait.Text = "Up";
                buttonUp.Enabled = false;
                buttonDown.Enabled = false;
                buttonLeft.Enabled = false;
                buttonRight.Enabled = false;
                buttonPlay.Enabled = false;
                playPattern();
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (answerMode)
            {
                buttonDown.BackColor = Color.Red;
                switch (currPattern)
                {
                    case pattern.up:
                        buttonUp.BackColor = Color.Green;
                        break;
                    case pattern.down:
                        buttonDown.BackColor = Color.Green;
                        break;
                    case pattern.left:
                        buttonLeft.BackColor = Color.Green;
                        break;
                    case pattern.right:
                        buttonRight.BackColor = Color.Green;
                        break;
                    default:
                        break;
                }
                Delay(1000);
                buttonUp.BackColor = Color.Black;
                buttonDown.BackColor = Color.Black;
                buttonLeft.BackColor = Color.Black;
                buttonRight.BackColor = Color.Black;
                answerMode = false;
                buttonPlay.Enabled = true;
            }
            else
            {
                currPattern = pattern.down;
                labelWait.Text = "Down";
                buttonUp.Enabled = false;
                buttonDown.Enabled = false;
                buttonLeft.Enabled = false;
                buttonRight.Enabled = false;
                buttonPlay.Enabled = false;
                playPattern();
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            if (answerMode)
            {
                buttonLeft.BackColor = Color.Red;
                switch (currPattern)
                {
                    case pattern.up:
                        buttonUp.BackColor = Color.Green;
                        break;
                    case pattern.down:
                        buttonDown.BackColor = Color.Green;
                        break;
                    case pattern.left:
                        buttonLeft.BackColor = Color.Green;
                        break;
                    case pattern.right:
                        buttonRight.BackColor = Color.Green;
                        break;
                    default:
                        break;
                }
                Delay(1000);
                buttonUp.BackColor = Color.Black;
                buttonDown.BackColor = Color.Black;
                buttonLeft.BackColor = Color.Black;
                buttonRight.BackColor = Color.Black;
                answerMode = false;
                buttonPlay.Enabled = true;
            }
            else
            {
                currPattern = pattern.left;
                labelWait.Text = "Left";
                buttonUp.Enabled = false;
                buttonDown.Enabled = false;
                buttonLeft.Enabled = false;
                buttonRight.Enabled = false;
                buttonPlay.Enabled = false;
                playPattern();
            }
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            if (answerMode)
            {
                buttonRight.BackColor = Color.Red;
                switch (currPattern)
                {
                    case pattern.up:
                        buttonUp.BackColor = Color.Green;
                        break;
                    case pattern.down:
                        buttonDown.BackColor = Color.Green;
                        break;
                    case pattern.left:
                        buttonLeft.BackColor = Color.Green;
                        break;
                    case pattern.right:
                        buttonRight.BackColor = Color.Green;
                        break;
                    default:
                        break;
                }
                Delay(1000);
                buttonUp.BackColor = Color.Black;
                buttonDown.BackColor = Color.Black;
                buttonLeft.BackColor = Color.Black;
                buttonRight.BackColor = Color.Black;
                answerMode = false;
                buttonPlay.Enabled = true;
            }
            else
            {
                currPattern = pattern.right;
                labelWait.Text = "Right";
                buttonUp.Enabled = false;
                buttonDown.Enabled = false;
                buttonLeft.Enabled = false;
                buttonRight.Enabled = false;
                buttonPlay.Enabled = false;
                playPattern();
            }
        }

        private void timerTraining_Tick(object sender, EventArgs e)
        {
            buttonUp.Enabled = false;
            buttonDown.Enabled = false;
            buttonLeft.Enabled = false;
            buttonRight.Enabled = false;
            labelTrial.Text = "Finished";
            buttonPlay.Text = "Exp Start";
            traningEnd = true;
            timerTraining.Enabled = false;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if(traningEnd)
            {
                this.Close();
            }
            else
            {
                Random randGen = new Random();
                currPattern = (pattern)randGen.Next(4);
                buttonUp.Enabled = false;
                buttonDown.Enabled = false;
                buttonLeft.Enabled = false;
                buttonRight.Enabled = false;
                buttonPlay.Enabled = false;
                answerMode = true;
                labelWait.Text = "Playing";
                playPattern();
            }
        }

        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);
            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }

        private void timerSS_Tick(object sender, EventArgs e)
        {
            int tmpIdx;
            if (ssFlag)
            {
                tmpIdx = patternPositionIdx / 2;
            }
            else
            {
                tmpIdx = patternPositionIdx;
            }
            if (lineFlag)
            {
                serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 0]);
                serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 1]);
                serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 2]);
            }
            else
            {
                serialPort1.WriteLine(patternCmd[(spIdx - 1), (int)currPattern, tmpIdx]);
            }
            timerPull.Interval = (int)pullTime;
            timerPull.Enabled = true;
            timerSS.Enabled = false;
        }

        private void button_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    e.IsInputKey = true;
                    break;                    
            }
        }

        private void button_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    if (buttonUp.Enabled)
                        buttonUp_Click(sender, e);
                    break;
                case Keys.Down:
                    if (buttonDown.Enabled)
                        buttonDown_Click(sender, e);
                    break;
                case Keys.Left:
                    if (buttonLeft.Enabled)
                        buttonLeft_Click(sender, e);
                    break;
                case Keys.Right:
                    if (buttonRight.Enabled)
                        buttonRight_Click(sender, e);
                    break;
                case Keys.Enter:
                    Console.WriteLine("Enter down");
                    e.Handled = true;
                    if (buttonPlay.Enabled)
                        buttonPlay_Click(sender, e);
                    break;
            }
        }

        private void Exp1Training_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            button_PreviewKeyDown(sender, e);
        }

        private void Exp1Training_KeyDown(object sender, KeyEventArgs e)
        {
            button_KeyDown(sender, e);
        }
    }
}

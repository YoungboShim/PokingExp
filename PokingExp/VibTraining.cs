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
    public partial class VibTraining : Form
    {
        enum pattern { up, down, left, right };
        string[,,] patternCmd = { { {"a4", "a5", "a6" },
                                    {"a6", "a5", "a4" },
                                    {"a2", "a5", "a8" },
                                    {"a8", "a5", "a2" } },
                                  { {"a7", "a8", "a9" },
                                    {"a9", "a8", "a7" },
                                    {"a2", "a5", "a8" },
                                    {"a8", "a5", "a2" } },
                                  { {"a1", "a2", "a3" },
                                    {"a3", "a2", "a1" },
                                    {"a2", "a5", "a8" },
                                    {"a8", "a5", "a2" } } };
        string[,,] patternLineCmd = { { {"m7", "m4", "m1" },
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
                                        {"m3", "m2", "m1" } } };
        int duration = 250;
        float pullDuration = 80;
        int patternPositionIdx = 0;
        int spIdx = 0;

        pattern currPattern = pattern.up;
        bool traningEnd = false;
        bool answerMode = false;
        bool pulseFlag = false;
        bool ssFlag = false;
        bool lineFlag = false;
        public VibTraining()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            labelWait.Text = "";
        }

        public void setVibTraining(SerialPort port, bool pulseOn, bool sensorySaltation, int spatialPattern)
        {
            serialPort1 = port;
            pulseFlag = pulseOn;
            ssFlag = sensorySaltation;
            spIdx = spatialPattern;
            lineFlag = (spatialPattern == 0);
            timerTraining.Enabled = true;
        }

        private void playPattern()
        {
            int tmpIdx;
            if(ssFlag)
            {
                tmpIdx = patternPositionIdx / 2;
            }
            else
            {
                tmpIdx = patternPositionIdx;
            }
            if(lineFlag)
            {
                // TODO: After line firmware update
            }
            else
            {
                serialPort1.WriteLine(patternCmd[(spIdx - 1), (int)currPattern, tmpIdx]);
            }
            timerDuration.Interval = (int)duration;
            timerDuration.Enabled = true;
            if(ssFlag)
            {
                timerSS.Interval = (int)duration / 2;
                timerSS.Enabled = true;
            }
            serialPort1.ReadExisting();
            patternPositionIdx++;
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
                if (!answerMode)
                    buttonPlay.Enabled = true;
            }
            else
            {
                playPattern();
            }
        }

        private void timerSS_Tick(object sender, EventArgs e)
        {
            int tmpIdx;
            if(ssFlag)
            {
                tmpIdx = patternPositionIdx / 2;
            }
            else
            {
                tmpIdx = patternPositionIdx;
            }
            if (lineFlag)
            {
                // TODO: After line firmware update
            }
            else
            {
                serialPort1.WriteLine(patternCmd[(spIdx - 1), (int)currPattern, tmpIdx]);
            }

            patternPositionIdx++;
            timerSS.Enabled = false;
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (answerMode)
            {
                buttonUp.BackColor = Color.Red;
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
                currPattern = pattern.up;
                labelWait.Text = "Up";
                buttonUp.Enabled = false;
                buttonDown.Enabled = false;
                buttonLeft.Enabled = false;
                buttonRight.Enabled = false;
                buttonPlay.Enabled = false;
                Delay(500);
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
                Delay(500);
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
                Delay(500);
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
                Delay(500);
                playPattern();
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (traningEnd)
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
                Delay(500);
                answerMode = true;
                labelWait.Text = "Playing";
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


        private void VibTraning_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        private void VibTraning_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
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
    }
}

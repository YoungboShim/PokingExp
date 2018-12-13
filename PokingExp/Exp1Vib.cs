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
    public partial class Exp1Vib : Form
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
        static string[] spCond = { "line", "point", "leftmost", "rightmost" }; // spatial pattern condition
        int patternNum = 4;
        int repeatNum = 12;
        int[] stimuli;
        int duration = 250;
        int patternPositionIdx = 0;
        pattern currPattern = pattern.up;
        int spIdx = 2;
        int stimuliIdx = 0;
        long timeStart = 0, timeEnd = 0;
        long timeAsk = 0, timeAnswer = 0;
        TextWriter tw, twTime;
        string userID;
        int block = 1;
        public Exp1Vib()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            stimuli = new int[patternNum * repeatNum];
            enableButtons(false);
            labelWait.Text = "";
            randomizeStimuli();
        }

        public void setExp1Vib(SerialPort port, int blockNum, string logID)
        {
            serialPort1 = port;
            userID = logID;
            block = blockNum;
            timerDuration.Interval = (int)duration;
            timerSS.Interval = (int)(duration / 2);
            tw = new StreamWriter("Exp2_" + logID + "_vib_" + blockNum.ToString() + ".csv", true);
            tw.WriteLine("Trial#, Stimuli, Answer, Correct, RT(ms)");
            tw.Flush();
            twTime = new StreamWriter("Exp1_time.csv", true);
        }

        private void timerDuration_Tick(object sender, EventArgs e)
        {
            if (patternPositionIdx >= 6)
            {
                patternPositionIdx = 0;
                timerDuration.Enabled = false;
                labelWait.Text = "Click the answer";
                enableButtons(true);
                timeAsk = DateTime.Now.Ticks;
            }
            else
            {
                playPattern();
            }
        }

        private void timerSS_Tick(object sender, EventArgs e)
        {
            int tmpIdx;
            tmpIdx = patternPositionIdx / 2;
            serialPort1.WriteLine(patternCmd[(spIdx - 1), (int)currPattern, tmpIdx]);

            patternPositionIdx++;
            timerSS.Enabled = false;
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            buttonUp.BackColor = Color.Gray;
            clickAnswer(pattern.up);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            buttonDown.BackColor = Color.Gray;
            clickAnswer(pattern.down);
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            buttonLeft.BackColor = Color.Gray;
            clickAnswer(pattern.left);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            buttonRight.BackColor = Color.Gray;
            clickAnswer(pattern.right);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (stimuliIdx == 0)
            {
                timeStart = DateTime.Now.Ticks;
            }
            currPattern = (pattern)stimuli[stimuliIdx++];
            buttonPlay.Enabled = false;
            Delay(500);
            labelWait.Text = "Playing";
            playPattern();
        }

        private void Exp1Vib_FormClosing(object sender, FormClosingEventArgs e)
        {
            tw.Close();
            twTime.Close();
        }

        private void randomizeStimuli()
        {
            Random random = new Random();
            int tmpNum;
            int[] randomIdx = new int[patternNum * repeatNum];
            int[] sampleStimuli = new int[patternNum * repeatNum];
            for (int i = 0; i < patternNum * repeatNum; i++)
            {
                randomIdx[i] = -1;
            }
            for (int i = 0; i < patternNum; i++)
            {
                for (int j = 0; j < repeatNum; j++)
                {
                    sampleStimuli[i * repeatNum + j] = i;
                    tmpNum = random.Next(patternNum * repeatNum);
                    while (randomIdx.Contains(tmpNum))
                    {
                        tmpNum = random.Next(patternNum * repeatNum);
                    }
                    randomIdx[i * repeatNum + j] = tmpNum;
                }
            }
            for (int i = 0; i < patternNum * repeatNum; i++)
            {
                stimuli[i] = sampleStimuli[randomIdx[i]];
            }
        }

        private void enableButtons(bool flag)
        {
            buttonUp.Enabled = flag;
            buttonDown.Enabled = flag;
            buttonLeft.Enabled = flag;
            buttonRight.Enabled = flag;
        }

        private void playPattern()
        {
            int tmpIdx;
            tmpIdx = patternPositionIdx / 2;
            serialPort1.WriteLine(patternCmd[(spIdx - 1), (int)currPattern, tmpIdx]);
            
            timerDuration.Interval = (int)duration;
            timerDuration.Enabled = true;
            timerSS.Interval = (int)duration / 2;
            timerSS.Enabled = true;

            serialPort1.ReadExisting();
            patternPositionIdx++;
        }

        private void Exp1Vib_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        private void Exp1Vib_KeyDown(object sender, KeyEventArgs e)
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

        private void clickAnswer(pattern answer)
        {
            enableButtons(false);
            serialPort1.ReadExisting();
            timeAnswer = DateTime.Now.Ticks;
            long RT = (timeAnswer - timeAsk) / 10000;

            if ((pattern)currPattern == answer)
            {
                tw.WriteLine(stimuliIdx.ToString() + "," + currPattern.ToString() + "," + answer.ToString() + "," + "1" + "," + RT.ToString());
                tw.Flush();
            }
            else
            {
                tw.WriteLine(stimuliIdx.ToString() + "," + currPattern.ToString() + "," + answer.ToString() + "," + "0" + "," + RT.ToString());
                tw.Flush();
            }

            if (stimuliIdx >= 48)
            {
                buttonColorBlack();
                timeEnd = DateTime.Now.Ticks;
                long timeExp = timeEnd - timeStart;
                TimeSpan elapsedTime = new TimeSpan(timeExp);
                Console.WriteLine("timeExp: " + elapsedTime.TotalSeconds);
                twTime.WriteLine(userID + "," + "vib" + "," + spCond[spIdx] + "," + block.ToString() + "," + elapsedTime.TotalSeconds);
                twTime.Flush();
                labelTrial.Text = "Finished!";
                labelWait.Text = "Finished!";
                Delay(2000);
                this.Close();
            }
            else
            {
                Delay(500);
                buttonColorBlack();
                labelTrial.Text = (stimuliIdx + 1).ToString() + "/" + (patternNum * repeatNum).ToString();
                labelWait.Text = "";
                buttonPlay.Enabled = true;
            }
        }

        private void buttonColorBlack()
        {
            buttonUp.BackColor = Color.Black;
            buttonDown.BackColor = Color.Black;
            buttonLeft.BackColor = Color.Black;
            buttonRight.BackColor = Color.Black;
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

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
    public partial class Exp1Main : Form
    {
        enum pattern { up, down, left, right };
        static string[,,] patternCmd = { { {"p4", "p5", "p6" },
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
        static string[,,] patternLineCmd = { { {"p7", "p4", "p1" },
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
        static string[] spCond = { "line", "point", "leftmost", "rightmost" }; // spatial pattern condition
        int[] depthCond = { 1, 2, 3, 4 };   // depth condition
        int patternNum = 4;
        int repeatNum = 12;
        int[] stimuli;
        int depth = 20;
        int duration = 250;
        int pullDuration = 100;
        int patternPositionIdx = 0;
        float pokeSpeed = 0.06f; // mm/ms
        float pullTime;
        pattern currPattern = pattern.up;
        bool ssFlag = false;
        bool lineFlag = false;
        int spIdx = 0;
        int stimuliIdx = 0;
        long timeStart = 0, timeEnd = 0;
        long timeAsk = 0, timeAnswer = 0;
        TextWriter tw, twTime;
        string userID;
        int block = 1;

        public Exp1Main()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            stimuli = new int[patternNum * repeatNum];
            enableButtons(false);
            labelWait.Text = "";
            randomizeStimuli();
        }

        public void setExp1Main(SerialPort port, int pokingDepthIdx, bool sensorySaltation, int spatialPattern, int blockNum, string logID)
        {
            serialPort1 = port;
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
            userID = logID;
            ssFlag = sensorySaltation;
            spIdx = spatialPattern;
            block = blockNum;
            lineFlag = (spatialPattern == 0);
            timerPull.Interval = (int)pullTime;
            timerDuration.Interval = (int)duration;
            timerSS.Interval = (int)(duration / 2);
            Console.WriteLine("Pull: " + pullTime.ToString() + ", Duration: " + duration.ToString());
            if (depth > 3)
            {
                tw = new StreamWriter("Exp2_" + logID + "_Vib_" + blockNum.ToString() + ".csv", true);
                tw.WriteLine("Trial#, Stimuli, Answer, Correct, RT(ms)");
            }
            else
            {
                tw = new StreamWriter("Exp2_" + logID + "_Poke_" + blockNum.ToString() + ".csv", true);
                tw.WriteLine("Trial#, Stimuli, Answer, Correct, RT(ms)");
            }
            tw.Flush();
            twTime = new StreamWriter("Exp1_time.csv", true);
        }

        private void randomizeStimuli()
        {
            Random random = new Random();
            int tmpNum;
            int[] randomIdx = new int[patternNum * repeatNum];
            int[] sampleStimuli = new int[patternNum * repeatNum];
            for(int i=0;i < patternNum * repeatNum;i++)
            {
                randomIdx[i] = -1;
            }
            for (int i = 0;i < patternNum;i++)
            {
                for (int j = 0; j < repeatNum; j++)
                {
                    sampleStimuli[i * repeatNum + j] = i;
                    tmpNum = random.Next(patternNum * repeatNum);
                    while(randomIdx.Contains(tmpNum))
                    {
                        tmpNum = random.Next(patternNum * repeatNum);
                    }
                    randomIdx[i * repeatNum + j] = tmpNum;
                }
            }
            for(int i = 0;i < patternNum * repeatNum; i++)
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
                //Console.Write(patternLineCmd[(int)currPattern, tmpIdx, 0]);
                serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 1]);
                //Console.Write(patternLineCmd[(int)currPattern, tmpIdx, 1]);
                serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 2]);
                //Console.Write(patternLineCmd[(int)currPattern, tmpIdx, 2]);
            }
            else
            {
                serialPort1.WriteLine(patternCmd[(spIdx - 1), (int)currPattern, tmpIdx]);
                //Console.Write(patternLineCmd[(int)currPattern, tmpIdx, tmpIdx]);
            }
            timerPull.Enabled = true;
            timerDuration.Enabled = true;
            if (ssFlag)
            {
                timerSS.Enabled = true;
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if(stimuliIdx == 0)
            {
                timeStart = DateTime.Now.Ticks;
            }
            currPattern = (pattern)stimuli[stimuliIdx++];
            buttonPlay.Enabled = false;
            labelWait.Text = "Playing";
            playPattern();            
        }

        private void timerPull_Tick(object sender, EventArgs e)
        {
            //Console.Write("P");
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
                //Console.Write(patternLineCmd[(int)currPattern, tmpIdx, 0]);
                serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 1]);
                //Console.Write(patternLineCmd[(int)currPattern, tmpIdx, 1]);
                serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 2]);
                //Console.Write(patternLineCmd[(int)currPattern, tmpIdx, 2]);
            }
            else
            {
                serialPort1.WriteLine(patternCmd[(spIdx - 1), (int)currPattern, tmpIdx]);
                //Console.Write(patternLineCmd[(int)currPattern, tmpIdx, tmpIdx]);
            }
            patternPositionIdx++;
            timerPull.Enabled = false;
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

        private void Exp1Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            tw.Close();
            twTime.Close();
        }

        private void timerSS_Tick(object sender, EventArgs e)
        {
            //Console.Write("S");
            int tmpIdx;
            if (ssFlag)
            {
                tmpIdx = patternPositionIdx / 2;
            }
            else
            {
                tmpIdx = patternPositionIdx;
            }
            try
            {
                if (lineFlag)
                {
                    serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 0]);
                    //Console.Write(patternLineCmd[(int)currPattern, tmpIdx, 0]);
                    serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 1]);
                    //Console.Write(patternLineCmd[(int)currPattern, tmpIdx, 1]);
                    serialPort1.WriteLine(patternLineCmd[(int)currPattern, tmpIdx, 2]);
                    //Console.Write(patternLineCmd[(int)currPattern, tmpIdx, 2]);
                }
                else
                {
                    serialPort1.WriteLine(patternCmd[(spIdx - 1), (int)currPattern, tmpIdx]);
                    //Console.Write(patternLineCmd[(int)currPattern, tmpIdx, tmpIdx]);
                }
                
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
            timerPull.Enabled = true;
            timerSS.Enabled = false;
        }

        private void timerDuration_Tick(object sender, EventArgs e)
        {
            //Console.Write("D");
            //Console.WriteLine("patternPositionIdx: " + patternPositionIdx.ToString());
            if ((patternPositionIdx >= 3 && !ssFlag) || (patternPositionIdx >= 6 && ssFlag))
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

        private void clickAnswer(pattern answer)
        {
            enableButtons(false);
            serialPort1.ReadExisting();
            timeAnswer = DateTime.Now.Ticks;
            long RT = (timeAnswer - timeAsk) / 10000;

            if((pattern)currPattern == answer)
            {
                tw.WriteLine(stimuliIdx.ToString() + "," + currPattern.ToString() + "," + answer.ToString() + "," + "1" + "," + RT.ToString());
                tw.Flush();
            }
            else
            {
                tw.WriteLine(stimuliIdx.ToString() + "," + currPattern.ToString() + "," + answer.ToString() + "," + "0" + "," + RT.ToString());
                tw.Flush();
            }

            if(stimuliIdx >= 48)
            {
                buttonColorBlack();
                timeEnd = DateTime.Now.Ticks;
                long timeExp = timeEnd - timeStart;
                TimeSpan elapsedTime = new TimeSpan(timeExp);
                Console.WriteLine("timeExp: " + elapsedTime.TotalSeconds);
                twTime.WriteLine(userID + "," + depth.ToString() + "," + ssFlag.ToString() + "," + spCond[spIdx] + "," + block.ToString() + "," + elapsedTime.TotalSeconds);
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

        private void Exp1Main_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            button_PreviewKeyDown(sender, e);
        }

        private void Exp1Main_KeyDown(object sender, KeyEventArgs e)
        {
            button_KeyDown(sender, e);
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
    }
}

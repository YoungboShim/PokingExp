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
    public partial class SecondaryTask : Form
    {
        enum pattern { up, down, left, right };
        static string[,] pokePatternCmd = { {"p4", "p5", "p6" },
                                           {"p6", "p5", "p4" },
                                           {"p2", "p5", "p8" },
                                           {"p8", "p5", "p2" } };
        static string[,] vibPatternCmd = { {"m7", "m8", "m9" },
                                           {"m9", "m8", "m7" },
                                           {"m2", "m5", "m8" },
                                           {"m8", "m5", "m2" } };
        int patternNum = 4;
        int repeatNum = 5;
        int[] stimuli;
        int[] incount;
        int depth = 3;
        int duration = 250;
        int vibPullDuration = 80;
        int patternPositionIdx = 0;
        int primaryTaskInterval = 5; // sec
        int primaryTaskNum = 60;
        float pokeSpeed = 0.06f; // mm/ms
        float pullTime;
        pattern currPattern = pattern.up;
        bool pokeOn = true; // true: poke, false: vib
        bool answerMode = false;
        int stimuliIdx = 0;
        long timeStart = 0, timeEnd = 0;
        long timeAsk = 0, timeAnswer = 0;
        TextWriter tw, twTime;
        string userID;

        public SecondaryTask()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.LimeGreen;
            this.TransparencyKey = Color.LimeGreen;

            randomizeStimuli();
            randomizeStimuliIncount();
        }

        private void timerRandom_Tick(object sender, EventArgs e)
        {
            stimuliIdx++;
            timerRandomSet();
            answerMode = true;
            playPattern();
        }

        private void SecondaryTask_Load(object sender, EventArgs e)
        {

        }

        public void setSecondaryTask(SerialPort port, bool pokeVib, string logId, int level)
        {
            serialPort1 = port;
            serialPort1.WriteLine("e");
            pullTime = (depth + 0.25f) / pokeSpeed;
            pokeOn = pokeVib;
            userID = logId;
            if(pokeOn)
                timerPull.Interval = (int)pullTime;
            else
                timerPull.Interval = (int)vibPullDuration;
            timerDuration.Interval = (int)duration;
            timerSS.Interval = (int)(duration / 2);
            tw = new StreamWriter("Exp3_" + userID + "_" + level.ToString() + "_" + (pokeOn ? "poke" : "vib") + ".csv");
            tw.WriteLine("Trial#, Stimuli, Answer, Correct, RT(ms), AskTime, AnswerTime");
            tw.Flush();
            timeStart = DateTime.Now.Ticks;
            timerRandomSet();
            timerRandom.Enabled = true;
        }

        private void timerPull_Tick(object sender, EventArgs e)
        {
            int tmpIdx;
            tmpIdx = patternPositionIdx / 2;
            if(pokeOn)
                serialPort1.WriteLine(pokePatternCmd[(int)currPattern, tmpIdx]);
            else
                serialPort1.WriteLine(vibPatternCmd[(int)currPattern, tmpIdx]);
            patternPositionIdx++;
            timerPull.Enabled = false;
        }

        private void timerDuration_Tick(object sender, EventArgs e)
        {
            if (patternPositionIdx >= 6)
            {
                patternPositionIdx = 0;
                timerDuration.Enabled = false;
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
            if(pokeOn)
                serialPort1.WriteLine(pokePatternCmd[(int)currPattern, tmpIdx]);
            else
                serialPort1.WriteLine(vibPatternCmd[(int)currPattern, tmpIdx]);
            timerPull.Enabled = true;

            timerSS.Enabled = false;
        }

        private void SecondaryTask_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

        private void SecondaryTask_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    answerPattern(pattern.up);
                    break;
                case Keys.Down:
                    answerPattern(pattern.down);
                    break;
                case Keys.Left:
                    answerPattern(pattern.left);
                    break;
                case Keys.Right:
                    answerPattern(pattern.right);
                    break;
            }
        }

        private void answerPattern(pattern answer)
        {
            if(answerMode)
            {
                long RT, tAsk, tAnswer;
                answerMode = false;
                timeAnswer = DateTime.Now.Ticks;
                RT = (timeAnswer - timeAsk) / 10000;
                tAsk = (timeAsk - timeStart) / 10000000;
                tAnswer = (timeAnswer - timeStart) / 10000000;

                if ((pattern)currPattern == answer)
                {
                    tw.WriteLine(stimuliIdx.ToString() + "," + currPattern.ToString() + "," + answer.ToString() + "," + "1" + "," + RT.ToString() + "," + tAsk.ToString() + "," + tAnswer.ToString());
                    tw.Flush();
                }
                else
                {
                    tw.WriteLine(stimuliIdx.ToString() + "," + currPattern.ToString() + "," + answer.ToString() + "," + "0" + "," + RT.ToString() + "," + tAsk.ToString() + "," + tAnswer.ToString());
                    tw.Flush();
                }

                if(stimuliIdx + 1 >= repeatNum * patternNum)
                {
                    // Do something for post task
                    this.Close();
                }
            }
        }

        private void SecondaryTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            tw.Flush();
            tw.Close();
        }

        private void randomizeStimuli()
        {
            stimuli = new int[patternNum * repeatNum];

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
            currPattern = (pattern)stimuli[stimuliIdx];
        }

        private void randomizeStimuliIncount()
        {
            incount = new int[patternNum * repeatNum];
            Random randTime = new Random();

            do
            {
                incount[0] = randTime.Next(10, 20);
                for (int i = 0; i < patternNum * repeatNum - 1; i++)
                {
                    incount[i + 1] = incount[i] + randTime.Next(10, 20);
                }
            } while (incount[patternNum * repeatNum - 1] > primaryTaskInterval * primaryTaskNum);
            
        }

        private void timerRandomSet()
        {
            if(answerMode)
            {
                // Do if timeout
                long RT, tAsk, tAnswer;
                answerMode = false;
                timeAnswer = DateTime.Now.Ticks;
                RT = (timeAnswer - timeAsk) / 10000;
                tAsk = (timeAsk - timeStart) / 10000000;
                tAnswer = (timeAnswer - timeStart) / 10000000;

                tw.WriteLine(stimuliIdx.ToString() + "," + currPattern.ToString() + "," + "none" + "," + "1" + "," + RT.ToString() + "," + tAsk.ToString() + "," + tAnswer.ToString());
                tw.Flush();
            }
            if (stimuliIdx == 0)
            {
                timerRandom.Interval = incount[stimuliIdx] * 1000;
                currPattern = (pattern)stimuli[stimuliIdx];
            }
            else if (stimuliIdx >= repeatNum * patternNum)
            {
                timerRandom.Enabled = false;
            }
            else
            {
                timerRandom.Interval = (incount[stimuliIdx] - incount[stimuliIdx - 1]) * 1000;
                currPattern = (pattern)stimuli[stimuliIdx];
            }
        }

        private void playPattern()
        {
            int tmpIdx;
            tmpIdx = patternPositionIdx / 2;
            if(patternPositionIdx == 0)
                timeAsk = DateTime.Now.Ticks;
            
            if(pokeOn)
                serialPort1.WriteLine(pokePatternCmd[(int)currPattern, tmpIdx]);
            else
                serialPort1.WriteLine(vibPatternCmd[(int)currPattern, tmpIdx]);
            timerPull.Enabled = true;

            timerDuration.Enabled = true;
            timerSS.Enabled = true; ;
            serialPort1.ReadExisting();
        }
    }
}

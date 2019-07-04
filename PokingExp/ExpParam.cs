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
    public partial class ExpParam : Form
    {
        enum pattern { up, down, left, right };
        string[] patternString = { "u", "d", "l", "r" };
        int patternNum = 4;
        enum param { norm, cresc, decresc, accel, decel, yleft, yright };
        string[] paramString = { "norm", "cresc", "decresc", "accel", "decel", "yleft", "yright" };
        int paramNum = 7;
        static string[,] patternCmds = new string[7,4] { { "4,0,2;5,125,2;6,250,2;", "6,0,2;5,125,2;4,250,2;", "2,0,2;5,125,2;8,250,2;", "8,0,2;5,125,2;2,250,2;" },
                                                         { "4,0,1.5;5,125,2;6,250,2.5;", "6,0,1.5;5,125,2;4,250,2.5;", "2,0,1.5;5,125,2;8,250,2.5;", "8,0,1.5;5,125,2;2,250,2.5;" },
                                                         { "4,0,2.5;5,125,2;6,250,1.5;", "6,0,2.5;5,125,2;4,250,1.5;", "2,0,2.5;5,125,2;8,250,1.5;", "8,0,2.5;5,125,2;2,250,1.5;" },
                                                         { "4,0,2;5,100,2;6,250,2;", "6,0,2;5,100,2;4,250,2;", "2,0,2;5,100,2;8,250,2;", "8,0,2;5,100,2;2,250,2;" },
                                                         { "4,0,2;5,150,2;6,250,2;", "6,0,2;5,150,2;4,250,2;", "2,0,2;5,150,2;8,250,2;", "8,0,2;5,150,2;2,250,2;" },
                                                         { "4,0,2;5,125,2;9,250,2;", "6,0,2;5,125,2;1,250,2;", "2,0,2;5,125,2;7,250,2;", "8,0,2;5,125,2;3,250,2;" },
                                                         { "4,0,2;5,125,2;3,250,2;", "6,0,2;5,125,2;7,250,2;", "2,0,2;5,125,2;9,250,2;", "8,0,2;5,125,2;1,250,2;" } };
        int repeatNum = 5;
        int[,] randSeq = new int[140, 2];
        int stimuliIdx = 0;
        int currPattern;
        int currParam;
        int maxOnsetDelay = 2000;
        long timeAsk = 0;
        long timeAnswer = 0;

        PokeCmdSend cmdSend;
        TextWriter logWriter;


        public ExpParam()
        {
            InitializeComponent();
        }

        public void initProgram(SerialPort sp, String logId)
        {
            int[] randIdx = new int[140];
            for(int i=0;i<140;i++)
            {
                randIdx[i] = -1;
            }
            for(int i=0;i<140;i++)
            {
                Random rand = new Random();
                int tmp = rand.Next(140);
                while(randIdx.Contains(tmp))
                {
                    tmp = rand.Next(140);
                }
                randIdx[i] = tmp;
            }


            for(int i=0;i<patternNum;i++)
            {
                for(int j=0;j<paramNum;j++)
                {
                    for(int k=0;k<repeatNum;k++)
                    {
                        randSeq[randIdx[i * paramNum * repeatNum + j * repeatNum + k], 0] = i;
                        randSeq[randIdx[i * paramNum * repeatNum + j * repeatNum + k], 1] = j;
                    }
                }
            }

            logWriter = new StreamWriter("ExpParam_" + logId + ".csv", true);
            logWriter.WriteLine("Trial#, Pattern, Answer, Correct, RT(ms), Param");

            cmdSend = new PokeCmdSend(sp);

            buttonUp.Enabled = false;
            buttonDown.Enabled = false;
            buttonLeft.Enabled = false;
            buttonRight.Enabled = false;

            buttonUp.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\up disable.png");
            buttonDown.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\down disable.png");
            buttonLeft.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\left disable.png");
            buttonRight.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\right disable.png");
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            currPattern = randSeq[stimuliIdx, 0];
            currParam = randSeq[stimuliIdx, 1];
            buttonPlay.Enabled = false;
            buttonPlay.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\play disable.png");
            labelGuide.Text = "Playing";
            Random random = new Random();
            Delay(random.Next(maxOnsetDelay));

            cmdSend.playCmd(patternCmds[currParam, currPattern]);
            timeAsk = DateTime.Now.Ticks;
            labelGuide.Text = "Click the answer";
            buttonUp.Enabled = true;
            buttonDown.Enabled = true;
            buttonLeft.Enabled = true;
            buttonRight.Enabled = true;
            buttonUp.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\up arrow.png");
            buttonDown.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\down arrow.png");
            buttonLeft.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\left arrow.png");
            buttonRight.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\right arrow.png");
        }

        private void clickAnswer(pattern ansPattern)
        {
            buttonUp.Enabled = false;
            buttonDown.Enabled = false;
            buttonLeft.Enabled = false;
            buttonRight.Enabled = false;

            buttonUp.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\up disable.png");
            buttonDown.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\down disable.png");
            buttonLeft.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\left disable.png");
            buttonRight.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\right disable.png");

            timeAnswer = DateTime.Now.Ticks;
            long RT = (timeAnswer - timeAsk) / 10000;

            if (currPattern == (int)ansPattern)
            {
                logWriter.WriteLine(stimuliIdx.ToString() + "," + patternString[currPattern] + "," + patternString[(int)ansPattern] + "," + "1" + "," + RT.ToString() + "," + paramString[currParam]);
                logWriter.Flush();
            }
            else
            {
                logWriter.WriteLine(stimuliIdx.ToString() + "," + patternString[currPattern] + "," + patternString[(int)ansPattern] + "," + "0" + "," + RT.ToString() + "," + paramString[currParam]);
                logWriter.Flush();
            }

            if (++stimuliIdx >= 140)
            {
                labelGuide.Text = "Finished!";
                labelOrder.Text = "Finished!";
            }
            else
            {
                Delay(500);
                
                labelOrder.Text = (stimuliIdx + 1).ToString() + " / 140";
                labelGuide.Text = "";
                buttonPlay.Enabled = true;
                buttonPlay.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\play icon.png");
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

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            clickAnswer(pattern.left);
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            clickAnswer(pattern.up);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            clickAnswer(pattern.down);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            clickAnswer(pattern.right);
        }

        private void buttonPlay_MouseEnter(object sender, EventArgs e)
        {
            buttonPlay.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\play hover.png");
        }

        private void buttonPlay_MouseLeave(object sender, EventArgs e)
        {
            if(buttonPlay.Enabled)
                buttonPlay.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\play icon.png");
        }

        private void buttonUp_MouseEnter(object sender, EventArgs e)
        {
            buttonUp.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\up hover.png");
        }

        private void buttonUp_MouseLeave(object sender, EventArgs e)
        {
            if (buttonUp.Enabled)
                buttonUp.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\up arrow.png");
        }

        private void buttonLeft_MouseEnter(object sender, EventArgs e)
        {
            buttonLeft.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\left arrow.png");
        }

        private void buttonLeft_MouseLeave(object sender, EventArgs e)
        {
            if (buttonLeft.Enabled)
                buttonLeft.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\left arrow.png");
        }

        private void buttonRight_MouseEnter(object sender, EventArgs e)
        {
            buttonRight.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\right hover.png");
        }

        private void buttonRight_MouseLeave(object sender, EventArgs e)
        {
            if (buttonRight.Enabled)
                buttonRight.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\right arrow.png");
        }

        private void buttonDown_MouseEnter(object sender, EventArgs e)
        {
            buttonDown.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\down hover.png");
        }

        private void buttonDown_MouseLeave(object sender, EventArgs e)
        {
            if (buttonDown.Enabled)
                buttonDown.BackgroundImage = Image.FromFile(@"D:\workspace\PokingExp\PokingExp\down arrow.png");
        }
    }
}


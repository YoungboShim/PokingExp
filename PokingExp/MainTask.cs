using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokingExp
{
    public partial class MainTask : Form
    {

        private readonly int numSets = 60;
        private readonly int answerNumber = 57;
        private readonly int duration = 5;
        private readonly int padding = 30;
        private readonly int fontSize = 12;

        private int numNumbers;
        private List<bool> answers;
        private int curIdx = 0;
        
        private List<Label> labels;
        
        private int screenWidth = 0;
        private int screenHeight = 0;
        private int gridX = 0;
        private int gridY = 0;

        public MainTask()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            screenWidth = Screen.PrimaryScreen.Bounds.Width;
            screenHeight = Screen.PrimaryScreen.Bounds.Height;

            gridX = (screenWidth - 2*padding) / (fontSize*2);
            gridY = (screenHeight - 2*padding) / (fontSize*2);

            //Start(30, "testLog.txt");

        }

        public void Start(int numNumbers, string logFileName)
        {
            
            PrepareAnswers();
            PrepareLabels(numNumbers);
            this.numNumbers = numNumbers;
            WriteLog(logFileName);
            StartTask(0);
        }

        public void WriteLog(string logFileName)
        {
            string answerStr = string.Join(",", answers.ToArray());
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(logFileName))
            {
                file.WriteLine(answerStr);
            }
        }
        
        private void PrepareAnswers()
        {
            Random rand = new Random();
            answers = new List<bool>();
            for (int i = 0; i < numSets; i++)
            {
                int v = rand.Next(100);
                if (v >= 50)
                {
                    answers.Add(true);
                }
                else
                {
                    answers.Add(false);
                }
            }
        }

        private void PrepareLabels(int numNumbers)
        {
            labels = new List<Label>();
            for(int i=0; i<numNumbers; i++)
            {
                Label l = new Label();
                l.Font = new Font("Arial", fontSize, FontStyle.Regular);
                l.AutoSize = true;
                labels.Add(l);
                this.Controls.Add(l);

            }
        }

        private void ClearLabels()
        {
            
            foreach (Label l in labels)
            {
                l.Text = "";

            }
            
        }

        private void UpdateLabels(List<int> numbers)
        {
            if(numNumbers <= 0)
            {
                return;
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                labels[i].Text = numbers[i].ToString();
            }
            ShuffleLabelsPosition();
        }

        private void ShuffleLabelsPosition()
        {
            Random rand = new Random();
            List<int> gxList = new List<int>();
            List<int> gyList = new List<int>();

            foreach (Label l in labels)
            {
                //int x = rand.Next(padding, screenWidth - padding);
                //int y = rand.Next(padding, screenHeight - padding);
                int gx = rand.Next(gridX);
                int gy = rand.Next(gridY);

                while(gxList.Contains(gx) && gyList.Contains(gy))
                {
                    gx = rand.Next(gridX);
                    gy = rand.Next(gridY);
                    Console.WriteLine("Redraw!");
                }

                gxList.Add(gx);
                gyList.Add(gy);
                
                int x = gridToPoint(gx);
                int y = gridToPoint(gy);

                l.Location = new Point(x, y);
            }

        }

        private int gridToPoint(int val)
        {
            Random rand = new Random();
            int noiseRange = fontSize / 3;
            int noise = rand.Next(noiseRange) - noiseRange / 2;
            return padding + val * fontSize * 2 + noise;
        }

        private void StartTask(int idx)
        {
            bool isAnsTrue = answers[idx];
            List<int> numbers;
            if(isAnsTrue)
            {
                numbers = GenerateRandNumbers(this.numNumbers - 1);
                numbers.Add(answerNumber);
            }
            else
            {
                numbers = GenerateRandNumbers(this.numNumbers);
            }

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateLabels(numbers)));
            }
            else
            {
                UpdateLabels(numbers);
            }


            Task.Delay(duration * 1000).ContinueWith(t => EndTask());
        }

        private void EndTask()
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new Action(() => ClearLabels()));
            }
            else
            {
                ClearLabels();
            }
            
            curIdx++;
            if(curIdx < numSets)
            {
                StartTask(curIdx);
            }
            else
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => this.Hide()));
                }
                else
                {
                    this.Hide(); ;
                }
                
            }
        }

        private List<int> GenerateRandNumbers(int num)
        {
            Random rand = new Random();
            List<int> numbers = new List<int>();
            for(int i = 0; i<num; i++)
            {
                int n = rand.Next(10, 100);
                while(n == answerNumber)
                {
                    n = rand.Next(10, 100);
                }
                numbers.Add(n);
            }
            return numbers;
        }        
    }

    
}

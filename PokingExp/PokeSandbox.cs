using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;


namespace PokingExp
{
    public partial class PokeSandbox : Form
    {
        List<Label> labels = new List<Label>();
        List<ComboBox> numCombos = new List<ComboBox>();
        List<TextBox> onsetInputs = new List<TextBox>();
        List<TextBox> depthInputs = new List<TextBox>();
        List<Button> delBtns = new List<Button>();

        static int nofLab = 5;
        string[] tnumList = new string[]{"1", "2", "3", "4", "5", "6", "7", "8", "9"};

        public PokeSandbox()
        {
            InitializeComponent();

            labels.Add(ControlExtensions.Clone<Label>(label1));
            labels.Add(ControlExtensions.Clone<Label>(label2));
            labels.Add(ControlExtensions.Clone<Label>(label3));
            labels.Add(ControlExtensions.Clone<Label>(label4));
            labels.Add(ControlExtensions.Clone<Label>(label5));

            numCombos.Add(ControlExtensions.Clone<ComboBox>(comboBoxTnum));
            onsetInputs.Add(ControlExtensions.Clone<TextBox>(textBoxOnset));
            depthInputs.Add(ControlExtensions.Clone<TextBox>(textBoxDepth));
            delBtns.Add(ControlExtensions.Clone<Button>(buttonDel));

            for (int i = 0; i < nofLab; i++)
            {
                panel1.Controls.Add(labels[i]);
                //labels[i].Show();
            }
            panel1.Controls.Add(numCombos[0]);
            //numCombos[0].Show();
            numCombos[0].Items.AddRange(tnumList);
            panel1.Controls.Add(onsetInputs[0]);
            //onsetInputs[0].Show();
            panel1.Controls.Add(depthInputs[0]);
            //depthInputs[0].Show();
            panel1.Controls.Add(delBtns[0]);
            //delBtns[0].Show();
            delBtns[0].Click += buttonDel_Click;

            panel1.Controls.Remove(label1);
            panel1.Controls.Remove(label2);
            panel1.Controls.Remove(label3);
            panel1.Controls.Remove(label4);
            panel1.Controls.Remove(label5);
            panel1.Controls.Remove(comboBoxTnum);
            panel1.Controls.Remove(textBoxOnset);
            panel1.Controls.Remove(textBoxDepth);
            panel1.Controls.Remove(buttonDel);

            label1.Dispose();
            label2.Dispose();
            label3.Dispose();
            label4.Dispose();
            label5.Dispose();
            comboBoxTnum.Dispose();
            textBoxOnset.Dispose();
            textBoxDepth.Dispose();
            buttonDel.Dispose();

            renewAll();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            cloneRow();
            int rowIdx = numCombos.Count() - 1;
            
            for(int i = 0; i < nofLab; i++)
            {
                panel1.Controls.Add(labels[rowIdx * nofLab + i]);
            }
            panel1.Controls.Add(numCombos[rowIdx]);
            panel1.Controls.Add(onsetInputs[rowIdx]);
            panel1.Controls.Add(depthInputs[rowIdx]);
            panel1.Controls.Add(delBtns[rowIdx]);

            numCombos[rowIdx].Items.AddRange(tnumList);
            delBtns[rowIdx].Click += buttonDel_Click;
            onsetInputs[rowIdx].Text = "";
            depthInputs[rowIdx].Text = "";

            renewAll();
        }

        private void cloneRow()
        {
            labels.Add(ControlExtensions.Clone<Label>(labels[0]));
            labels.Add(ControlExtensions.Clone<Label>(labels[1]));
            labels.Add(ControlExtensions.Clone<Label>(labels[2]));
            labels.Add(ControlExtensions.Clone<Label>(labels[3]));
            labels.Add(ControlExtensions.Clone<Label>(labels[4]));

            numCombos.Add(ControlExtensions.Clone<ComboBox>(numCombos[0]));
            onsetInputs.Add(ControlExtensions.Clone<TextBox>(onsetInputs[0]));
            depthInputs.Add(ControlExtensions.Clone<TextBox>(depthInputs[0]));
            delBtns.Add(ControlExtensions.Clone<Button>(delBtns[0]));
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            Button tmpBtn = (Button)sender;
            int rowIdx = delBtns.IndexOf(tmpBtn);

            if (delBtns.Count == 1)
                return;
            else
            {
                for (int i = 0; i < nofLab; i++)
                {
                    panel1.Controls.Remove(labels[nofLab * rowIdx]);
                    labels[nofLab * rowIdx].Dispose();
                    labels.RemoveAt(nofLab * rowIdx);
                }
                panel1.Controls.Remove(numCombos[rowIdx]);
                numCombos[rowIdx].Dispose();
                numCombos.RemoveAt(rowIdx);
                panel1.Controls.Remove(onsetInputs[rowIdx]);
                onsetInputs[rowIdx].Dispose();
                onsetInputs.RemoveAt(rowIdx);
                panel1.Controls.Remove(depthInputs[rowIdx]);
                depthInputs[rowIdx].Dispose();
                depthInputs.RemoveAt(rowIdx);
                panel1.Controls.Remove(delBtns[rowIdx]);
                delBtns[rowIdx].Dispose();
                delBtns.RemoveAt(rowIdx);

                renewAll();
            }
        }

        private void renewAll()
        {
            int nofRow = numCombos.Count();
            for(int row = 1;row<nofRow;row++)
            {
                for (int i = 0; i < nofLab; i++)
                {
                    labels[row * nofLab + i].SetBounds(labels[row * nofLab + i].Location.X, labels[(row - 1) * nofLab + i].Location.Y + 50, labels[row * nofLab + i].Width, labels[row * nofLab + i].Height);
                    labels[row * nofLab + i].Show();
                }
                numCombos[row].SetBounds(numCombos[row].Location.X, numCombos[row - 1].Location.Y + 50, numCombos[row].Width, numCombos[row].Height);
                numCombos[row].Show();
                onsetInputs[row].SetBounds(onsetInputs[row].Location.X, onsetInputs[row - 1].Location.Y + 50, onsetInputs[row].Width, onsetInputs[row].Height);
                onsetInputs[row].Show();
                depthInputs[row].SetBounds(depthInputs[row].Location.X, depthInputs[row - 1].Location.Y + 50, depthInputs[row].Width, depthInputs[row].Height);
                depthInputs[row].Show();
                delBtns[row].SetBounds(delBtns[row].Location.X, delBtns[row - 1].Location.Y + 50, delBtns[row].Width, delBtns[row].Height);
                delBtns[row].Show();
            }
            this.Refresh();
        }
    }
}

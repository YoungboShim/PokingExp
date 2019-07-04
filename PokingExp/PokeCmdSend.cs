using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace PokingExp
{
    class PokeCmdSend
    {
        private SerialPort serialPort;
        private double pokeSpeed = 0.04f;   // mm/ms

        public PokeCmdSend(SerialPort port)
        {
            serialPort = port;
        }

        public void playCmd(String cmd)
        {
            String[] cmdRows = cmd.Split(';');
            int nofRow = cmdRows.Length - 1;

            Timer[] onsetTimer = new Timer[nofRow];
            Timer[] pullTimer = new Timer[nofRow];

            int row = 0;
            foreach (String cmdRow in cmdRows)
            {
                if (cmdRow == "") break;
                String[] cmdParam = cmdRow.Split(',');

                int tNum = Int32.Parse(cmdParam[0]) - 1;
                int onset = Convert.ToInt32(cmdParam[1]);
                double depth = Convert.ToDouble(cmdParam[2]);
                if (onset == 0) onset = 1;

                onsetTimer[row] = new Timer();
                onsetTimer[row].Interval = onset;
                onsetTimer[row].Tick += (s, ea) => TimerEventProcessor(s, ea, tNum + 1, depth);
                onsetTimer[row].Enabled = true;

                pullTimer[row] = new Timer();
                pullTimer[row].Interval = onset + Convert.ToInt32(depth / pokeSpeed);
                pullTimer[row].Tick += (s, ea) => TimerEventProcessor(s, ea, tNum + 1, depth);
                pullTimer[row].Enabled = true;

                row++;
            }
        }

        private void TimerEventProcessor(Object sender, EventArgs e, int tNum, double depth)
        {
            int depthCmd = Convert.ToInt32(depth * 10);
            serialPort.WriteLine("d" + depthCmd.ToString());
            Console.WriteLine("d" + depthCmd.ToString());
            serialPort.WriteLine("p" + tNum.ToString());
            Console.WriteLine("p" + tNum.ToString());

            Console.WriteLine(serialPort.ReadExisting());

            ((Timer)sender).Enabled = false;
        }
    }


}

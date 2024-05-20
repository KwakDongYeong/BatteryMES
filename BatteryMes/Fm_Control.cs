using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using ActUtlTypeLib;
using System.Runtime.CompilerServices;

namespace BatteryMes
{
    public partial class Fm_Control : Form
    {
        public ActUtlType plc = new ActUtlType();
        private Timer timer = new Timer();

        private Timer colorTimer;

        private int progressBarValue = 0;
        

        public Fm_Control()
        {
            InitializeComponent();
            plc.ActLogicalStationNumber = 1;
            plc.Open();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            ChargeBattery();
            this.DoubleBuffered = true;
            progressBar1.Maximum = 100;
            progressBar1.Step = 20;

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            ChargeBattery();
        }


        private void ChargeBattery()
        {
            int value;
            plc.GetDevice("M7", out value);
            int timevalue;
            plc.GetDevice("T1", out timevalue);
            int chargevalue;
            plc.GetDevice("M111", out chargevalue);

            if (value == 1)
            {
                progressBar1.Visible = true;
                Pn_pro_1_4.Visible = true;
                colorTimer = new Timer();
                colorTimer.Interval = 3000; // 2초마다 색상 변경
                colorTimer.Tick += ColorTimer_Tick;
                colorTimer.Start();

                if (timevalue >= 1 && timevalue < 60)
                {
                    progressBar1.Value = 20;
                }
                else if (timevalue >= 60 && timevalue < 120)
                {
                    progressBar1.Value = 40;
                }
                else if (timevalue >= 120 && timevalue < 180)
                {
                    progressBar1.Value = 60;
                }
                else if (timevalue >= 180 && timevalue < 240)
                {
                    progressBar1.Value = 80;
                }
                else if (timevalue >= 240 && timevalue < 300)
                {
                    progressBar1.Value = 100;
                }
                else if (chargevalue == 1)
                {
                    progressBar1.ForeColor = Color.Yellow;
                    progressBar1.Value = 100;
                    if (colorTimer != null)
                    {
                        colorTimer.Stop();
                        colorTimer.Dispose();
                        colorTimer = null;
                    }
                }

                else
                {
                    progressBar1.Value = 0;
                }
            }
            else
            {
                Pn_1_4.BackColor = SystemColors.ControlDark;
                progressBar1.Value = 0;
                progressBarValue = 0;
                progressBar1.Visible = false;
                Pn_pro_1_4.Visible = false;

                // PLC가 연결되어 있지 않으면 깜빡임을 중지
                if (colorTimer != null)
                {
                    colorTimer.Stop();
                    colorTimer.Dispose();
                    colorTimer = null; // 타이머 해제
                }
            }
        }



        /* else
         {
             //  panel1.BackColor = (panel1.BackColor == Color.GreenYellow) ? Color.YellowGreen: Color.GreenYellow;
            // panel1.BackColor = (panel1.BackColor == Color.FromArgb(206, 240, 19)) ? Color.FromArgb(230, 241, 10) : Color.FromArgb(206, 240, 19);

         }*/

        private void ColorTimer_Tick(object sender, EventArgs e)
        {
            // 초록색과 노랑색을 2초마다 번갈아가면서 표시
            if (progressBar1.ForeColor == Color.Green)
            {
            //    progressBar1.BackColor = Color.Yellow;
                progressBar1.ForeColor = Color.Yellow;
            }
            else
            {
             //   progressBar1.BackColor = Color.Green;
                progressBar1.ForeColor = Color.Green;
            }
            progressBar1.Refresh(); // 색상 변경 즉시 적용
        }
        private void Fm_Control_Load(object sender, EventArgs e)
        {
           
        }
    
        private void Bt_ProcessOn_Click(object sender, EventArgs e)
        {

        }

        private void Bt_ProcessOff_Click(object sender, EventArgs e)
        {

        }
        private void Fm_Controls_Closing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            plc.Close();
            colorTimer.Stop();
            colorTimer.Dispose();
        }

    }
}

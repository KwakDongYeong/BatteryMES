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
        
        public Fm_Control()
        {
            InitializeComponent();
            plc.ActLogicalStationNumber = 1;
            plc.Open();
            timer.Interval = 900;
            timer.Tick += Timer_Tick;
            timer.Start();

            ChargeBattery();
            this.DoubleBuffered = true;

            int Temvalue;
            plc.GetDevice("D1513", out Temvalue);
            Tb_CurTem.Text = Temvalue.ToString();



        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            ChargeBattery();
            
        }


        private void ChargeBattery()
        {
            /* int senvalue;
             plc.GetDevice("X10", out senvalue); //센서 신호 
             int timevalue; //충전시간
             plc.GetDevice("T1", out timevalue);
             int chargevalue;
             plc.GetDevice("M200", out chargevalue); //충전완료 신호

             if (senvalue == 1)
             {
                 Bar_1_1.Visible = true;
                 Bar_1_1.BackColor = SystemColors.Control;

                 if (timevalue > 0 && timevalue < 300)
                 {
                     Bar_1_1.ForeColor = (Bar_1_1.ForeColor == Color.FromArgb(206, 240, 19)) ? Color.FromArgb(230, 220, 10) : Color.FromArgb(206, 240, 19);

                     if (timevalue >= 1 && timevalue < 60)
                     {
                         Bar_1_1.Value = 20;
                     }
                     else if (timevalue >= 60 && timevalue < 120)
                     {
                         Bar_1_1.Value = 40;
                     }
                     else if (timevalue >= 120 && timevalue < 180)
                     {
                         Bar_1_1.Value = 60;
                     }
                     else if (timevalue >= 180 && timevalue < 240)
                     {
                         Bar_1_1.Value = 80;
                     }
                     else if (timevalue >= 240 && timevalue < 300)
                     {
                         Bar_1_1.Value = 100;
                     }
                 }
                 else if (chargevalue == 1)
                 {
                     Bar_1_1.ForeColor = Color.FromArgb(230, 220, 10);
                     Bar_1_1.Value = 100;
                 }

                 else
                 {
                     Bar_1_1.Value = 0;
                 }
             }
             else
             {
                 Pn_1_1.BackColor = SystemColors.ControlDark;
                 Bar_1_1.Value = 0;
                 Bar_1_1.Visible = false;
             }*/
            for (int i = 0; i < 16; i++)
            {
                int senvalue;
                int timevalue;
                int chargevalue;

                string senDevice;
                if (i < 10)
                {
                    senDevice = $"X{10 + i}";
                }
                else
                {
                    senDevice = $"X1{(char)('A' + (i - 10))}";
                }

                string timeDevice = $"T{i + 1}";
                string chargeDevice = $"M{200 + i}";

                // PLC 디바이스 값 가져오기
                plc.GetDevice(senDevice, out senvalue);
                plc.GetDevice(timeDevice, out timevalue);
                plc.GetDevice(chargeDevice, out chargevalue);

                // 각 ProgressBar와 Panel 이름 설정
                ProgressBar bar = Controls.Find($"Bar_{(i / 4) + 1}_{(i % 4) + 1}", true).FirstOrDefault() as ProgressBar;
                Panel panel = Controls.Find($"Pn_{(i / 4) + 1}_{(i % 4) + 1}", true).FirstOrDefault() as Panel;

                // ProgressBar와 Panel 업데이트
                UpdateProgressBarAndPanel(senvalue, timevalue, chargevalue, bar, panel);
            }


        }

        private void UpdateProgressBarAndPanel(int senvalue, int timevalue, int chargevalue, ProgressBar bar, Panel panel)
        {
            if (senvalue == 1)
            {
                panel.BackColor = SystemColors.Control;
                bar.Visible = true;
                bar.BackColor = SystemColors.Control;
                

                if (timevalue > 0 && timevalue < 300)
                {
                    bar.ForeColor = (bar.ForeColor == Color.FromArgb(206, 240, 19)) ? Color.FromArgb(230, 220, 10) : Color.FromArgb(206, 240, 19);

                    if (timevalue >= 1 && timevalue < 60)
                    {
                        bar.Value = 20;
                    }
                    else if (timevalue >= 60 && timevalue < 120)
                    {
                        bar.Value = 40;
                    }
                    else if (timevalue >= 120 && timevalue < 180)
                    {
                        bar.Value = 60;
                    }
                    else if (timevalue >= 180 && timevalue < 240)
                    {
                        bar.Value = 80;
                    }
                    else if (timevalue >= 240 && timevalue < 300)
                    {
                        bar.Value = 100;
                    }
                }
                else if (chargevalue == 1)
                {
                    bar.ForeColor = Color.FromArgb(230, 225, 8);
                    bar.Value = 100;
                }
                else
                {
                    bar.Value = 0;
                }
            }
            else
            {
                panel.BackColor = SystemColors.ControlDark;
                bar.Value = 0;
                bar.Visible = false;
            }
        }



        private void Fm_Control_Load(object sender, EventArgs e)
        {
           
        }
    
        private void Bt_ProcessOn_Click(object sender, EventArgs e)
        {
            
            plc.SetDevice("X8", 1);
        }

        private void Bt_ProcessOff_Click(object sender, EventArgs e)
        {

        }
        private void Fm_Controls_Closing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            plc.Close();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Bt_RackOn_Click(object sender, EventArgs e)
        {

        }

        private void Bt_SetTem_Click(object sender, EventArgs e)
        {
            int value;

            // 텍스트박스에서 입력된 값이 숫자인지 확인
            if (int.TryParse(Tb_SetTem.Text, out value))
            {
                // 입력된 값에 10을 곱함
                value *= 10;

                // PLC 장치에 값 설정
                plc.SetDevice("D1613", value);
                plc.SetDevice("D1614.0", 1);
            }
            else
            {
                // 숫자가 아닌 경우 사용자에게 알림 (예: 메시지 박스)
                MessageBox.Show("유효한 숫자를 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bt_RackOff_Click(object sender, EventArgs e)
        {

        }
    }
}

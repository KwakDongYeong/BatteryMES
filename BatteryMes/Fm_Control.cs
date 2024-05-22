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
using Google.Protobuf.WellKnownTypes;

namespace BatteryMes
{
    public partial class Fm_Control : Form
    {
        public ActUtlType plc = new ActUtlType();
        private Timer timer = new Timer();
        int Plc_on_value;
        int Pc_on_value;
        
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

            int Temvalue; //현재 온도 값 받아오기
            plc.GetDevice("D1513", out Temvalue);
            Tb_CurTem.Text = Temvalue.ToString();


        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            ChargeBattery();
            CurrentRack();


        }
        private void CurrentRack()
        {

            int gg;
            plc.GetDevice("D1600", out gg);
            textBox1.Text = gg.ToString();


            /*    for (int i = 0; i < 32; i++)
                {
                    string RackDevice;
                    if (i < 16)
                    {
                        if (i < 10)
                        {
                            RackDevice = $"D1600.{i}";
                        }
                        else
                        {
                            RackDevice = $"D1600.{(char)('A' + (i - 10))}";
                        }
                    }
                    else
                    {
                        int newI = i - 16;
                        if (newI < 10)
                        {
                            RackDevice = $"D1601.{newI}";
                        }
                        else
                        {
                            RackDevice = $"D1601.{(char)('A' + (newI - 10))}";
                        }
                    }

                    if (value == 1)
                    {
                        string 연 = $"{(i / 8) + 1}연";
                        string 단 = $"{(i % 4) + 1}단";
                        string 상태 = (i < 16) ? "투입" : "배출";

                        Lb_Rack.Text = $"{연} {단} {상태}";
                    }
                }*/
            // Lb_Rack.Text에 텍스트 누적
            Lb_Rack.Text = ""; // 초기화

            for (int i = 0; i < 32; i++)
            {
                string RackDevice;
                // RackDevice 값에 따라 다른 텍스트 할당
                if (i < 16)
                {
                    if (i < 10)
                    {
                        RackDevice = $"D1600.{i}";
                    }
                    else
                    {
                        RackDevice = $"D1600.{(char)('A' + (i - 10))}";
                    }
                }
                else
                {
                    int newI = i - 16;
                    if (newI < 10)
                    {
                        RackDevice = $"D1601.{newI}";
                    }
                    else
                    {
                        RackDevice = $"D1601.{(char)('A' + (newI - 10))}";
                    }
                }

                // plc.getdevice를 호출하여 value 값 획득
                int value;
                plc.GetDevice(RackDevice, out value);

                // value 값에 따라 다른 텍스트 할당
                string textToDisplay = "";
                if (value == 1)
                {
                    // RackDevice가 D1601.x 일 때
                    if (RackDevice.StartsWith("D1601"))
                    {
                        // D1601.x 에 따라 다른 텍스트 할당
                        int x = int.Parse(RackDevice.Split('.')[1]);
                        textToDisplay = $"1연 {x + 1}단 배출";
                    }
                    else
                    {
                        // M1600.x 에 따라 다른 텍스트 할당
                        int x = int.Parse(RackDevice.Split('.')[1]);
                        int row = x / 4 + 1;
                        int col = x % 4 + 1;
                        textToDisplay = $"{row}연 {col}단 투입";
                    }

                    // 이전 값과 함께 현재 값 추가
                    Lb_Rack.Text += $"{textToDisplay}\n";
                }
                else
                {
                    // value가 1이 아닌 경우, 다른 처리를 할 수 있습니다.
                    
                    
                }
            }



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
         /*   for (int i = 0; i < 16; i++)
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
            }*/

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
            //  plc.SetDevice("M1600", 1);
            //int m1540;
            /* plc.GetDevice("M1540", out m1540);
             if(m1540 == 1)
             {
                 plc.SetDevice("M1600", 0);
             }*/
            int value;
            plc.GetDevice("M1540", out value);
            if(value == 0)
            {
                plc.SetDevice("M1600", 1);


            }
            else if(value == 1)
            {
                plc.SetDevice("M1600", 0);
            }
            


        }

        private void Bt_SetTem_Click(object sender, EventArgs e)
        {
            int value;

            if (int.TryParse(Tb_SetTem.Text, out value))
            {
                value *= 10;
                plc.SetDevice("D1613", value);
                plc.SetDevice("D1614.0", 1);
                MessageBox.Show("설정 완료", "온도 설정", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("유효한 숫자를 입력해주세요.", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bt_RackOff_Click(object sender, EventArgs e)
        {

        }

        private void Bt_Bt_ConnectOn_Click(object sender, EventArgs e)
        {
            plc.GetDevice("M1001", out Plc_on_value);
            plc.GetDevice("M1002", out Pc_on_value);
            if (Plc_on_value == 1)
            {
                DialogResult msgresult = MessageBox.Show("PLC와 통신 하시겠습니까?", "연결 확인", MessageBoxButtons.YesNo);
                if (msgresult == DialogResult.Yes)
                {
                    plc.SetDevice("M1002", 1);
                    Bt_ConnectOn.BackColor = Color.Red;
                }
            }
            else if (Plc_on_value == 0)
            {
                MessageBox.Show("PLC 통신 요청을 확인하세요", "통신 확인", MessageBoxButtons.OK);
            }
            else if (Pc_on_value == 1)
            {
                MessageBox.Show("이미 통신 중입니다.", "연결", MessageBoxButtons.OK);
            }
        }

        private void Bt_ConnectOff_Click(object sender, EventArgs e)
        {
            plc.GetDevice("M1002", out Pc_on_value);
            if (Pc_on_value == 1)
            {
                DialogResult pcmsg = MessageBox.Show("연결을 종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo);
                if (pcmsg == DialogResult.Yes)
                {
                    plc.SetDevice("M1002", 0);
                    Bt_ConnectOn.BackColor = SystemColors.Control;
                }
            }
        }
    }
}

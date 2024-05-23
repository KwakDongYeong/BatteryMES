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
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using System.Threading;

namespace BatteryMes
{
    public partial class Fm_Control : Form
    {
        public ActUtlType plc = new ActUtlType();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        static Random random = new Random();
        static object lockObject = new object();
        static AutoResetEvent stopSignal = new AutoResetEvent(false);
        static bool isWorking = false;

        int Plc_on_value;
        int Pc_on_value;

      
        public Fm_Control()
        {
            InitializeComponent();
            plc.ActLogicalStationNumber = 2;
            plc.Open();

            timer.Interval = 700;
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

            int Temvalue;
            plc.GetDevice("D1600", out Temvalue);
            textBox1.Text = Temvalue.ToString();


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

                int value;
                plc.GetDevice(RackDevice, out value);

                string textToDisplay = "";
                if (value == 1)
                {
                    if (RackDevice.StartsWith("D1601"))
                    {
                        string[] parts = RackDevice.Split('.');
                        if (parts.Length == 2)
                        {
                            int row;
                            int col;
                            int x;
                            if (int.TryParse(parts[1], out x))
                            {
                                // 10진수로 해석하여 연과 단을 계산합니다.
                                row = (x / 4) + 1;
                                col = (x % 4) + 1;
                                textToDisplay = $"{row}연 {col}단 배출";
                            }
                            else
                            {
                                // 16진수로 변환하여 다시 시도합니다.
                                if (int.TryParse(parts[1], System.Globalization.NumberStyles.HexNumber, null, out x))
                                {
                                    row = (x / 4) + 1;
                                    col = (x % 4) + 1;
                                    textToDisplay = $"{row}연 {col}단 투입";
                                }
                                else
                                {
                                    textToDisplay = "유효하지 않은 RackDevice 값입니다.";
                                }
                            }
                        }
                        else
                        {
                            textToDisplay = "유효하지 않은 RackDevice 값입니다.";
                        }
                    }
                    else
                    {/*
                        int x = int.Parse(RackDevice.Split('.')[1]);
                        int row = (x / 4) + 1;  
                        int col = (x % 4) + 1;  
                        textToDisplay = $"{row}연 {col}단 투입";
                        */
                        string[] parts = RackDevice.Split('.');
                        if (parts.Length == 2)
                        {
                            int row;
                            int col;

                            int x;
                            if (int.TryParse(parts[1], out x))
                            {
                                row = (x / 4) + 1;
                                col = (x % 4) + 1;
                                textToDisplay = $"{row}연 {col}단 투입";
                            }
                            else
                            {
                                // 16진수로 변환하여 다시 시도합니다.
                                if (int.TryParse(parts[1], System.Globalization.NumberStyles.HexNumber, null, out x))
                                {
                                    row = (x / 4) + 1;
                                    col = (x % 4) + 1;
                                    textToDisplay = $"{row}연 {col}단 투입";
                                }
                                else
                                {
                                    textToDisplay = "유효하지 않은 RackDevice 값입니다.";
                                }
                            }
                        }
                        else
                        {
                            textToDisplay = "유효하지 않은 RackDevice 값입니다.";
                        }
                    }

                    Lb_Rack.Text += $"{textToDisplay}\n";
                }
                else
                {
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

      /*  private void UpdateProgressBarAndPanel(int senvalue, int timevalue, int chargevalue, ProgressBar bar, Panel panel)
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
        }*/



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
            Thread inputThread = new Thread(InputTask);
            inputThread.Start();

            // 창고에서 배출하는 스레드 시작
            Thread outputThread = new Thread(OutputTask);
            outputThread.Start();

        }
        void InputTask()
        {
            while (!stopSignal.WaitOne(0)) // 정지 신호가 보내질 때까지 반복
            {
                int inputEnd;
                plc.GetDevice("M1529", out inputEnd);
                if (inputEnd != 1) // 센서 신호가 1이 아니면 작업 불가
                {
                    Thread.Sleep(1000);
                    continue;
                }

                int startWarehouse = 1540; // 시작 창고 번호
                int endWarehouse = 1555; // 끝 창고 번호
                int inputStartWarehouse = 1600; // 투입 작업 시작 창고 번호
                int inputEndWarehouse = 1615; // 투입 작업 끝 창고 번호
                int currentWarehouse = startWarehouse; // 현재 작업 중인 창고 번호 초기화

                while (currentWarehouse <= endWarehouse) // 시작 창고부터 끝 창고까지 반복
                {
                    int warehouseValue;
                    plc.GetDevice($"M{currentWarehouse}", out warehouseValue);

                    if (warehouseValue == 1) // 창고에 물건이 있으면 다음 창고로 넘어감
                    {
                        currentWarehouse++;
                        continue;
                    }

                    if (warehouseValue == 0)
                    {
                        string warehouseSensor = $"M{currentWarehouse}"; // 해당 창고의 센서 디바이스 변수에 저장

                        int inputSignal = currentWarehouse + (inputStartWarehouse - startWarehouse);
                        if (inputSignal >= inputStartWarehouse && inputSignal <= inputEndWarehouse)
                        {
                            // 해당 창고에 투입 신호를 설정합니다.
                            plc.SetDevice($"M{inputSignal}", 1);
                        }

                        isWorking = true; // 작업 중임을 표시
                        break; // 작업 시작 후 루프 종료
                    }
                }
                if (isWorking)
                {
                    int m1576Value;
                    do
                    {
                        Thread.Sleep(1000);
                        plc.GetDevice("M1576", out m1576Value);
                    } while (m1576Value != 1); // M1576이 1이 될 때까지 반복

                    plc.SetDevice($"M{inputStartWarehouse}", 0); // 해당 창고에 물건을 넣는 작업 완료
                    isWorking = false; // 작업 완료를 표시
                }
            }
        }

        void OutputTask()
        {
            while (!stopSignal.WaitOne(0))
            {
                // 충전 완료 신호를 확인하여 배출 가능 여부 판단
                bool canDischarge = false;
                int chargeCompleteSignal = 0;

                for (int i = 1500; i <= 1515; i++)
                {
                    plc.GetDevice($"M{i}", out chargeCompleteSignal);

                    if (chargeCompleteSignal == 1)
                    {
                        canDischarge = true;
                        break;
                    }
                }

                if (!canDischarge)
                {
                    Thread.Sleep(1000); // 충전 완료 신호를 기다림
                    continue;
                }

                int dischargeWarehouse = 1617 + (chargeCompleteSignal - 1500);
                int dischargeSignal;
                plc.GetDevice($"M{dischargeWarehouse}", out dischargeSignal);

                if (dischargeSignal == 0)
                {
                    // 해당 창고의 배출 신호를 켬
                    plc.SetDevice($"M{dischargeWarehouse}", 1);

                    // 배출 작업 완료를 기다림
                    int dischargeCompleteSignal;
                    do
                    {
                        Thread.Sleep(1000);
                        plc.GetDevice("M1577", out dischargeCompleteSignal);
                    } while (dischargeCompleteSignal != 1); // M1577이 1이 될 때까지 반복

                    // 해당 창고의 배출 신호를 끔
                    plc.SetDevice($"M{dischargeWarehouse}", 0);
                }
            }
        }



        private void Bt_RackOff_Click(object sender, EventArgs e)
        {
            stopSignal.Set();
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

        private void Lb_Rack_Click(object sender, EventArgs e)
        {

        }
    }
}

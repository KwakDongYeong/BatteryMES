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

        private bool isWorking = false;
        private AutoResetEvent stopSignal = new AutoResetEvent(false);
        private Random random = new Random();
        private object lockObject = new object();
        private Thread taskThread;

        int Plc_on_value;
        int Pc_on_value;

      
        public Fm_Control()
        {
            InitializeComponent();
            plc.ActLogicalStationNumber = 0;
            plc.Open();

            timer.Interval = 700;
            timer.Tick += Timer_Tick;
            timer.Start();

            ChargeBattery();
            this.DoubleBuffered = true;

            int Temvalue; //현재 온도 값 받아오기
            plc.GetDevice("D1513", out Temvalue);
            Tb_CurTem.Text = Temvalue.ToString();

            plc.GetDevice("M1002", out Pc_on_value);
            if (Pc_on_value == 1)
            {
                Bt_ConnectOn.BackColor = Color.Red;
            }
            else
            {
                Bt_ConnectOn.BackColor = SystemColors.Control;
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            ChargeBattery();
            CurrentRack();
        }
        private void CurrentRack()
        {
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
          
            Lb_Rack.Text = "";
            for (int i = 0; i < 32; i++)
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
                                row = (x / 4) + 1;
                                col = (x % 4) + 1;
                                textToDisplay = $"{row}연 {col}단 배출";
                            }
                            else
                            {
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
                    {
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
            if (taskThread == null || !taskThread.IsAlive)
            {
                stopSignal.Reset(); // 이전 작업이 완료되었을 때만 새 작업
                taskThread = new Thread(TaskRunner);
                taskThread.Start();
            }
        }
        void TaskRunner()
        {
            while (true)
            {
                if (stopSignal.WaitOne(0))
                {
                    break; // 루프를 종료
                }

                int randomNumber = random.Next(2);

                if (randomNumber == 0)
                {
                    InputTask();
                }
                else
                {
                    OutputTask();
                }

                Thread.Sleep(500); // 작업 간 잠깐 대기 시간
            }
        }

        void InputTask()
        {
            lock (lockObject)
            {
                if (isWorking) return;
                isWorking = true;
                Console.WriteLine("인풋 신호 시작");
            }

            try
            {
                int inputEnd;
                plc.GetDevice("M1529", out inputEnd);
                if (inputEnd != 1)
                {
                    Console.WriteLine("InputTask: Input end signal not received.");
                    Thread.Sleep(500);
                    return;
                }

                int startWarehouse = 1540;
                int endWarehouse = 1555;
                int inputStartWarehouse = 1600;
                int inputEndWarehouse = 1615;
                int currentWarehouse = startWarehouse;

                while (currentWarehouse <= endWarehouse)
                {
                    int warehouseValue;
                    plc.GetDevice($"M{currentWarehouse}", out warehouseValue);
                    Console.WriteLine($"InputTask: Warehouse M{currentWarehouse} value: {warehouseValue}");

                    if (warehouseValue == 1)
                    {
                        currentWarehouse++;
                        continue;
                    }

                    if (warehouseValue == 0)
                    {
                        int inputSignal = currentWarehouse + (inputStartWarehouse - startWarehouse);
                        if (inputSignal >= inputStartWarehouse && inputSignal <= inputEndWarehouse)
                        {
                            Console.WriteLine($"InputTask: Setting device {inputSignal} to 1");
                            plc.SetDevice($"M{inputSignal}", 1);
                            Thread.Sleep(1000);
                            plc.SetDevice($"M{inputSignal}", 0);
                            Console.WriteLine($"InputTask: Setting device {inputSignal} to 0");
                        }
                        break;
                    }
                }

                int m1576Value;
                do
                {
                    Thread.Sleep(1000);
                    plc.GetDevice("M1576", out m1576Value);
                    Console.WriteLine($"InputTask: Device M1576 value: {m1576Value}");
                } while (m1576Value != 1);

                plc.SetDevice($"M{inputStartWarehouse}", 0);
                Console.WriteLine($"InputTask: Setting device {inputStartWarehouse} to 0");
            }
            finally
            {
                lock (lockObject)
                {
                    isWorking = false;
                    Console.WriteLine("InputTask: Finished.");
                }
            }
        }

        void OutputTask()
        {
            lock (lockObject)
            {
                if (isWorking) return;
                isWorking = true;

            }

            try
            {
                int m1578Value;
                plc.GetDevice("M1578", out m1578Value);
                if (m1578Value != 1)
                {
                    Console.WriteLine("OutputTask: M1578 is not 1. Exiting.");
                    return;
                }


                bool canDischarge = false;
                int dischargeWarehouse = 0;
                Console.WriteLine("아웃풋 신호 시작");

                for (int i = 1500; i <= 1515; i++)
                {
                    int chargeCompleteSignal;
                    plc.GetDevice($"M{i}", out chargeCompleteSignal);
                    Console.WriteLine($"OutputTask: Charge complete signal M{i} value: {chargeCompleteSignal}");

                    if (chargeCompleteSignal == 1)
                    {
                        canDischarge = true;
                        dischargeWarehouse = 1616 + (i - 1500); 
                        break;
                    }
                }
                
                if (!canDischarge)
                {
                    Console.WriteLine("OutputTask: Cannot discharge yet. Waiting...");
                    Thread.Sleep(1000);
                    return;
                }

                int dischargeSignal;
                plc.GetDevice($"M{dischargeWarehouse}", out dischargeSignal);
                Console.WriteLine($"OutputTask: Discharge signal M{dischargeWarehouse} value: {dischargeSignal}");

                if (dischargeSignal == 0)
                {
                    Console.WriteLine($"OutputTask: Setting device M{dischargeWarehouse} to 1");
                    plc.SetDevice($"M{dischargeWarehouse}", 1);
                    Thread.Sleep(1000);
                    plc.SetDevice($"M{dischargeWarehouse}", 0);
                    Console.WriteLine($"OutputTask: Setting device M{dischargeWarehouse} to 0");

                    int dischargeCompleteSignal;
                    do
                    {
                        Thread.Sleep(1000);
                        plc.GetDevice("M1577", out dischargeCompleteSignal);
                        Console.WriteLine($"OutputTask: Discharge complete signal M1577 value: {dischargeCompleteSignal}");
                    } while (dischargeCompleteSignal != 1);

                    plc.SetDevice($"M{dischargeWarehouse}", 0);
                    Console.WriteLine($"OutputTask: Setting device M{dischargeWarehouse} to 0");
                }
            }
            finally
            {
                lock (lockObject)
                {
                    isWorking = false;
                    Console.WriteLine("OutputTask: Finished.");
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
              //  value *= 10;
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

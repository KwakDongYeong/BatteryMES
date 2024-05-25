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
using System.Collections.Concurrent;

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
        private Dictionary<string, Panel> panelCache = new Dictionary<string, Panel>();
        private Dictionary<string, Panel> chargepanel = new Dictionary<string, Panel>();


        public Fm_Control()
        {
            InitializeComponent();
            plc.ActLogicalStationNumber = 0;
            plc.Open();
            int result;
                if((result = plc.Open()) != 0)
                {
                Console.WriteLine("plc 연결완");
                  }

            timer.Interval = 500;
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
        }

        private void ChargeBattery()
        {
            if (panelCache.Count == 0)
            {
                for (int i = 1540; i <= 1555; i++)
                {
                    string panelName = $"Pn_{((i - 1540) / 4) + 1}_{((i - 1540) % 4) + 1}";
                    Panel panel = Controls.Find(panelName, true).FirstOrDefault() as Panel;
                    if (panel != null)
                    {
                        panelCache[panelName] = panel;
                    }
                }
            }
            if (chargepanel.Count == 0)
            {
                for (int i = 1540; i <= 1555; i++)
                {
                    string overlayPanelName = $"Pn_Sen_{((i - 1540) / 4) + 1}_{((i - 1540) % 4) + 1}";
                    Panel overlayPanel = Controls.Find(overlayPanelName, true).FirstOrDefault() as Panel;
                    if (overlayPanel != null)
                    {
                        chargepanel[overlayPanelName] = overlayPanel;
                    }
                }
            }

            for (int i = 1540; i <= 1555; i++)
            {
                int senvalue;
                int chargevalue;

                string sendevice = $"M{i}";
                string chargedevice = $"M{i - 40}";
                plc.GetDevice(sendevice, out senvalue);
                plc.GetDevice(chargedevice, out chargevalue);
                string panelName = $"Pn_{((i - 1540) / 4) + 1}_{((i - 1540) % 4) + 1}";
                string overlayPanelName = $"Pn_Sen_{((i - 1540) / 4) + 1}_{((i - 1540) % 4) + 1}";

                if (panelCache.TryGetValue(panelName, out Panel panel))
                {
                    if (senvalue == 1)
                    {
                        UpdatePanel(panel, SystemColors.Control, Properties.Resources.battery);
                    }
                    else
                    {
                        UpdatePanel(panel, SystemColors.ControlDark, null);
                    }
                }

                if (chargepanel.TryGetValue(overlayPanelName, out Panel overlayPanel))
                {
                    if (senvalue == 1)
                    {
                        Color backColor = (overlayPanel.BackColor == Color.Green) ? Color.Yellow : Color.Green;
                        overlayPanel.BackColor = backColor;
                        overlayPanel.Visible = true;
                    }
                    else
                    {
                        overlayPanel.Visible = false;
                    }

                    // M1500부터 M1515까지의 신호가 모두 1이면 충전 완료로 판단하여 패널의 색을 빨간색으로 변경
                  
                    for (int j = 1500; j <= 1515; j++)
                    {
                        string completeSignalDevice = $"M{j}";
                        int completeSignal;
                        plc.GetDevice(completeSignalDevice, out completeSignal);
                        if (completeSignal == 1)
                        {
                            string panelName1 = $"Pn_Sen_{((j - 1500) / 4) + 1}_{((j - 1500) % 4) + 1}";
                            if (chargepanel.TryGetValue(panelName1, out Panel completePanel))
                            {
                                completePanel.BackColor = Color.Red;
                            }
                        }
                    }

                }
            }
        }

        private void UpdatePanel(Panel panel, Color backColor, Image backgroundImage)
        {
            panel.BackColor = backColor;
            panel.BackgroundImage = backgroundImage;
        }



        private void Fm_Control_Load(object sender, EventArgs e)
        {
           
        }
        private void Fm_Controls_Closing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            plc.Close();
            stopSignal.Set();
            taskThread?.Join();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        private async void Bt_RackOn_Click(object sender, EventArgs e)
        {
            if (taskThread == null || !taskThread.IsAlive)
            {
                stopSignal.Reset();
                await Task.Run(TaskRunner);
            }
        }

        private async Task TaskRunner()
        {
            while (true)
            {
                if (stopSignal.WaitOne(0))
                {
                    break;
                }
                int m1529Value;
                int m1585Value;

                plc.GetDevice("M1529", out m1529Value);
                plc.GetDevice("M1585", out m1585Value);

                if (m1529Value == 1 && m1585Value == 1)
                {
                    Random random = new Random();
                    int randomNumber = random.Next(2);

                    if (randomNumber == 0)
                    {
                        await InputTask();
                    }
                    else
                    {
                        await OutputTask();
                    }
                }
                else if (m1529Value == 1)
                {
                    await InputTask();
                }
                else if (m1585Value == 1)
                {
                    await OutputTask();
                }
                await Task.Delay(500);
            }
        }

        private async Task InputTask()
        {
            await Task.Run(() =>
            {
                lock (lockObject)
                {
                    if (isWorking) return;
                    isWorking = true;
                    Console.WriteLine("인풋 신호 시작");
                }
                int inputEnd;
                plc.GetDevice("M1529", out inputEnd);
                Console.WriteLine("get.");
                if (inputEnd != 1)
                {
                    Console.WriteLine("InputTask: Input end signal not received.");
                    Thread.Sleep(500);
                    return;
                }
                try
                {
                    int startWarehouse = 1540; //창고 센서 1번째 어드레스
                    int endWarehouse = 1555;  //창고 16번 어드레스
                    int inputStartWarehouse = 1600;  // 수납 1번 어드레스
                    int inputEndWarehouse = 1615; //수납 16번 어드레스

                    Dictionary<string, int> warehouseValues = new Dictionary<string, int>();
                    for (int i = startWarehouse; i <= endWarehouse; i++)
                    {
                        int value;
                        plc.GetDevice($"M{i}", out value);
                        warehouseValues[$"M{i}"] = value;
                    }

                    // 작업할 Warehouse를 랜덤하게 선택하여 작업 수행
                    int[] warehouseIndexes = Enumerable.Range(startWarehouse, endWarehouse - startWarehouse + 1).ToArray();
                    Shuffle(warehouseIndexes); // 배열을 섞는 함수를 호출하여 랜덤한 순서로 작업할 Warehouse를 선택

                    foreach (int i in warehouseIndexes)
                    {
                        int warehouseValue = warehouseValues[$"M{i}"];
                        Console.WriteLine($"투입 창고 빈칸 M{i} value: {warehouseValue}");

                        if (warehouseValue == 0)
                        {
                            int inputSignal = i + (inputStartWarehouse - startWarehouse);
                            if (inputSignal >= inputStartWarehouse && inputSignal <= inputEndWarehouse)
                            {
                                string rackText = GetRackText(inputSignal);
                                Console.WriteLine($"InputTask: Setting device {inputSignal} to 1");
                                plc.SetDevice($"M{inputSignal}", 1);
                                UpdateLabel(Lb_Rack, rackText);
                                Thread.Sleep(2500);
                                plc.SetDevice($"M{inputSignal}", 0);
                                Console.WriteLine($"InputTask: Setting device {inputSignal} to 0");
                                Thread.Sleep(7000);
                            }
                            break;
                        }
                    }

                    int m1576Value;
                    DateTime startTime = DateTime.Now;
                    do
                    {
                        if (stopSignal.WaitOne(0)) // 종료 신호를 확인
                        {
                            Console.WriteLine("InputTask: Stopped.");
                            return;
                        }
                        Thread.Sleep(700);
                        plc.GetDevice("M1576", out m1576Value);
                        Console.WriteLine($"InputTask: Device M1576 value: {m1576Value}");
                        if ((DateTime.Now - startTime).TotalSeconds > 15)
                        {
                            Console.WriteLine("InputTask: Timeout occurred, exiting...");
                            return;
                        }
                    } while (m1576Value != 1);
                    UpdateLabel(Lb_Rack, "");
                    Console.WriteLine($"인풋 종료신호 받음");
                }
                finally
                {
                    lock (lockObject)
                    {
                        isWorking = false;
                        Console.WriteLine("InputTask: Finished.");
                    }
                }
            });
        }

        void UpdateLabel(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(new Action(() => label.Text = text));
            }
            else
            {
                label.Text = text;
            }
        }
        string GetRackText(int inputSignal)
        {
            switch (inputSignal)
            {
                case 1600: return "1연 1단 투입";
                case 1601: return "1연 2단 투입";
                case 1602: return "1연 3단 투입";
                case 1603: return "1연 4단 투입";
                case 1604: return "2연 1단 투입";
                case 1605: return "2연 2단 투입";
                case 1606: return "2연 3단 투입";
                case 1607: return "2연 4단 투입";
                case 1608: return "3연 1단 투입";
                case 1609: return "3연 2단 투입";
                case 1610: return "3연 3단 투입";
                case 1611: return "3연 4단 투입";
                case 1612: return "4연 1단 투입";
                case 1613: return "4연 2단 투입";
                case 1614: return "4연 3단 투입";
                case 1615: return "4연 4단 투입";
                default: return "";
            }
        }
        private async Task OutputTask()
        {
            await Task.Run(() =>
            {
                lock (lockObject)
                {
                    if (isWorking) return;
                    isWorking = true;
                }

                try
                {
                    int m1585Value;
                    plc.GetDevice("M1585", out m1585Value);
                    if (m1585Value != 1)
                    {
                        Console.WriteLine("OutputTask: M1578 is not 1. Exiting.");
                        return;
                    }

                    int startChargeWarehouse = 1500;
                    int endChargeWarehouse = 1515;
                    int dischargeStartWarehouse = 1616;
                    int dischargeEndWarehouse = 1631;

                    Dictionary<string, int> chargeValues = new Dictionary<string, int>();
                    for (int i = startChargeWarehouse; i <= endChargeWarehouse; i++)
                    {
                        int value;
                        plc.GetDevice($"M{i}", out value);
                        chargeValues[$"M{i}"] = value;
                    }

                    bool canDischarge = false;
                    int dischargeWarehouse = 0;
                    int[] chargeWarehouseIndexes = Enumerable.Range(startChargeWarehouse, endChargeWarehouse - startChargeWarehouse + 1).ToArray();
                    Shuffle(chargeWarehouseIndexes); // 배열을 섞는 함수를 호출하여 랜덤 창고를 선택

                    foreach (int i in chargeWarehouseIndexes)
                    {
                        int chargeCompleteSignal = chargeValues[$"M{i}"];
                        Console.WriteLine($"OutputTask: Charge complete signal M{i} value: {chargeCompleteSignal}");

                        if (chargeCompleteSignal == 1)
                        {
                            canDischarge = true;
                            dischargeWarehouse = dischargeStartWarehouse + (i - startChargeWarehouse);
                            break;
                        }
                    }

                    if (!canDischarge)
                    {
                        Console.WriteLine("OutputTask: Cannot discharge yet. Waiting...");
                        Thread.Sleep(1000);
                        return;
                    }

                    //신호를 확인
                    int dischargeSignal;
                    plc.GetDevice($"M{dischargeWarehouse}", out dischargeSignal);
                    Console.WriteLine($"OutputTask: Discharge signal M{dischargeWarehouse} value: {dischargeSignal}");

                    if (dischargeSignal == 0)
                    {
                        string rackText = GetDischargeRackText(dischargeWarehouse);
                        Console.WriteLine($"OutputTask: Setting device M{dischargeWarehouse} to 1");
                        plc.SetDevice($"M{dischargeWarehouse}", 1);
                        UpdateLabel(Lb_Rack, rackText);
                        Thread.Sleep(2500);
                        plc.SetDevice($"M{dischargeWarehouse}", 0);
                        Console.WriteLine($"OutputTask: Setting device M{dischargeWarehouse} to 0");
                        Thread.Sleep(6000);

                        int dischargeCompleteSignal;
                        do
                        {
                            if (stopSignal.WaitOne(0))
                            {
                                Console.WriteLine("InputTask: Stopped.");
                                return;
                            }
                            Thread.Sleep(600);
                            plc.GetDevice("M1577", out dischargeCompleteSignal);
                            Console.WriteLine($"OutputTask: Discharge complete signal M1577 value: {dischargeCompleteSignal}");
                        } while (dischargeCompleteSignal != 1);
                        UpdateLabel(Lb_Rack, "");
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
            });
        }

        string GetDischargeRackText(int dischargeSignal)
        {
            switch (dischargeSignal)
            {
                case 1616: return "1연 1단 배출";
                case 1617: return "1연 2단 배출";
                case 1618: return "1연 3단 배출";
                case 1619: return "1연 4단 배출";
                case 1620: return "2연 1단 배출";
                case 1621: return "2연 2단 배출";
                case 1622: return "2연 3단 배출";
                case 1623: return "2연 4단 배출";
                case 1624: return "3연 1단 배출";
                case 1625: return "3연 2단 배출";
                case 1626: return "3연 3단 배출";
                case 1627: return "3연 4단 배출";
                case 1628: return "4연 1단 배출";
                case 1629: return "4연 2단 배출";
                case 1630: return "4연 3단 배출";
                case 1631: return "4연 4단 배출";
                default: return "";
            }
        }
        void Shuffle<T>(T[] array)
        {
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
        }
        private void Bt_RackOff_Click(object sender, EventArgs e)
        {
            DialogResult stopmsg = MessageBox.Show("작업을 정지하시겠습니까?", "창고 작업 종료", MessageBoxButtons.YesNo);
            if (stopmsg == DialogResult.Yes)
            { 
            stopSignal.Set();
            }
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
                if (Pc_on_value == 1)
                {
                    MessageBox.Show("이미 통신 중입니다.", "연결", MessageBoxButtons.OK);
                }
                else
                {
                    DialogResult msgresult = MessageBox.Show("PLC와 통신 하시겠습니까?", "연결 확인", MessageBoxButtons.YesNo);
                    if (msgresult == DialogResult.Yes)
                    {
                        plc.SetDevice("M1002", 1);
                    }
                }
            }
            else if (Plc_on_value == 0)
            {
                MessageBox.Show("PLC 통신 요청을 확인하세요", "통신 확인", MessageBoxButtons.OK);
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

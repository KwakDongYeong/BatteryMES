using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACTMULTILib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BatteryMes
{
    public partial class Fm_Main : Form
    {
        //객체 선언
        ActEasyIF PLC1 = new ActEasyIF();
        
        private int blinkCount = 0;
        private bool alarm1581Displayed = false;
        private bool alarm1582Displayed = false;
        private bool alarm1583Displayed = false;
        private bool alarm1584Displayed = false;
        private List<string> alarmsDisplayed = new List<string>();

        public Fm_Main()
        {
            InitializeComponent();
            this.Load += new EventHandler(Fm_Main_Load);
            PLC1.ActLogicalStationNumber = 1; //로지컬 스테이션 넘버 넣기
            int conErr = 0;
            conErr = PLC1.Open();

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Fm_Main_Load(object sender, EventArgs e)
        {
            case_cylamp.SizeMode = PictureBoxSizeMode.StretchImage;
            battery_cylamp.SizeMode = PictureBoxSizeMode.StretchImage;
            cvlamp1.SizeMode = PictureBoxSizeMode.StretchImage;
            fork_xlamp.SizeMode = PictureBoxSizeMode.StretchImage;
            fork_ylamp.SizeMode = PictureBoxSizeMode.StretchImage;
            fork_zlamp.SizeMode = PictureBoxSizeMode.StretchImage;
            fork_rotatelamp.SizeMode = PictureBoxSizeMode.StretchImage;
            cvlamp2.SizeMode = PictureBoxSizeMode.StretchImage;
            vision_check.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        private void SetPanelRegionToCircle(Panel panel)
        {
            if (panel != null)
            {
                // 원형 경로 생성
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, panel.Width, panel.Height);

                // 클리핑 영역 설정
                panel.Region = new Region(path);
            }
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            SetPanelRegionToCircle(panel);
        }
        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCon_Click(object sender, EventArgs e)
        {

        }

        private void btnDiscon_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                
                int m1534 = 0; int m1535 = 0; 
                int m1540 = 0; int m1541 = 0; int m1542 = 0; int m1543 = 0; int m1544 = 0; int m1545 = 0; 
                int m1546 = 0; int m1547 = 0; int m1548 = 0; int m1549 = 0; int m1550 = 0; int m1551 = 0;
                int m1552 = 0; int m1553 = 0; int m1554 = 0; int m1555 = 0; 
                int m1560 = 0; int m1561 = 0; int m1562 = 0; int m1563 = 0; int m1564 = 0; int m1565 = 0;
                int m1566 = 0; int m1567 = 0; int m1568 = 0; int m1569 = 0; int m1578 = 0;
                int m1581 = 0; int m1582 = 0; int m1583 = 0; int m1584 = 0;

                int y38 = 0; int y39 = 0; int y40 = 0; int y41 = 0; int y42 = 0; int y43 = 0;
                int y50 = 0, y51 = 0; int y1001 = 0;
                PLC1.GetDevice("M1534", out m1534); PLC1.GetDevice("M1535", out m1535);
                PLC1.GetDevice("M1540", out m1540); PLC1.GetDevice("m1541", out m1541); PLC1.GetDevice("m1542", out m1542);
                PLC1.GetDevice("m1543", out m1543); PLC1.GetDevice("m1544", out m1544); PLC1.GetDevice("m1545", out m1545);
                PLC1.GetDevice("m1546", out m1546); PLC1.GetDevice("m1547", out m1547); PLC1.GetDevice("m1548", out m1548);
                PLC1.GetDevice("m1549", out m1549); PLC1.GetDevice("m1550", out m1550); PLC1.GetDevice("m1551", out m1551);
                PLC1.GetDevice("m1552", out m1552); PLC1.GetDevice("m1553", out m1553); PLC1.GetDevice("m1554", out m1554);
                PLC1.GetDevice("m1555", out m1555);
                PLC1.GetDevice("m1560", out m1560); PLC1.GetDevice("m1561", out m1561); PLC1.GetDevice("m1562", out m1562);
                PLC1.GetDevice("m1563", out m1563); PLC1.GetDevice("m1564", out m1564); PLC1.GetDevice("m1565", out m1565);
                PLC1.GetDevice("m1566", out m1566); PLC1.GetDevice("m1567", out m1567); PLC1.GetDevice("m1568", out m1568);
                PLC1.GetDevice("m1569", out m1569); PLC1.GetDevice("m1578", out m1578);
                PLC1.GetDevice("m1581", out m1581); PLC1.GetDevice("m1582", out m1582); PLC1.GetDevice("m1583", out m1583);
                PLC1.GetDevice("m1584", out m1584);
                PLC1.GetDevice("Y38", out y38); PLC1.GetDevice("Y39", out y39); PLC1.GetDevice("Y40", out y40);
                PLC1.GetDevice("Y41", out y41); PLC1.GetDevice("Y42", out y42); PLC1.GetDevice("Y43", out y43);
                PLC1.GetDevice("Y50", out y50); PLC1.GetDevice("Y51", out y51); PLC1.GetDevice("Y1001", out y1001);


                int d1513 = 0;
                int d1613 = 0;
                PLC1.GetDevice("D1513", out d1513);
                PLC1.GetDevice("D1613", out d1613);

                // Label 업데이트
                label18.Text = d1513.ToString();
                label19.Text = d1613.ToString();

                // PictureBox 이미지 변경
                case_cylamp.Image = (m1560 == 1) ? Properties.Resources.green : (m1561 == 1) ? Properties.Resources.red : null;
                battery_cylamp.Image = (m1562 == 1) ? Properties.Resources.green : (m1563 == 1) ? Properties.Resources.red : null;
                cvlamp1.Image = (1568 == 1) ? Properties.Resources.green : null;
                fork_xlamp.Image = (m1566 == 1) ? Properties.Resources.green : (m1567 == 1) ? Properties.Resources.red : null;
                fork_ylamp.Image = (y38 == 1) ? Properties.Resources.green : (y39 == 1) ? Properties.Resources.red : null;
                fork_zlamp.Image = (y40 == 1) ? Properties.Resources.green : (y41 == 1) ? Properties.Resources.red : null;
                fork_rotatelamp.Image = (m1564 == 1) ? Properties.Resources.green : (m1565 == 1) ? Properties.Resources.red : null;
                cvlamp2.Image = (m1569 == 1) ? Properties.Resources.green : null;
                vision_check.Image = (m1534 == 1) ? Properties.Resources.green : (m1535 == 1) ? Properties.Resources.red : null;

                try
                {
                    // m1581, m1582, m1583, m1584
                    CheckAndDisplayAlarm(m1581, "서보알람 에러");
                    CheckAndDisplayAlarm(m1582, "이중격납 알람");
                    CheckAndDisplayAlarm(m1583, "공출고 알람");
                    CheckAndDisplayAlarm(m1584, "포크전진 기동알람");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PLC 통신 오류: " + ex.Message);
                }



                panel18.BackColor = (y1001 ==1) ? Color.Lime : Color.Red ;
                lblStatus.Text = (y1001 == 1) ? " ● PLC와의 연결이 확인되었습니다.●" : " ❌ PLC 와 연결되어 있지않습니다.❌ \n  제어창에서 PLC connect를 진행하세요.";

                // M1540 ~ M1555 상태 읽기
                int[] mBits = new int[16];
                int mStart = 1540;
                int activeCount = 0;

                for (int i = 0; i < 16; i++)
                {
                    PLC1.GetDevice($"M{mStart + i}", out mBits[i]);
                    if (mBits[i] == 1)
                    {
                        activeCount++;
                    }
                }
                rackplace.Text = $"{activeCount}";

                if (m1578 == 1)
                {
                    // "autoSignal" 라벨이 깜박이도록 타이머 시작
                    blinkTimer.Start();
                    durationTimer.Start();
                }
                else
                {
                    // "autoSignal" 라벨이 깜박이는 타이머 중지
                    blinkTimer.Stop();
                    durationTimer.Stop();
                    autosignal.Text = ": Stopped";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PLC 통신 오류: " + ex.Message);
            }
        }
        private void CheckAndDisplayAlarm(int mValue, string alarmMessage)
        {
            if (mValue == 1 && !alarmsDisplayed.Contains(alarmMessage))
            {
                mentbox.AppendText($"[{DateTime.Now:HH:mm}] {alarmMessage} 발생하였습니다.\n");
                alarmsDisplayed.Add(alarmMessage);
            }
            else if (mValue == 0 && alarmsDisplayed.Contains(alarmMessage))
            {
                mentbox.AppendText($"[{DateTime.Now:HH:mm}] {alarmMessage} 해제되었습니다.\n");
                alarmsDisplayed.Remove(alarmMessage);
            }
        }
        private void mentbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void blinkTimer_Tick(object sender, EventArgs e)
        {
            autosignal.Visible = !autosignal.Visible;
            // 깜박임 횟수 증가
            blinkCount++;
            // 3번 깜박였을 때
            if (blinkCount == 3)
            {
                // "blinkTimer" 중지
                blinkTimer.Stop();
                // "autoSignal" 라벨이 깜박임을 멈추고 "running"으로 설정
                autosignal.Visible = true;
                autosignal.Text = ": Running";
                // 깜박임 횟수 초기화
                blinkCount = 0;
            }
        }

        private void durationTimer_Tick(object sender, EventArgs e)
        {
            // "blinkTimer" 중지
            blinkTimer.Stop();
            // "autoSignal" 라벨이 깜박임을 멈추고 "running"으로 설정
            autosignal.Visible = true;
            autosignal.Text = ": Running";
            // 깜박임 횟수 초기화
            blinkCount = 0;
        }
    }
}

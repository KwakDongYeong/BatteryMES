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
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BatteryMes
{
    public partial class Fm_Main : Form
    {
        private string connectionString = "Server = 10.10.32.238; Database=batterymes; Uid=BatteryMes;Pwd=Battery;";
        //객체 선언
        ActEasyIF PLC1 = new ActEasyIF();
        private Dictionary<string, PictureBox> sensorPictureBoxes;

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
            PLC1.ActLogicalStationNumber = 0; //로지컬 스테이션 넘버 넣기
            int conErr = 0;
            conErr = PLC1.Open();

        }

        private void Fm_Main_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
            case_cylamp.SizeMode = PictureBoxSizeMode.StretchImage;
            battery_cylamp.SizeMode = PictureBoxSizeMode.StretchImage;
            cvlamp1.SizeMode = PictureBoxSizeMode.StretchImage;
            fork_xlamp.SizeMode = PictureBoxSizeMode.StretchImage;
            fork_ylamp.SizeMode = PictureBoxSizeMode.StretchImage;
            fork_zlamp.SizeMode = PictureBoxSizeMode.StretchImage;
            fork_rotatelamp.SizeMode = PictureBoxSizeMode.StretchImage;
            cvlamp2.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }
        private void LoadDataFromDatabase()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT sensor, value FROM mainview WHERE value IN (0, 1)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        connection.Open();
                        DataTable dataTable = new DataTable();

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        connection.Close();

                        ClearAllPictureBoxes();

                        if (dataTable.Rows.Count > 0)
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                string sensor = row["sensor"].ToString();
                                int value = Convert.ToInt32(row["value"]);
                                Image image = GetImage(sensor, value);
                                SetPictureBoxImage(sensor, image);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터를 불러오는 중 오류가 발생했습니다: " + ex.Message);
            }
        }

        private Image GetImage(string sensor, int value)
        {
            Image image;

            switch (sensor)
            {
                case "케이스_공급실린더":
                    image = (value == 1) ? Properties.Resources.green : Properties.Resources.red;
                    break;
                case "베터리_공급실린더":
                    image = (value == 1) ? Properties.Resources.green : Properties.Resources.red;
                    break;
                case "공급_컨베이어":
                    image = (value == 1) ? Properties.Resources.green : null;
                    break;
                case "포크_전진":
                    image = (value == 1) ? Properties.Resources.green : Properties.Resources.red;
                    break;
                case "서보주행":
                    image = (value == 1) ? Properties.Resources.green : null;
                    break;
                case "서보승강":
                    image = (value == 1) ? Properties.Resources.green : null;
                    break;
                case "포크_회전":
                    image = (value == 1) ? Properties.Resources.green : Properties.Resources.red;
                    break;
                case "배출_컨베이어":
                    image = (value == 1) ? Properties.Resources.green : null;
                    break;
                default:
                    // 기본 이미지
                    image = null;
                    break;
            }

            return image;
        }

        private void SetPictureBoxImage(string sensor, Image image)
        {
            switch (sensor)
            {
                case "케이스_공급실린더":
                    case_cylamp.Image = image;
                    break;
                case "베터리_공급실린더":
                    battery_cylamp.Image = image;
                    break;
                case "공급_컨베이어":
                    cvlamp1.Image = image;
                    break;
                case "포크_전진":
                    fork_xlamp.Image = image;
                    break;
                case "서보주행":
                    fork_ylamp.Image = image;
                    break;
                case "서보승강":
                    fork_zlamp.Image = image;
                    break;
                case "포크_회전":
                    fork_rotatelamp.Image = image;
                    break;
                case "배출_컨베이어":
                    cvlamp2.Image = image;
                    break;
            }
        }

        private void ClearAllPictureBoxes()
        {
            case_cylamp.Image = null;
            battery_cylamp.Image = null;
            cvlamp1.Image = null;
            fork_xlamp.Image = null;
            fork_ylamp.Image = null;
            fork_zlamp.Image = null;
            fork_rotatelamp.Image = null;
            cvlamp2.Image = null;
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
            try
            {

                
                int m1578 = 0;
                int m1540 = 0; int m1541 = 0; int m1542 = 0; int m1543 = 0; int m1544 = 0; int m1545 = 0; 
                int m1546 = 0; int m1547 = 0; int m1548 = 0; int m1549 = 0; int m1550 = 0; int m1551 = 0;
                int m1552 = 0; int m1553 = 0; int m1554 = 0; int m1555 = 0; int m1581 = 0; int m1582 = 0;
                int m1583 = 0; int m1584 = 0; int y1001 = 0;

                PLC1.GetDevice("M1540", out m1540); PLC1.GetDevice("m1541", out m1541); PLC1.GetDevice("m1542", out m1542);
                PLC1.GetDevice("m1543", out m1543); PLC1.GetDevice("m1544", out m1544); PLC1.GetDevice("m1545", out m1545);
                PLC1.GetDevice("m1546", out m1546); PLC1.GetDevice("m1547", out m1547); PLC1.GetDevice("m1548", out m1548);
                PLC1.GetDevice("m1549", out m1549); PLC1.GetDevice("m1550", out m1550); PLC1.GetDevice("m1551", out m1551);
                PLC1.GetDevice("m1552", out m1552); PLC1.GetDevice("m1553", out m1553); PLC1.GetDevice("m1554", out m1554);
                PLC1.GetDevice("m1555", out m1555); PLC1.GetDevice("m1578", out m1578); 
                PLC1.GetDevice("m1581", out m1581); PLC1.GetDevice("m1582", out m1582); PLC1.GetDevice("m1583", out m1583);
                PLC1.GetDevice("m1584", out m1584); PLC1.GetDevice("Y1001", out y1001);

                int d1513 = 0;
                int d1514 = 0;
                PLC1.GetDevice("D1513", out d1513);
                PLC1.GetDevice("D1514", out d1514);

                // Label 업데이트
                label18.Text = d1513.ToString();
                label19.Text = d1514.ToString();

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

                autosignal.Text = (m1578 == 1) ? " Running" : " Stopped";
            
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

        }

        private void durationTimer_Tick(object sender, EventArgs e)
        {

        }

        private void mentbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

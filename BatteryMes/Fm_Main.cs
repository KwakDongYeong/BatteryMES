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

namespace BatteryMes
{
    public partial class Fm_Main : Form
    {
        //객체 선언
        ActEasyIF PLC1 = new ActEasyIF();

        public Fm_Main()
        {
            InitializeComponent();
            this.Load += new EventHandler(Fm_Main_Load);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Fm_Main_Load(object sender, EventArgs e)
        {
            case_cylamp.SizeMode = PictureBoxSizeMode.StretchImage;
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
            PLC1.ActLogicalStationNumber = 1; //로지컬 스테이션 넘버 넣기
            int conErr = 0;
            conErr = PLC1.Open();

            if (conErr == 0)
            {
                lblStatus.Text = "Connected";
            }
            else lblStatus.Text = "Connection error : " + conErr;
        }

        private void btnDiscon_Click(object sender, EventArgs e)
        {
            PLC1.Close();
            lblStatus.Text = "Disconnected";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // PLC에서 Y20과 Y21 상태 읽기
                int y20 = 0;
                int y21 = 0;
                PLC1.GetDevice("Y20", out y20);
                PLC1.GetDevice("Y21", out y21);

                // PictureBox 이미지 변경
                if (y20 == 1)
                {
                    case_cylamp.Image = Properties.Resources.green; // Y20이 켜진 경우
                }
                else if (y21 == 1)
                {
                    case_cylamp.Image = Properties.Resources.red; // Y21이 켜진 경우
                }
                else
                {
                    case_cylamp.Image = null; // 아무것도 켜지지 않은 경우
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("PLC 통신 오류: " + ex.Message);
            }
        }
    }
}

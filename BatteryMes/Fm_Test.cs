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
using ActUtlTypeLib;

namespace BatteryMes
{
    public partial class Fm_Test : Form
    {
        public ActUtlType plc = new ActUtlType();
        public Fm_Test()
        {
            InitializeComponent();
        }

        private void Fm_Test_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            plc.ActLogicalStationNumber = 1;
            plc.Open();
            LightOn();
        }

        public void LightOn()
        {
                int value;
            plc.GetDevice("M1", out value);
            if(value == 0)
            {
                pictureBox1.Image = Properties.Resources.제목_없음;
            }
            else
            {
                pictureBox1.Image = Properties.Resources._1;
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                // 원형 경로 생성
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, panel.Width, panel.Height);

                // 클리핑 영역 설정
                panel.Region = new Region(path);
            }
        }
    }
}

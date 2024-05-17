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

namespace BatteryMes
{
    public partial class Fm_Main : Form
    {
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
            // 지정한 패널들의 Paint 이벤트에 핸들러를 연결합니다.
            panel1.Paint += new PaintEventHandler(panel_Paint);
            panel2.Paint += new PaintEventHandler(panel_Paint);
            panel3.Paint += new PaintEventHandler(panel_Paint);
            panel4.Paint += new PaintEventHandler(panel_Paint);
            panel5.Paint += new PaintEventHandler(panel_Paint);
            panel6.Paint += new PaintEventHandler(panel_Paint);
            panel7.Paint += new PaintEventHandler(panel_Paint);
            panel8.Paint += new PaintEventHandler(panel_Paint);
            panel9.Paint += new PaintEventHandler(panel_Paint);
            panel10.Paint += new PaintEventHandler(panel_Paint);
            panel11.Paint += new PaintEventHandler(panel_Paint);
            panel12.Paint += new PaintEventHandler(panel_Paint);
            panel13.Paint += new PaintEventHandler(panel_Paint);
            panel14.Paint += new PaintEventHandler(panel_Paint);
            panel15.Paint += new PaintEventHandler(panel_Paint);
            panel16.Paint += new PaintEventHandler(panel_Paint);
            // 필요한 만큼 패널을 추가합니다.
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
    }
}

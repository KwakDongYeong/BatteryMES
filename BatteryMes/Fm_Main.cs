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

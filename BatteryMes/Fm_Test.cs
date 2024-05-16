using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}

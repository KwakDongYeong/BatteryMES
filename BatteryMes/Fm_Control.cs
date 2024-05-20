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

namespace BatteryMes
{
    public partial class Fm_Control : Form
    {
        public ActUtlType plc = new ActUtlType();
        private Timer timer = new Timer();

        private Timer colorTimer;

        private int progressBarValue = 0;
        

        public Fm_Control()
        {
            InitializeComponent();
            plc.ActLogicalStationNumber = 1;
            plc.Open();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            ChargeBattery();
            this.DoubleBuffered = true;
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            progressBar1.Step = 20;

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            ChargeBattery();
            
        }


        private void ChargeBattery()
        {
            int value;
            plc.GetDevice("M7", out value);
            int timevalue;
            plc.GetDevice("T1", out timevalue);
            int chargevalue;
            plc.GetDevice("M111", out chargevalue);

            if (value == 1)
            {
                progressBar1.Visible = true;
                Pn_pro_1_4.Visible = true;
                
                if (timevalue > 0 && timevalue < 300)
                {
                    progressBar1.ForeColor = (progressBar1.ForeColor == Color.FromArgb(206, 240, 19)) ? Color.FromArgb(230, 220, 10) : Color.FromArgb(206, 240, 19);
                    
                    if (timevalue >= 1 && timevalue < 60)
                    {
                        progressBar1.Value = 20;
                    }
                    else if (timevalue >= 60 && timevalue < 120)
                    {
                        progressBar1.Value = 40;
                    }
                    else if (timevalue >= 120 && timevalue < 180)
                    {
                        progressBar1.Value = 60;
                    }
                    else if (timevalue >= 180 && timevalue < 240)
                    {
                        progressBar1.Value = 80;
                    }
                    else if (timevalue >= 240 && timevalue < 300)
                    {
                        progressBar1.Value = 100;
                    }
                }
                else if (chargevalue == 1)
                {
                    progressBar1.ForeColor = Color.FromArgb(230, 220, 10);
                    progressBar1.Value = 100;
                }

                else
                {
                    progressBar1.Value = 0;
                }
            }
            else
            {
                Pn_1_4.BackColor = SystemColors.ControlDark;
                progressBar1.Value = 0;
                progressBarValue = 0;
                progressBar1.Visible = false;
                Pn_pro_1_4.Visible = false;

            }
        }
      
        private void Fm_Control_Load(object sender, EventArgs e)
        {
           
        }
    
        private void Bt_ProcessOn_Click(object sender, EventArgs e)
        {

        }

        private void Bt_ProcessOff_Click(object sender, EventArgs e)
        {

        }
        private void Fm_Controls_Closing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            plc.Close();
        }

    }
}

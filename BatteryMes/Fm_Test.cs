﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActUtlTypeLib;

namespace BatteryMes
{
    public partial class Fm_Test : Form
    {
        public ActUtlType plc = new ActUtlType();
        private Timer timer = new Timer();
        public Fm_Test()
        {
            InitializeComponent();
            Pn_Tray_On.Paint += panel2_Paint;
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.DoubleBuffered = true;

         

        }

        private void Fm_Test_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            plc.ActLogicalStationNumber = 1;
            plc.Open();
            LightOn();

            Bt_Tray_On.BackgroundImageLayout = ImageLayout.Stretch;
            Bt_Tray_On.BackgroundImage = Properties.Resources.테스트1;
            BT_Tray_OFF.BackgroundImageLayout = ImageLayout.Stretch;
            BT_Tray_OFF.BackgroundImage = Properties.Resources.테스트1;

        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            Pn_Tray_On.Invalidate();
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
            Panel Pn_Tray_On = sender as Panel;
            if (Pn_Tray_On != null)
            {
                // 원형 경로 생성
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, Pn_Tray_On.Width, Pn_Tray_On.Height);

                // 클리핑 영역 설정
                Pn_Tray_On.Region = new Region(path);
                int value;
                plc.GetDevice("M1", out value);
                if (value == 0)
                {

                    using (Pen pen = new Pen(Color.Black, 5)) // 두께 3의 검은색 펜 사용
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.DrawEllipse(pen, 1, 1, Pn_Tray_On.Width - 2, Pn_Tray_On.Height - 2);
                        Pn_Tray_On.BackColor = Color.DarkGray;
                    }
                }
                
                else
                {
                    using (Pen pen = new Pen(Color.Black, 5)) // 두께 3의 검은색 펜 사용
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.DrawEllipse(pen, 1, 1, Pn_Tray_On.Width - 2, Pn_Tray_On.Height - 2);
                        Pn_Tray_On.BackColor = Color.Red;
                    }
                }
                
            }
        }

        private void Bt_Tray_On_Click(object sender, EventArgs e)
        {
            
        }

        private void Bt_Tray_On_MouseDown(object sender, MouseEventArgs e)
        {
            Bt_Tray_On.BackgroundImageLayout = ImageLayout.Stretch;
            Bt_Tray_On.BackgroundImage = Properties.Resources.PU;
            plc.SetDevice("M1", 1);
        }

        private void Bt_Tray_On_MouseUp(object sender, MouseEventArgs e)
        {
            Bt_Tray_On.BackgroundImageLayout = ImageLayout.Stretch;
            Bt_Tray_On.BackgroundImage = Properties.Resources.테스트1;
            plc.SetDevice("M1", 0);
        }

       

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BT_Tray_OFF_Click(object sender, EventArgs e)
        {

        }

        private void BT_Tray_OFF_MouseDown(object sender, MouseEventArgs e)
        {
            BT_Tray_OFF.BackgroundImageLayout = ImageLayout.Stretch;
            BT_Tray_OFF.BackgroundImage = Properties.Resources.PU;
        }

        private void BT_Tray_OFF_MouseUp(object sender, MouseEventArgs e)
        {
            BT_Tray_OFF.BackgroundImageLayout = ImageLayout.Stretch;
            BT_Tray_OFF.BackgroundImage = Properties.Resources.테스트1;
        }
    }
    
}
   
namespace BatteryMes
{
    partial class Fm_Test
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Pn_Title_M = new System.Windows.Forms.Panel();
            this.Lb_Title_M = new System.Windows.Forms.Label();
            this.Pn_monitoring = new System.Windows.Forms.Panel();
            this.Pn_Tray_On = new System.Windows.Forms.Panel();
            this.Pn_Title_C = new System.Windows.Forms.Panel();
            this.Lb_Title_C = new System.Windows.Forms.Label();
            this.Bt_Tray_On = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BT_Tray_OFF = new System.Windows.Forms.Button();
            this.Pn_Title_M.SuspendLayout();
            this.Pn_monitoring.SuspendLayout();
            this.Pn_Title_C.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pn_Title_M
            // 
            this.Pn_Title_M.Controls.Add(this.Lb_Title_M);
            this.Pn_Title_M.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pn_Title_M.Location = new System.Drawing.Point(3, 3);
            this.Pn_Title_M.Name = "Pn_Title_M";
            this.Pn_Title_M.Size = new System.Drawing.Size(561, 44);
            this.Pn_Title_M.TabIndex = 0;
            // 
            // Lb_Title_M
            // 
            this.Lb_Title_M.AutoSize = true;
            this.Lb_Title_M.Location = new System.Drawing.Point(216, 14);
            this.Lb_Title_M.Name = "Lb_Title_M";
            this.Lb_Title_M.Size = new System.Drawing.Size(102, 15);
            this.Lb_Title_M.TabIndex = 0;
            this.Lb_Title_M.Text = "센서 모니터링";
            // 
            // Pn_monitoring
            // 
            this.Pn_monitoring.Controls.Add(this.Bt_Tray_On);
            this.Pn_monitoring.Controls.Add(this.pictureBox1);
            this.Pn_monitoring.Controls.Add(this.Pn_Tray_On);
            this.Pn_monitoring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pn_monitoring.Location = new System.Drawing.Point(30, 70);
            this.Pn_monitoring.Margin = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.Pn_monitoring.Name = "Pn_monitoring";
            this.Pn_monitoring.Size = new System.Drawing.Size(507, 592);
            this.Pn_monitoring.TabIndex = 1;
            // 
            // Pn_Tray_On
            // 
            this.Pn_Tray_On.Location = new System.Drawing.Point(32, 33);
            this.Pn_Tray_On.Name = "Pn_Tray_On";
            this.Pn_Tray_On.Size = new System.Drawing.Size(34, 32);
            this.Pn_Tray_On.TabIndex = 0;
            // 
            // Pn_Title_C
            // 
            this.Pn_Title_C.Controls.Add(this.Lb_Title_C);
            this.Pn_Title_C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pn_Title_C.Location = new System.Drawing.Point(570, 3);
            this.Pn_Title_C.Name = "Pn_Title_C";
            this.Pn_Title_C.Size = new System.Drawing.Size(688, 44);
            this.Pn_Title_C.TabIndex = 1;
            // 
            // Lb_Title_C
            // 
            this.Lb_Title_C.AutoSize = true;
            this.Lb_Title_C.Location = new System.Drawing.Point(330, 14);
            this.Lb_Title_C.Name = "Lb_Title_C";
            this.Lb_Title_C.Size = new System.Drawing.Size(37, 15);
            this.Lb_Title_C.TabIndex = 0;
            this.Lb_Title_C.Text = "조작";
            // 
            // Bt_Tray_On
            // 
            this.Bt_Tray_On.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Tray_On.Location = new System.Drawing.Point(149, 222);
            this.Bt_Tray_On.Name = "Bt_Tray_On";
            this.Bt_Tray_On.Size = new System.Drawing.Size(101, 182);
            this.Bt_Tray_On.TabIndex = 0;
            this.Bt_Tray_On.Text = "Tray전진";
            this.Bt_Tray_On.UseVisualStyleBackColor = true;
            this.Bt_Tray_On.Click += new System.EventHandler(this.Bt_Tray_On_Click);
            this.Bt_Tray_On.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Bt_Tray_On_MouseDown);
            this.Bt_Tray_On.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Bt_Tray_On_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Controls.Add(this.Pn_monitoring, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Pn_Title_C, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Pn_Title_M, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1261, 682);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(242, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 25);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(570, 53);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(688, 626);
            this.tableLayoutPanel2.TabIndex = 2;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.BT_Tray_OFF, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(682, 226);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // BT_Tray_OFF
            // 
            this.BT_Tray_OFF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BT_Tray_OFF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BT_Tray_OFF.FlatAppearance.BorderSize = 0;
            this.BT_Tray_OFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Tray_OFF.Location = new System.Drawing.Point(173, 3);
            this.BT_Tray_OFF.Name = "BT_Tray_OFF";
            this.BT_Tray_OFF.Size = new System.Drawing.Size(164, 50);
            this.BT_Tray_OFF.TabIndex = 1;
            this.BT_Tray_OFF.Text = "Tray후진";
            this.BT_Tray_OFF.UseVisualStyleBackColor = true;
            this.BT_Tray_OFF.Click += new System.EventHandler(this.BT_Tray_OFF_Click);
            this.BT_Tray_OFF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BT_Tray_OFF_MouseDown);
            this.BT_Tray_OFF.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BT_Tray_OFF_MouseUp);
            // 
            // Fm_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1261, 682);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Fm_Test";
            this.Text = "Fm_Test";
            this.Load += new System.EventHandler(this.Fm_Test_Load);
            this.Pn_Title_M.ResumeLayout(false);
            this.Pn_Title_M.PerformLayout();
            this.Pn_monitoring.ResumeLayout(false);
            this.Pn_Title_C.ResumeLayout(false);
            this.Pn_Title_C.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Pn_Title_M;
        private System.Windows.Forms.Label Lb_Title_M;
        private System.Windows.Forms.Panel Pn_monitoring;
        private System.Windows.Forms.Panel Pn_Title_C;
        private System.Windows.Forms.Label Lb_Title_C;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Pn_Tray_On;
        private System.Windows.Forms.Button Bt_Tray_On;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button BT_Tray_OFF;
    }
}
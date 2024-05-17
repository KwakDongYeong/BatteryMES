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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Pn_Tray_On = new System.Windows.Forms.Panel();
            this.Pn_Title_C = new System.Windows.Forms.Panel();
            this.Lb_Title_C = new System.Windows.Forms.Label();
            this.Pn_Control = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Pn_Title_M.SuspendLayout();
            this.Pn_monitoring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Pn_Title_C.SuspendLayout();
            this.Pn_Control.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.Pn_monitoring.Controls.Add(this.pictureBox1);
            this.Pn_monitoring.Controls.Add(this.Pn_Tray_On);
            this.Pn_monitoring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pn_monitoring.Location = new System.Drawing.Point(30, 70);
            this.Pn_monitoring.Margin = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.Pn_monitoring.Name = "Pn_monitoring";
            this.Pn_monitoring.Size = new System.Drawing.Size(507, 592);
            this.Pn_monitoring.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(192, 256);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 51);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            // Pn_Control
            // 
            this.Pn_Control.Controls.Add(this.button1);
            this.Pn_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pn_Control.Location = new System.Drawing.Point(570, 53);
            this.Pn_Control.Name = "Pn_Control";
            this.Pn_Control.Size = new System.Drawing.Size(688, 626);
            this.Pn_Control.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 97);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Controls.Add(this.Pn_Control, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Pn_monitoring, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Pn_Title_C, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Pn_Title_M, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1261, 682);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Fm_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 682);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Fm_Test";
            this.Text = "Fm_Test";
            this.Load += new System.EventHandler(this.Fm_Test_Load);
            this.Pn_Title_M.ResumeLayout(false);
            this.Pn_Title_M.PerformLayout();
            this.Pn_monitoring.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Pn_Title_C.ResumeLayout(false);
            this.Pn_Title_C.PerformLayout();
            this.Pn_Control.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Pn_Title_M;
        private System.Windows.Forms.Label Lb_Title_M;
        private System.Windows.Forms.Panel Pn_monitoring;
        private System.Windows.Forms.Panel Pn_Title_C;
        private System.Windows.Forms.Label Lb_Title_C;
        private System.Windows.Forms.Panel Pn_Control;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Pn_Tray_On;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
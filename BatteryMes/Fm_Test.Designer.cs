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
            this.Pn_Title_C = new System.Windows.Forms.Panel();
            this.Lb_Title_C = new System.Windows.Forms.Label();
            this.Pn_Control = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Pn_Tray_On = new System.Windows.Forms.Panel();
            this.Pn_Title_M.SuspendLayout();
            this.Pn_monitoring.SuspendLayout();
            this.Pn_Title_C.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Pn_Title_M
            // 
            this.Pn_Title_M.Controls.Add(this.Lb_Title_M);
            this.Pn_Title_M.Location = new System.Drawing.Point(12, 28);
            this.Pn_Title_M.Name = "Pn_Title_M";
            this.Pn_Title_M.Size = new System.Drawing.Size(445, 38);
            this.Pn_Title_M.TabIndex = 0;
            // 
            // Lb_Title_M
            // 
            this.Lb_Title_M.AutoSize = true;
            this.Lb_Title_M.Location = new System.Drawing.Point(169, 14);
            this.Lb_Title_M.Name = "Lb_Title_M";
            this.Lb_Title_M.Size = new System.Drawing.Size(102, 15);
            this.Lb_Title_M.TabIndex = 0;
            this.Lb_Title_M.Text = "센서 모니터링";
            // 
            // Pn_monitoring
            // 
            this.Pn_monitoring.Controls.Add(this.pictureBox1);
            this.Pn_monitoring.Controls.Add(this.Pn_Tray_On);
            this.Pn_monitoring.Location = new System.Drawing.Point(12, 72);
            this.Pn_monitoring.Name = "Pn_monitoring";
            this.Pn_monitoring.Size = new System.Drawing.Size(445, 442);
            this.Pn_monitoring.TabIndex = 1;
            // 
            // Pn_Title_C
            // 
            this.Pn_Title_C.Controls.Add(this.Lb_Title_C);
            this.Pn_Title_C.Location = new System.Drawing.Point(463, 28);
            this.Pn_Title_C.Name = "Pn_Title_C";
            this.Pn_Title_C.Size = new System.Drawing.Size(418, 38);
            this.Pn_Title_C.TabIndex = 1;
            // 
            // Lb_Title_C
            // 
            this.Lb_Title_C.AutoSize = true;
            this.Lb_Title_C.Location = new System.Drawing.Point(193, 14);
            this.Lb_Title_C.Name = "Lb_Title_C";
            this.Lb_Title_C.Size = new System.Drawing.Size(37, 15);
            this.Lb_Title_C.TabIndex = 0;
            this.Lb_Title_C.Text = "조작";
            // 
            // Pn_Control
            // 
            this.Pn_Control.Location = new System.Drawing.Point(463, 72);
            this.Pn_Control.Name = "Pn_Control";
            this.Pn_Control.Size = new System.Drawing.Size(418, 442);
            this.Pn_Control.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(189, 200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Pn_Tray_On
            // 
            this.Pn_Tray_On.Location = new System.Drawing.Point(23, 26);
            this.Pn_Tray_On.Name = "Pn_Tray_On";
            this.Pn_Tray_On.Size = new System.Drawing.Size(34, 32);
            this.Pn_Tray_On.TabIndex = 0;
            // 
            // Fm_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 526);
            this.Controls.Add(this.Pn_Control);
            this.Controls.Add(this.Pn_Title_C);
            this.Controls.Add(this.Pn_monitoring);
            this.Controls.Add(this.Pn_Title_M);
            this.Name = "Fm_Test";
            this.Text = "Fm_Test";
            this.Load += new System.EventHandler(this.Fm_Test_Load);
            this.Pn_Title_M.ResumeLayout(false);
            this.Pn_Title_M.PerformLayout();
            this.Pn_monitoring.ResumeLayout(false);
            this.Pn_Title_C.ResumeLayout(false);
            this.Pn_Title_C.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
    }
}
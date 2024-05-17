namespace BatteryMes
{
    partial class Fm_Frame
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Bt_Zoom = new System.Windows.Forms.Button();
            this.Bt_Close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Bt_User = new System.Windows.Forms.Button();
            this.Bt_Static = new System.Windows.Forms.Button();
            this.Bt_Test = new System.Windows.Forms.Button();
            this.Bt_Control = new System.Windows.Forms.Button();
            this.Bt_Main = new System.Windows.Forms.Button();
            this.Pn_Main = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.Bt_Zoom);
            this.panel1.Controls.Add(this.Bt_Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1174, 50);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Bt_Zoom
            // 
            this.Bt_Zoom.Dock = System.Windows.Forms.DockStyle.Right;
            this.Bt_Zoom.FlatAppearance.BorderSize = 0;
            this.Bt_Zoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Zoom.Location = new System.Drawing.Point(1060, 0);
            this.Bt_Zoom.Name = "Bt_Zoom";
            this.Bt_Zoom.Size = new System.Drawing.Size(57, 50);
            this.Bt_Zoom.TabIndex = 1;
            this.Bt_Zoom.Text = "ㅇ";
            this.Bt_Zoom.UseVisualStyleBackColor = true;
            this.Bt_Zoom.Click += new System.EventHandler(this.Bt_Zoom_Click);
            // 
            // Bt_Close
            // 
            this.Bt_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.Bt_Close.FlatAppearance.BorderSize = 0;
            this.Bt_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Close.Location = new System.Drawing.Point(1117, 0);
            this.Bt_Close.Name = "Bt_Close";
            this.Bt_Close.Size = new System.Drawing.Size(57, 50);
            this.Bt_Close.TabIndex = 0;
            this.Bt_Close.Text = "X";
            this.Bt_Close.UseVisualStyleBackColor = true;
            this.Bt_Close.Click += new System.EventHandler(this.Bt_Close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.Bt_User);
            this.panel2.Controls.Add(this.Bt_Static);
            this.panel2.Controls.Add(this.Bt_Test);
            this.panel2.Controls.Add(this.Bt_Control);
            this.panel2.Controls.Add(this.Bt_Main);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 594);
            this.panel2.TabIndex = 1;
            // 
            // Bt_User
            // 
            this.Bt_User.Dock = System.Windows.Forms.DockStyle.Top;
            this.Bt_User.FlatAppearance.BorderSize = 0;
            this.Bt_User.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_User.Location = new System.Drawing.Point(0, 228);
            this.Bt_User.Name = "Bt_User";
            this.Bt_User.Size = new System.Drawing.Size(250, 57);
            this.Bt_User.TabIndex = 4;
            this.Bt_User.Text = "직원관리";
            this.Bt_User.UseVisualStyleBackColor = true;
            this.Bt_User.Click += new System.EventHandler(this.Bt_User_Click);
            // 
            // Bt_Static
            // 
            this.Bt_Static.Dock = System.Windows.Forms.DockStyle.Top;
            this.Bt_Static.FlatAppearance.BorderSize = 0;
            this.Bt_Static.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Static.Location = new System.Drawing.Point(0, 171);
            this.Bt_Static.Name = "Bt_Static";
            this.Bt_Static.Size = new System.Drawing.Size(250, 57);
            this.Bt_Static.TabIndex = 3;
            this.Bt_Static.Text = "통계";
            this.Bt_Static.UseVisualStyleBackColor = true;
            this.Bt_Static.Click += new System.EventHandler(this.Bt_Static_Click);
            // 
            // Bt_Test
            // 
            this.Bt_Test.Dock = System.Windows.Forms.DockStyle.Top;
            this.Bt_Test.FlatAppearance.BorderSize = 0;
            this.Bt_Test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Test.Location = new System.Drawing.Point(0, 114);
            this.Bt_Test.Name = "Bt_Test";
            this.Bt_Test.Size = new System.Drawing.Size(250, 57);
            this.Bt_Test.TabIndex = 2;
            this.Bt_Test.Text = "수동 제어";
            this.Bt_Test.UseVisualStyleBackColor = true;
            this.Bt_Test.Click += new System.EventHandler(this.Bt_Test_Click);
            // 
            // Bt_Control
            // 
            this.Bt_Control.Dock = System.Windows.Forms.DockStyle.Top;
            this.Bt_Control.FlatAppearance.BorderSize = 0;
            this.Bt_Control.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Control.Location = new System.Drawing.Point(0, 57);
            this.Bt_Control.Name = "Bt_Control";
            this.Bt_Control.Size = new System.Drawing.Size(250, 57);
            this.Bt_Control.TabIndex = 1;
            this.Bt_Control.Text = "제어";
            this.Bt_Control.UseVisualStyleBackColor = true;
            this.Bt_Control.Click += new System.EventHandler(this.Bt_Control_Click);
            // 
            // Bt_Main
            // 
            this.Bt_Main.Dock = System.Windows.Forms.DockStyle.Top;
            this.Bt_Main.FlatAppearance.BorderSize = 0;
            this.Bt_Main.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Main.Location = new System.Drawing.Point(0, 0);
            this.Bt_Main.Name = "Bt_Main";
            this.Bt_Main.Size = new System.Drawing.Size(250, 57);
            this.Bt_Main.TabIndex = 0;
            this.Bt_Main.Text = "메인";
            this.Bt_Main.UseVisualStyleBackColor = true;
            this.Bt_Main.Click += new System.EventHandler(this.Bt_Main_Click);
            // 
            // Pn_Main
            // 
            this.Pn_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pn_Main.Location = new System.Drawing.Point(250, 50);
            this.Pn_Main.Name = "Pn_Main";
            this.Pn_Main.Size = new System.Drawing.Size(924, 594);
            this.Pn_Main.TabIndex = 2;
            // 
            // Fm_Frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1174, 644);
            this.Controls.Add(this.Pn_Main);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Fm_Frame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fm_Frame";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel Pn_Main;
        private System.Windows.Forms.Button Bt_Main;
        private System.Windows.Forms.Button Bt_Static;
        private System.Windows.Forms.Button Bt_Test;
        private System.Windows.Forms.Button Bt_Control;
        private System.Windows.Forms.Button Bt_User;
        private System.Windows.Forms.Button Bt_Close;
        private System.Windows.Forms.Button Bt_Zoom;
    }
}
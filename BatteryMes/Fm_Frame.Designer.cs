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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fm_Frame));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Bt_Zoom = new System.Windows.Forms.Button();
            this.Bt_Close = new System.Windows.Forms.Button();
            this.Pn_Main = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Bt_Test = new System.Windows.Forms.Button();
            this.Bt_Control = new System.Windows.Forms.Button();
            this.Bt_Static = new System.Windows.Forms.Button();
            this.Bt_Main = new System.Windows.Forms.Button();
            this.Bt_User = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.Bt_Zoom);
            this.panel1.Controls.Add(this.Bt_Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1329, 40);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Bt_Zoom
            // 
            this.Bt_Zoom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Bt_Zoom.BackgroundImage")));
            this.Bt_Zoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_Zoom.Dock = System.Windows.Forms.DockStyle.Right;
            this.Bt_Zoom.FlatAppearance.BorderSize = 0;
            this.Bt_Zoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Zoom.Location = new System.Drawing.Point(1259, 0);
            this.Bt_Zoom.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.Bt_Zoom.Name = "Bt_Zoom";
            this.Bt_Zoom.Size = new System.Drawing.Size(30, 40);
            this.Bt_Zoom.TabIndex = 1;
            this.Bt_Zoom.UseVisualStyleBackColor = true;
            this.Bt_Zoom.Click += new System.EventHandler(this.Bt_Zoom_Click);
            // 
            // Bt_Close
            // 
            this.Bt_Close.BackgroundImage = global::BatteryMes.Properties.Resources.close;
            this.Bt_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.Bt_Close.FlatAppearance.BorderSize = 0;
            this.Bt_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Close.Location = new System.Drawing.Point(1289, 0);
            this.Bt_Close.Name = "Bt_Close";
            this.Bt_Close.Padding = new System.Windows.Forms.Padding(3);
            this.Bt_Close.Size = new System.Drawing.Size(40, 40);
            this.Bt_Close.TabIndex = 0;
            this.Bt_Close.UseVisualStyleBackColor = true;
            this.Bt_Close.Click += new System.EventHandler(this.Bt_Close_Click);
            // 
            // Pn_Main
            // 
            this.Pn_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pn_Main.Location = new System.Drawing.Point(202, 3);
            this.Pn_Main.Name = "Pn_Main";
            this.Pn_Main.Size = new System.Drawing.Size(1124, 754);
            this.Pn_Main.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1329, 800);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel3.Controls.Add(this.Pn_Main, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1329, 760);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // Bt_Test
            // 
            this.Bt_Test.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bt_Test.FlatAppearance.BorderSize = 0;
            this.Bt_Test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Test.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Test.ForeColor = System.Drawing.Color.White;
            this.Bt_Test.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bt_Test.Location = new System.Drawing.Point(3, 187);
            this.Bt_Test.Name = "Bt_Test";
            this.Bt_Test.Size = new System.Drawing.Size(193, 66);
            this.Bt_Test.TabIndex = 2;
            this.Bt_Test.Text = "수동 제어";
            this.Bt_Test.UseVisualStyleBackColor = true;
            this.Bt_Test.Click += new System.EventHandler(this.Bt_Test_Click);
            // 
            // Bt_Control
            // 
            this.Bt_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bt_Control.FlatAppearance.BorderSize = 0;
            this.Bt_Control.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Control.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Control.ForeColor = System.Drawing.Color.White;
            this.Bt_Control.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bt_Control.Location = new System.Drawing.Point(3, 115);
            this.Bt_Control.Name = "Bt_Control";
            this.Bt_Control.Size = new System.Drawing.Size(193, 66);
            this.Bt_Control.TabIndex = 1;
            this.Bt_Control.Text = "제어";
            this.Bt_Control.UseVisualStyleBackColor = true;
            this.Bt_Control.Click += new System.EventHandler(this.Bt_Control_Click);
            // 
            // Bt_Static
            // 
            this.Bt_Static.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bt_Static.FlatAppearance.BorderSize = 0;
            this.Bt_Static.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Static.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Static.ForeColor = System.Drawing.Color.White;
            this.Bt_Static.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bt_Static.Location = new System.Drawing.Point(3, 259);
            this.Bt_Static.Name = "Bt_Static";
            this.Bt_Static.Size = new System.Drawing.Size(193, 66);
            this.Bt_Static.TabIndex = 3;
            this.Bt_Static.Text = "통계";
            this.Bt_Static.UseVisualStyleBackColor = true;
            this.Bt_Static.Click += new System.EventHandler(this.Bt_Static_Click);
            // 
            // Bt_Main
            // 
            this.Bt_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bt_Main.FlatAppearance.BorderSize = 0;
            this.Bt_Main.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Main.ForeColor = System.Drawing.Color.White;
            this.Bt_Main.Location = new System.Drawing.Point(3, 43);
            this.Bt_Main.Name = "Bt_Main";
            this.Bt_Main.Size = new System.Drawing.Size(193, 66);
            this.Bt_Main.TabIndex = 0;
            this.Bt_Main.Text = "메인";
            this.Bt_Main.UseVisualStyleBackColor = true;
            this.Bt_Main.Click += new System.EventHandler(this.Bt_Main_Click);
            // 
            // Bt_User
            // 
            this.Bt_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bt_User.FlatAppearance.BorderSize = 0;
            this.Bt_User.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bt_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_User.ForeColor = System.Drawing.Color.White;
            this.Bt_User.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Bt_User.Location = new System.Drawing.Point(3, 331);
            this.Bt_User.Name = "Bt_User";
            this.Bt_User.Size = new System.Drawing.Size(193, 66);
            this.Bt_User.TabIndex = 4;
            this.Bt_User.Text = "직원관리";
            this.Bt_User.UseVisualStyleBackColor = true;
            this.Bt_User.Click += new System.EventHandler(this.Bt_User_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Bt_User, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.Bt_Main, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Bt_Static, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.Bt_Control, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.Bt_Test, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(199, 760);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // Fm_Frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1329, 800);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Fm_Frame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fm_Frame";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Pn_Main;
        private System.Windows.Forms.Button Bt_Close;
        private System.Windows.Forms.Button Bt_Zoom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button Bt_User;
        private System.Windows.Forms.Button Bt_Main;
        private System.Windows.Forms.Button Bt_Static;
        private System.Windows.Forms.Button Bt_Control;
        private System.Windows.Forms.Button Bt_Test;
    }
}
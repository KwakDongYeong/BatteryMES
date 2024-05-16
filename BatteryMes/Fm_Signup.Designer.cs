namespace BatteryMes
{
    partial class Fm_Signup
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Cb_Position = new System.Windows.Forms.ComboBox();
            this.Lb_Position = new System.Windows.Forms.Label();
            this.Cb_Deparment = new System.Windows.Forms.ComboBox();
            this.Lb_department = new System.Windows.Forms.Label();
            this.Lb_Pw = new System.Windows.Forms.Label();
            this.Tb_Pw = new System.Windows.Forms.TextBox();
            this.Lb_Id = new System.Windows.Forms.Label();
            this.Tb_Id = new System.Windows.Forms.TextBox();
            this.Lb_name = new System.Windows.Forms.Label();
            this.Tb_Name = new System.Windows.Forms.TextBox();
            this.Bt_Sign = new System.Windows.Forms.Button();
            this.Bt_Close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Lb_Title = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(348, 449);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Cb_Position);
            this.panel1.Controls.Add(this.Lb_Position);
            this.panel1.Controls.Add(this.Cb_Deparment);
            this.panel1.Controls.Add(this.Lb_department);
            this.panel1.Controls.Add(this.Lb_Pw);
            this.panel1.Controls.Add(this.Tb_Pw);
            this.panel1.Controls.Add(this.Lb_Id);
            this.panel1.Controls.Add(this.Tb_Id);
            this.panel1.Controls.Add(this.Lb_name);
            this.panel1.Controls.Add(this.Tb_Name);
            this.panel1.Controls.Add(this.Bt_Sign);
            this.panel1.Controls.Add(this.Bt_Close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 72);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 376);
            this.panel1.TabIndex = 0;
            // 
            // Cb_Position
            // 
            this.Cb_Position.FormattingEnabled = true;
            this.Cb_Position.Items.AddRange(new object[] {
            "사원",
            "대리",
            "부장"});
            this.Cb_Position.Location = new System.Drawing.Point(157, 261);
            this.Cb_Position.Name = "Cb_Position";
            this.Cb_Position.Size = new System.Drawing.Size(121, 23);
            this.Cb_Position.TabIndex = 23;
            // 
            // Lb_Position
            // 
            this.Lb_Position.AutoSize = true;
            this.Lb_Position.Location = new System.Drawing.Point(92, 264);
            this.Lb_Position.Name = "Lb_Position";
            this.Lb_Position.Size = new System.Drawing.Size(47, 15);
            this.Lb_Position.TabIndex = 22;
            this.Lb_Position.Text = "직책 :";
            // 
            // Cb_Deparment
            // 
            this.Cb_Deparment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_Deparment.FormattingEnabled = true;
            this.Cb_Deparment.Items.AddRange(new object[] {
            "생산팀",
            "인사팀",
            "품질관리팀"});
            this.Cb_Deparment.Location = new System.Drawing.Point(157, 208);
            this.Cb_Deparment.Name = "Cb_Deparment";
            this.Cb_Deparment.Size = new System.Drawing.Size(121, 23);
            this.Cb_Deparment.TabIndex = 21;
            // 
            // Lb_department
            // 
            this.Lb_department.AutoSize = true;
            this.Lb_department.Location = new System.Drawing.Point(92, 208);
            this.Lb_department.Name = "Lb_department";
            this.Lb_department.Size = new System.Drawing.Size(47, 15);
            this.Lb_department.TabIndex = 20;
            this.Lb_department.Text = "부서 :";
            // 
            // Lb_Pw
            // 
            this.Lb_Pw.AutoSize = true;
            this.Lb_Pw.Location = new System.Drawing.Point(92, 151);
            this.Lb_Pw.Name = "Lb_Pw";
            this.Lb_Pw.Size = new System.Drawing.Size(41, 15);
            this.Lb_Pw.TabIndex = 19;
            this.Lb_Pw.Text = "PW :";
            // 
            // Tb_Pw
            // 
            this.Tb_Pw.Location = new System.Drawing.Point(157, 141);
            this.Tb_Pw.Name = "Tb_Pw";
            this.Tb_Pw.Size = new System.Drawing.Size(127, 25);
            this.Tb_Pw.TabIndex = 18;
            // 
            // Lb_Id
            // 
            this.Lb_Id.AutoSize = true;
            this.Lb_Id.Location = new System.Drawing.Point(92, 86);
            this.Lb_Id.Name = "Lb_Id";
            this.Lb_Id.Size = new System.Drawing.Size(30, 15);
            this.Lb_Id.TabIndex = 17;
            this.Lb_Id.Text = "ID :";
            // 
            // Tb_Id
            // 
            this.Tb_Id.Location = new System.Drawing.Point(157, 83);
            this.Tb_Id.Name = "Tb_Id";
            this.Tb_Id.Size = new System.Drawing.Size(127, 25);
            this.Tb_Id.TabIndex = 16;
            // 
            // Lb_name
            // 
            this.Lb_name.AutoSize = true;
            this.Lb_name.Location = new System.Drawing.Point(61, 36);
            this.Lb_name.Name = "Lb_name";
            this.Lb_name.Size = new System.Drawing.Size(47, 15);
            this.Lb_name.TabIndex = 15;
            this.Lb_name.Text = "이름 :";
            // 
            // Tb_Name
            // 
            this.Tb_Name.Location = new System.Drawing.Point(157, 36);
            this.Tb_Name.Name = "Tb_Name";
            this.Tb_Name.Size = new System.Drawing.Size(127, 25);
            this.Tb_Name.TabIndex = 14;
            // 
            // Bt_Sign
            // 
            this.Bt_Sign.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Bt_Sign.Location = new System.Drawing.Point(53, 301);
            this.Bt_Sign.Name = "Bt_Sign";
            this.Bt_Sign.Size = new System.Drawing.Size(105, 39);
            this.Bt_Sign.TabIndex = 13;
            this.Bt_Sign.Text = "등록";
            this.Bt_Sign.UseVisualStyleBackColor = false;
            this.Bt_Sign.Click += new System.EventHandler(this.Bt_Sign_Click);
            // 
            // Bt_Close
            // 
            this.Bt_Close.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Bt_Close.Location = new System.Drawing.Point(202, 301);
            this.Bt_Close.Name = "Bt_Close";
            this.Bt_Close.Size = new System.Drawing.Size(105, 39);
            this.Bt_Close.TabIndex = 12;
            this.Bt_Close.Text = "닫기";
            this.Bt_Close.UseVisualStyleBackColor = false;
            this.Bt_Close.Click += new System.EventHandler(this.Bt_Close_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Lb_Title);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 70);
            this.panel2.TabIndex = 1;
            // 
            // Lb_Title
            // 
            this.Lb_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lb_Title.AutoSize = true;
            this.Lb_Title.Font = new System.Drawing.Font("굴림", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lb_Title.Location = new System.Drawing.Point(73, 16);
            this.Lb_Title.Name = "Lb_Title";
            this.Lb_Title.Size = new System.Drawing.Size(220, 37);
            this.Lb_Title.TabIndex = 24;
            this.Lb_Title.Text = "사용자 등록";
            this.Lb_Title.Click += new System.EventHandler(this.Lb_Title_Click);
            // 
            // Fm_Signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 449);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Fm_Signup";
            this.Text = "Fm_Signup";
            this.Load += new System.EventHandler(this.Fm_Signup_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox Cb_Position;
        private System.Windows.Forms.Label Lb_Position;
        private System.Windows.Forms.ComboBox Cb_Deparment;
        private System.Windows.Forms.Label Lb_department;
        private System.Windows.Forms.Label Lb_Pw;
        private System.Windows.Forms.TextBox Tb_Pw;
        private System.Windows.Forms.Label Lb_Id;
        private System.Windows.Forms.TextBox Tb_Id;
        private System.Windows.Forms.Label Lb_name;
        private System.Windows.Forms.TextBox Tb_Name;
        private System.Windows.Forms.Button Bt_Sign;
        private System.Windows.Forms.Button Bt_Close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Lb_Title;
    }
}
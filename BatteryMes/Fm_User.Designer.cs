namespace BatteryMes
{
    partial class Fm_User
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.Gv_user = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userpw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Bt_Re = new System.Windows.Forms.Button();
            this.Bt_change = new System.Windows.Forms.Button();
            this.Bt_Signup = new System.Windows.Forms.Button();
            this.Bt_Delete = new System.Windows.Forms.Button();
            this.Bt_Search = new System.Windows.Forms.Button();
            this.Tb_Search = new System.Windows.Forms.TextBox();
            this.Cb_Search = new System.Windows.Forms.ComboBox();
            this.Lb_Search = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gv_user)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1092, 593);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 103);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 487F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 487F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1086, 487);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.Gv_user, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(303, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(780, 481);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // Gv_user
            // 
            this.Gv_user.AllowUserToAddRows = false;
            this.Gv_user.AllowUserToDeleteRows = false;
            this.Gv_user.AllowUserToResizeRows = false;
            this.Gv_user.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Gv_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Gv_user.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.username,
            this.userid,
            this.userpw,
            this.department,
            this.position});
            this.Gv_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gv_user.Location = new System.Drawing.Point(3, 153);
            this.Gv_user.MultiSelect = false;
            this.Gv_user.Name = "Gv_user";
            this.Gv_user.RowHeadersWidth = 51;
            this.Gv_user.RowTemplate.Height = 27;
            this.Gv_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Gv_user.Size = new System.Drawing.Size(774, 325);
            this.Gv_user.TabIndex = 0;
            // 
            // CheckBox
            // 
            this.CheckBox.FillWeight = 15F;
            this.CheckBox.HeaderText = "";
            this.CheckBox.MinimumWidth = 15;
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // username
            // 
            this.username.DataPropertyName = "name";
            this.username.FillWeight = 71.24693F;
            this.username.HeaderText = "이름";
            this.username.MinimumWidth = 6;
            this.username.Name = "username";
            this.username.ReadOnly = true;
            this.username.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // userid
            // 
            this.userid.DataPropertyName = "id";
            this.userid.FillWeight = 71.24693F;
            this.userid.HeaderText = "ID";
            this.userid.MinimumWidth = 6;
            this.userid.Name = "userid";
            this.userid.ReadOnly = true;
            // 
            // userpw
            // 
            this.userpw.DataPropertyName = "pw";
            this.userpw.FillWeight = 71.24693F;
            this.userpw.HeaderText = "PW";
            this.userpw.MinimumWidth = 6;
            this.userpw.Name = "userpw";
            this.userpw.ReadOnly = true;
            // 
            // department
            // 
            this.department.DataPropertyName = "department";
            this.department.FillWeight = 71.24693F;
            this.department.HeaderText = "부서";
            this.department.MinimumWidth = 6;
            this.department.Name = "department";
            this.department.ReadOnly = true;
            // 
            // position
            // 
            this.position.DataPropertyName = "position";
            this.position.FillWeight = 71.24693F;
            this.position.HeaderText = "직책";
            this.position.MinimumWidth = 6;
            this.position.Name = "position";
            this.position.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Bt_Re);
            this.panel3.Controls.Add(this.Bt_change);
            this.panel3.Controls.Add(this.Bt_Signup);
            this.panel3.Controls.Add(this.Bt_Delete);
            this.panel3.Controls.Add(this.Bt_Search);
            this.panel3.Controls.Add(this.Tb_Search);
            this.panel3.Controls.Add(this.Cb_Search);
            this.panel3.Controls.Add(this.Lb_Search);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(774, 144);
            this.panel3.TabIndex = 1;
            // 
            // Bt_Re
            // 
            this.Bt_Re.Location = new System.Drawing.Point(433, 75);
            this.Bt_Re.Name = "Bt_Re";
            this.Bt_Re.Size = new System.Drawing.Size(75, 27);
            this.Bt_Re.TabIndex = 7;
            this.Bt_Re.Text = "초기화";
            this.Bt_Re.UseVisualStyleBackColor = true;
            this.Bt_Re.Click += new System.EventHandler(this.Bt_Re_Click);
            // 
            // Bt_change
            // 
            this.Bt_change.Location = new System.Drawing.Point(586, 12);
            this.Bt_change.Name = "Bt_change";
            this.Bt_change.Size = new System.Drawing.Size(156, 71);
            this.Bt_change.TabIndex = 6;
            this.Bt_change.Text = "변경기능은 새창 열어서 할지 고민중";
            this.Bt_change.UseVisualStyleBackColor = true;
            // 
            // Bt_Signup
            // 
            this.Bt_Signup.Location = new System.Drawing.Point(597, 110);
            this.Bt_Signup.Name = "Bt_Signup";
            this.Bt_Signup.Size = new System.Drawing.Size(75, 23);
            this.Bt_Signup.TabIndex = 5;
            this.Bt_Signup.Text = "등록";
            this.Bt_Signup.UseVisualStyleBackColor = true;
            this.Bt_Signup.Click += new System.EventHandler(this.Bt_Signup_Click);
            // 
            // Bt_Delete
            // 
            this.Bt_Delete.Location = new System.Drawing.Point(678, 109);
            this.Bt_Delete.Name = "Bt_Delete";
            this.Bt_Delete.Size = new System.Drawing.Size(75, 23);
            this.Bt_Delete.TabIndex = 4;
            this.Bt_Delete.Text = "삭제";
            this.Bt_Delete.UseVisualStyleBackColor = true;
            this.Bt_Delete.Click += new System.EventHandler(this.Bt_Delete_Click);
            // 
            // Bt_Search
            // 
            this.Bt_Search.Location = new System.Drawing.Point(433, 108);
            this.Bt_Search.Name = "Bt_Search";
            this.Bt_Search.Size = new System.Drawing.Size(75, 27);
            this.Bt_Search.TabIndex = 3;
            this.Bt_Search.Text = "조회";
            this.Bt_Search.UseVisualStyleBackColor = true;
            this.Bt_Search.Click += new System.EventHandler(this.Bt_Search_Click);
            // 
            // Tb_Search
            // 
            this.Tb_Search.Location = new System.Drawing.Point(308, 108);
            this.Tb_Search.Name = "Tb_Search";
            this.Tb_Search.Size = new System.Drawing.Size(119, 25);
            this.Tb_Search.TabIndex = 2;
            // 
            // Cb_Search
            // 
            this.Cb_Search.FormattingEnabled = true;
            this.Cb_Search.Items.AddRange(new object[] {
            "이름",
            "ID",
            "PW",
            "부서",
            "직책"});
            this.Cb_Search.Location = new System.Drawing.Point(181, 109);
            this.Cb_Search.Name = "Cb_Search";
            this.Cb_Search.Size = new System.Drawing.Size(121, 23);
            this.Cb_Search.TabIndex = 1;
            // 
            // Lb_Search
            // 
            this.Lb_Search.AutoSize = true;
            this.Lb_Search.Location = new System.Drawing.Point(123, 112);
            this.Lb_Search.Name = "Lb_Search";
            this.Lb_Search.Size = new System.Drawing.Size(37, 15);
            this.Lb_Search.TabIndex = 0;
            this.Lb_Search.Text = "조건";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 481);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "메인이동";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1086, 94);
            this.panel1.TabIndex = 1;
            // 
            // Fm_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 617);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Fm_User";
            this.Text = "Fm_User";
            this.Load += new System.EventHandler(this.Fm_User_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Gv_user)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView Gv_user;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button Bt_Search;
        private System.Windows.Forms.TextBox Tb_Search;
        private System.Windows.Forms.ComboBox Cb_Search;
        private System.Windows.Forms.Label Lb_Search;
        private System.Windows.Forms.Button Bt_Delete;
        private System.Windows.Forms.Button Bt_change;
        private System.Windows.Forms.Button Bt_Signup;
        private System.Windows.Forms.Button Bt_Re;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn userid;
        private System.Windows.Forms.DataGridViewTextBoxColumn userpw;
        private System.Windows.Forms.DataGridViewTextBoxColumn department;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
    }
}
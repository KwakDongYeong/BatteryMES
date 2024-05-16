using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BatteryMes
{
    public partial class Fm_Signup : Form
    {
        public event EventHandler SignupFormClosed;
        public Fm_Signup()
        {
            InitializeComponent();
         //   FormBorderStyle = FormBorderStyle.None;
        }

        private void Fm_Signup_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
        }
        private void Fm_Signup_SignupFormClosed(object sender, EventArgs e)
        {
           // SignupFormClosed?.Invoke(this, EventArgs.Empty);
        }


        private void Bt_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            SignupFormClosed?.Invoke(this, EventArgs.Empty);
        }

  
        private void Lb_Title_Click(object sender, EventArgs e)
        {

        }

        private void Bt_Sign_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Tb_Name.Text) ||
                string.IsNullOrEmpty(Tb_Id.Text) ||
                string.IsNullOrEmpty(Tb_Pw.Text) ||
                (Cb_Deparment.SelectedItem == null) ||
                (Cb_Position.SelectedItem == null))
            {
                MessageBox.Show("모든 항목을 입력하세요.", "필수항목", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                DialogResult result = MessageBox.Show("등록하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                string username = Tb_Name.Text.ToString();
                string password = Tb_Pw.Text.ToString();
                string userid = Tb_Id.Text.ToString();
                string department = Cb_Deparment.SelectedItem.ToString();
                string position = Cb_Position.SelectedItem.ToString();

                if (result == DialogResult.Yes)
                {
                    string userstring = "Server = 10.10.32.238; Database = batterymes; Uid = BatteryMes; Pwd = Battery;";

                    try
                    {

                        using (MySqlConnection connection = new MySqlConnection(userstring))
                        {
                            connection.Open();

                            string checkQuery = "SELECT COUNT(*) FROM user WHERE id = @userid";
                            MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                            checkCommand.Parameters.AddWithValue("@userid", userid);

                            int count = Convert.ToInt32(checkCommand.ExecuteScalar());
                            if (count > 0)
                            {
                                MessageBox.Show("이미 존재하는 ID입니다. 다른 ID를 사용해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                string query = "insert into user (name, id, pw, department, position)" + "VALUES (@username, @userid, @password , @department, @position)";
                                MySqlCommand command = new MySqlCommand(query, connection);
                                command.Parameters.AddWithValue("@username", username);
                                command.Parameters.AddWithValue("@password", password);
                                command.Parameters.AddWithValue("@userid", userid);
                                command.Parameters.AddWithValue("@department", department);
                                command.Parameters.AddWithValue("@position", position);

                                command.ExecuteNonQuery();

                                MessageBox.Show("등록되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // 오류 메시지 표시
                        MessageBox.Show("데이터를 추가하는 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}

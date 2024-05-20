using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // sql 연동을 위함

namespace BatteryMes
{
    public partial class Fm_Login : Form
    {
        public Fm_Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                // 연결 문자열 수정
                string connectionString = "Server=10.10.32.238;Port=3306; Database=BatteryMes; Uid=BatteryMes; Pwd=Battery;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string loginid = id_text.Text;
                string loginpw = pw_text.Text;

                string selectQuery = "SELECT * FROM user WHERE id = @id AND pw = @pw";

                MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@id", loginid);
                selectCommand.Parameters.AddWithValue("@pw", loginpw);

                MySqlDataReader userAccount = selectCommand.ExecuteReader();

                bool loginSuccessful = false;

                while (userAccount.Read())
                {
                    loginSuccessful = true;
                }

                connection.Close();

                if (loginSuccessful)
                {
                    MessageBox.Show("로그인 성공");
                    Fm_Frame frame_Form = new Fm_Frame();
                    frame_Form.Show();
                    this.Hide();
                    frame_Form.FormClosed += (s, args) => this.Close();
                }
                else
                {
                    MessageBox.Show("회원 정보를 확인해 주세요.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}

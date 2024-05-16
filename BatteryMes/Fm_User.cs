using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BatteryMes
{
    public partial class Fm_User : Form
    {
        public Fm_User()
        {
            InitializeComponent();
            LoadUser();
        }

        private void Fm_User_Load(object sender, EventArgs e)
        {
            this.Cb_Search.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

        }

        private void LoadUser()
        {
            MySqlConnection usercon = new MySqlConnection(@"Server=10.10.32.238;Database=batterymes;Uid=BatteryMes;Pwd=Battery;Allow Zero Datetime=True;");

            try
            { 
            usercon.Open();

            string usersql = "select * from user";
            MySqlCommand cmd = new MySqlCommand(usersql, usercon);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Gv_user.DataSource = dt;
            Gv_user.ClearSelection();

            usercon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB 연결 오류: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fm_Main Main = new Fm_Main();
            Main.Show();
        }

        private void Bt_Search_Click(object sender, EventArgs e)
        {
            string connectionString = "Server = 10.10.32.238; Database = batterymes; Uid = BatteryMes; Pwd = Battery;";

            string SelectedCb = Cb_Search.SelectedItem?.ToString();
            string SearchText = Tb_Search.Text;
            if (string.IsNullOrEmpty(SelectedCb))
            {
                MessageBox.Show("검색할 항목을 선택하세요.");
                return;
            }
            if (string.IsNullOrEmpty(SearchText))
            {
                MessageBox.Show("검색할 내용을 입력해주세요.");
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL 쿼리 작성
                    string query = "";
                    switch (SelectedCb)
                    {
                        case "이름":
                            query = "SELECT * FROM user WHERE name LIKE @SearchText";
                            break;
                        case "ID":
                            query = "SELECT * FROM user WHERE id LIKE @SearchText";
                            break;
                        case "PW":
                            query = "SELECT * FROM user WHERE pw LIKE @SearchText";
                            break;
                        case "부서":
                            query = "SELECT * FROM user WHERE department LIKE @SearchText";
                            break;
                        case "직책":
                            query = "SELECT * FROM user WHERE position LIKE @SearchText";
                            break;
                        default:
                            MessageBox.Show("올바르지 않은 선택입니다.");
                            return;
                    }

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SearchText", "%" + SearchText + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    Gv_user.DataSource = dataTable;
                    Gv_user.ClearSelection();

                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("검색 결과가 없습니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB 연결 오류: " + ex.Message);
            }
        }

        private void Bt_Re_Click(object sender, EventArgs e)
        {
            LoadUser();
        }
    }
    
}

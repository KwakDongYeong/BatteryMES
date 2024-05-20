using System;
using System.Collections;
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
            Cb_Search.SelectedIndex = -1;
            Tb_Search.Clear();
        }

        private void Bt_Signup_Click(object sender, EventArgs e)
        {
            Fm_Signup fm_Signup = new Fm_Signup();
              fm_Signup.StartPosition = FormStartPosition.CenterScreen;

           // fm_Signup.StartPosition = FormStartPosition.Manual;
           // fm_Signup.Location = new Point(250, 150);
            fm_Signup.SignupFormClosed += Fm_Signup_SignupFormClosed;
            fm_Signup.ShowDialog();
        }
        private void Fm_Signup_SignupFormClosed(object sender, EventArgs e)
        {
           LoadUser() ;
        }

        private void Bt_Delete_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void DeleteUser()
        {
            int rowsToDelete = 0;
            StringBuilder deletedNames = new StringBuilder();

            foreach (DataGridViewRow row in Gv_user.Rows)
            {
                DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(chk.Value))
                {
                    rowsToDelete++;

                    string name = row.Cells["username"].Value.ToString();
                    deletedNames.Append(name);
                    deletedNames.Append(", ");

                }
            }

            if (rowsToDelete == 0)
            {
                MessageBox.Show("선택된 데이터가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult result = MessageBox.Show("선택한 데이터를 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string connectionString = "Server = 10.10.32.238; Database = batterymes; Uid = BatteryMes; Pwd = Battery;";
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        for (int i = Gv_user.Rows.Count - 1; i >= 0; i--)
                        {
                            DataGridViewRow row = Gv_user.Rows[i];
                            DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
                            if (Convert.ToBoolean(chk.Value))
                            {
                                string id = row.Cells["userid"].Value.ToString();
                                DeleteRecordFromDatabase(connection, id);
                                Gv_user.Rows.RemoveAt(i);
                            }
                        }

                        // MessageBox.Show(rowsToDelete + "정보가 삭제되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string message = rowsToDelete + "명의 정보가 삭제되었습니다.\n삭제된 사용자: " + deletedNames.ToString().TrimEnd(',', ' ');
                        MessageBox.Show(message, "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("삭제 불가: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteRecordFromDatabase(MySqlConnection connection, string id)
        {
            try
            {
                string deletesql = "DELETE FROM user WHERE id = @id";
                MySqlCommand delcommand = new MySqlCommand(deletesql, connection);
                delcommand.Parameters.AddWithValue("@id", id);
                delcommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("삭제 불가" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fm_Test fm_Test = new Fm_Test();
            fm_Test.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}

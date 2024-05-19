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
                MySqlConnection connection = new MySqlConnection("Server = localhost;Database=1;Uid=root;Pwd=0000;");
                // SQL 서버와 연결.
                // Server = localhost : 로컬 호스트 (내 컴퓨터) 서버와 연결
                // Database = login_hjc
                // Uid = 1
                // Pwd = 0000

                connection.Open();
                // SQL 서버 연결

                int login_status = 0;
                // 로그인 상태 변수 선언, 비로그인 상태는 0

                string loginid = id_text.Text;
                // 문자열 loginid 변수는 txtbox_id 의 텍스트값
                string loginpw = pw_text.Text;
                // 문자열 loginpwd 변수는 txtbox_pwd 의 텍스트값

                string selectQuery = "SELECT * FROM account_info WHERE id = \'" + loginid + "\' ";
                // 문자열 selectQuery 변수 선언.
                // MySQL에 전송할 명령어를 입력한다.
                // 실제로 MySQL에 전송될 명령어는 "" 사이의 값.
                // dbtest 스키마의 account_info 테이블 값을 읽기 위해 변수 선언.

                MySqlCommand Selectcommand = new MySqlCommand(selectQuery, connection);
                // MySqlCommand는 MySQL로 명령어를 전송하기 위한 클래스.
                // MySQL에 selectQuery 값을 보내고, connection 값을 보내 연결을 시도한다.
                // 위 정보를 Selectcommand 변수에 저장한다.

                MySqlDataReader userAccount = Selectcommand.ExecuteReader();
                // MySqlDataReader은 입력값을 받기 위함.
                // Selectcommand 변수에 ExecuteReader() 객체를 통해 입력값을 받고,
                // 해당 정보를 userAccount 변수에 저장한다.

                while (userAccount.Read())
                // userAccount가 Read 되고 있을 동안
                {
                    if (loginid == (string)userAccount["id"] && loginpw == (string)userAccount["pw"])
                    // 만약 loginid변수의 값이 account_info 테이블 값의 id 정보와,
                    // loginpwd변수의 값이 account_info 테이블 값의 pwd 정보와 일치한다면
                    {
                        login_status = 1;
                        // 해당 변수 상태를 1로 바꾼다.
                    }
                }
                connection.Close();
                // MySQL과 연결을 끊는다.

                if (login_status == 1)
                // 만약 해당 변수 상태가 1이라면,
                {
                    MessageBox.Show("로그인 성공");
                    // 로그인 완료 메시지박스를 띄운다.
                    Fm_Frame frame_Form = new Fm_Frame();

                    // fm_main 폼을 표시합니다.
                    frame_Form.Show();

                    // 현재 fm_login 폼을 숨깁니다. (또는 닫을 수도 있습니다.)
                    this.Hide();

                    // fm_main 폼이 닫힐 때 현재 애플리케이션을 종료하기 위해 이벤트 핸들러를 추가합니다.
                    frame_Form.FormClosed += (s, args) => this.Close();
                }
                else
                // 아니라면,
                {
                    MessageBox.Show("회원 정보를 확인해 주세요.");
                    // 오류 메시지박스를 띄운다.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // 예외값 발생 시 해당 정보와 관련된 메시지박스를 띄운다.
            }
            

        }
    }
}

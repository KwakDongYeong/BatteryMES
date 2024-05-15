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
    public partial class Fm_User : Form
    {
        public Fm_User()
        {
            InitializeComponent();
            LoadUser();
        }

        private void Fm_User_Load(object sender, EventArgs e)
        {
            MySqlConnection usercon = new MySqlConnection(@"Server=localhost;Database=batterymes;Uid=root;Pwd=kwak123;Allow Zero Datetime=True;");

            usercon.Open();

            string usersql = "select * from user";
            MySqlCommand cmd = new MySqlCommand(usersql,usercon);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);   
            Gv_user.DataSource = dt;


            usercon.Close();

        }

        private void LoadUser()
        { 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fm_Main Main = new Fm_Main();
            Main.Show();
        }
    }
}

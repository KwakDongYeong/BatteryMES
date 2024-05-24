using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActUtlTypeLib;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient; // SQL 연동을 위함

namespace BatteryMes
{
    public partial class Fm_Test : Form
    {
        public ActUtlType plc = new ActUtlType();
        private Timer timer = new Timer();
        private FileSystemWatcher watcher;
        private string imageFolderPath = @"C:\Users\user\Desktop\비전결과";
        private string connectionString = "Server=localhost;Port=3306;Database=login_hjc;Uid=root;Pwd=0000;";
        //private string connectionString = "Server = 10.10.32.238; Database=batterymes; Uid=BatteryMes;Pwd=Battery;";

        public Fm_Test()
        {
            InitializeComponent();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            timer.Start();
            this.DoubleBuffered = true;
        }

        private void Fm_Test_Load(object sender, EventArgs e)
        {
            InitializePictureBoxes();
            plc.ActLogicalStationNumber = 1;
            plc.Open();
            LightOn();

            SetupFileSystemWatcher();
            UploadAllImagesToDatabase();

            visionpicture.SizeMode = PictureBoxSizeMode.StretchImage;

            // MySQL 연결 및 이미지 업로드
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("데이터베이스 연결 성공!");

                    // 폴더 내의 모든 이미지 파일을 처리
                    foreach (string filePath in Directory.GetFiles(imageFolderPath, "*.jpg"))
                    {
                        UploadImage(filePath, conn);
                    }

                    conn.Close();
                    //MessageBox.Show("All images uploaded successfully.");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CheckPLCSignal();
            LightOn();
        }

        private void LightOn()
        {
            for (int i = 0; i <= 9; i++)
            {
                int value;
                string deviceName = "X" + i;
                plc.GetDevice(deviceName, out value);

                switch (i)
                {
                    case 0:
                        Pb_Trayon.Image = (value == 0) ? Properties.Resources.제목_없음 : Properties.Resources._1;
                        break;
                    case 1:
                        Pb_TrayOff.Image = (value == 0) ? Properties.Resources.제목_없음 : Properties.Resources._1;
                        break;
                    case 2:
                        Pb_Left.Image = (value == 0) ? Properties.Resources.제목_없음 : Properties.Resources._1;
                        break;
                    case 3:
                        Pb_Right.Image = (value == 0) ? Properties.Resources.제목_없음 : Properties.Resources._1;
                        break;
                    case 4:
                        Pb_ForkOn.Image = (value == 0) ? Properties.Resources.제목_없음 : Properties.Resources._1;
                        break;
                    case 5:
                        Pb_ForkOff.Image = (value == 0) ? Properties.Resources.제목_없음 : Properties.Resources._1;
                        break;
                    case 6:
                        Pb_Fork.Image = (value == 0) ? Properties.Resources.제목_없음 : Properties.Resources._1;
                        break;
                    case 7:
                        Pb_ST1_1.Image = (value == 0) ? Properties.Resources.제목_없음 : Properties.Resources._1;
                        break;
                    case 8:
                        Pb_ST1_2.Image = (value == 0) ? Properties.Resources.제목_없음 : Properties.Resources._1;
                        break;
                    case 9:
                        Pb_ST1_3.Image = (value == 0) ? Properties.Resources.제목_없음 : Properties.Resources._1;
                        break;
                }
            }

            string[] deviceNames = { "X0A", "X0B", "X0C", "X0D" };

            foreach (string deviceName in deviceNames)
            {
                int value;
                plc.GetDevice(deviceName, out value);

                switch (deviceName)
                {
                    case "X0A":
                        Pb_ST2_1.Image = (value == 0) ? Properties.Resources.제목_없음 : Properties.Resources._1;
                        break;
                    case "X0B":
                        Pb_ST2_2.Image = (value == 0) ? Properties.Resources.제목_없음 : Properties.Resources._1;
                        break;
                    case "X0C":
                        Pb_ST2_3.Image = (value == 0) ? Properties.Resources.제목_없음 : Properties.Resources._1;
                        break;
                    case "X0D":
                        Pb_ST2_4.Image = (value == 0) ? Properties.Resources.제목_없음 : Properties.Resources._1;
                        break;
                }
            }
        }

        private void SetupFileSystemWatcher()
        {
            watcher = new FileSystemWatcher
            {
                Path = imageFolderPath,
                Filter = "*.jpg",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
            };

            watcher.Created += OnNewImageCreated;
            watcher.EnableRaisingEvents = true;
        }

        private void OnNewImageCreated(object sender, FileSystemEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => OnNewImageCreated(sender, e)));
            }
            else
            {
                LoadImageToPictureBox(e.FullPath);
                UploadImageToDatabase(e.FullPath); // 이미지 업로드 추가
            }
        }

        private void UploadImageToDatabase(string filePath)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    UploadImage(filePath, conn);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void LoadImageToPictureBox(string imagePath)
        {
            try
            {
                visionpicture.Image = Image.FromFile(imagePath); // Pb_NewImage는 PictureBox의 이름입니다.
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Failed to load image: {ex.Message}");
            }
        }

        private void CheckPLCSignal()
        {
            int value;
            plc.GetDevice("Y20", out value); // 비전카메라 부분 포토센서값 넣기

            if (value == 1) // 비전카메라 부분 포토센서 신호가 켜졌을 때
            {
                string latestImagePath = GetLatestImagePath();
                if (latestImagePath != null)
                {
                    LoadImageToPictureBox(latestImagePath);
                }
            }
        }

        private string GetLatestImagePath()
        {
            var directoryInfo = new DirectoryInfo(imageFolderPath);
            var file = directoryInfo.GetFiles("*.jpg")
                                    .OrderByDescending(f => f.LastWriteTime)
                                    .FirstOrDefault();
            return file?.FullName;
        }

        private void UploadAllImagesToDatabase()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("데이터베이스 연결 성공!");

                    foreach (string filePath in Directory.GetFiles(imageFolderPath, "*.jpg"))
                    {
                        UploadImage(filePath, conn);
                    }

                    conn.Close();
                    Console.WriteLine("All images uploaded successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        static void UploadImage(string filePath, MySqlConnection conn)
        {
            try
            {
                string imageName = Path.GetFileName(filePath);

                // 이미지 이름 중복 확인
                string checkQuery = "SELECT COUNT(*) FROM images WHERE ImageName = @imageName";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@imageName", imageName);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        return; // 이미지 이름이 중복되면 업로드하지 않음
                    }
                }

                // 이미지 파일 데이터를 읽습니다.
                byte[] imageData = File.ReadAllBytes(filePath);

                // 이미지 업로드 쿼리
                string uploadQuery = "INSERT INTO images (ImageName, ImageData) VALUES (@imageName, @imageData)";
                using (MySqlCommand uploadCmd = new MySqlCommand(uploadQuery, conn))
                {
                    uploadCmd.Parameters.AddWithValue("@imageName", imageName);
                    uploadCmd.Parameters.AddWithValue("@imageData", imageData);

                    uploadCmd.ExecuteNonQuery();
                    Console.WriteLine($"Image {imageName} uploaded successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while uploading {filePath}: " + ex.Message);
            }
        }

        private void InitializePictureBoxes()
        {
            Pb_Trayon.SizeMode = PictureBoxSizeMode.Zoom;
            Pb_TrayOff.SizeMode = PictureBoxSizeMode.Zoom;
            Pb_ForkOn.SizeMode = PictureBoxSizeMode.Zoom;
            Pb_ForkOff.SizeMode = PictureBoxSizeMode.Zoom;
            Pb_Fork.SizeMode = PictureBoxSizeMode.Zoom;
            Pb_Right.SizeMode = PictureBoxSizeMode.Zoom;
            Pb_Left.SizeMode = PictureBoxSizeMode.Zoom;
            Pb_ST1_1.SizeMode = PictureBoxSizeMode.Zoom;
            Pb_ST1_2.SizeMode = PictureBoxSizeMode.Zoom;
            Pb_ST1_3.SizeMode = PictureBoxSizeMode.Zoom;
            Pb_ST2_1.SizeMode = PictureBoxSizeMode.Zoom;
            Pb_ST2_2.SizeMode = PictureBoxSizeMode.Zoom;
            Pb_ST2_3.SizeMode = PictureBoxSizeMode.Zoom;
            Pb_ST2_4.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Bt_Tray_On_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M1", 1);
        }

        private void Bt_Tray_On_MouseDown(object sender, MouseEventArgs e)
        {
            Bt_Tray_On.BackgroundImageLayout = ImageLayout.Stretch;
            // Bt_Tray_On.BackgroundImage = Properties.Resources.Button2;
        }

        private void Bt_Tray_On_MouseUp(object sender, MouseEventArgs e)
        {
            Bt_Tray_On.BackgroundImageLayout = ImageLayout.Stretch;
            // Bt_Tray_On.BackgroundImage = Properties.Resources.Button1;
        }

        private void BT_Tray_OFF_Click(object sender, EventArgs e)
        {
            plc.SetDevice("M1", 0);
        }

        private void BT_Tray_OFF_MouseDown(object sender, MouseEventArgs e)
        {
            BT_Tray_OFF.BackgroundImageLayout = ImageLayout.Stretch;
            // BT_Tray_OFF.BackgroundImage = Properties.Resources.Button2;
        }

        private void BT_Tray_OFF_MouseUp(object sender, MouseEventArgs e)
        {
            BT_Tray_OFF.BackgroundImageLayout = ImageLayout.Stretch;
            // BT_Tray_OFF.BackgroundImage = Properties.Resources.Button1;
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

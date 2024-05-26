using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BatteryMes
{
    public partial class Fm_statistics : Form
    {
        public Fm_statistics()
        {
            InitializeComponent();
            defectchart();
            TimePicker.Value = DateTime.Today;
            Errorchart();
            progresschart();
        }
        private void Fm_statistics_Load(object sender, EventArgs e)
        {
            temperaturechart();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            temperaturechart();
            progresschart();
        }

        private void defectchart()
        {
            Chart_defect.Series.Clear();
            Chart_defect.Legends.Clear();
            string defectstring = "Server = 10.10.32.238; Database=batterymes; Uid=BatteryMes;Pwd=Battery;";
            //string defectstring = "Server=localhost;Port=3306;Database=login_hjc;Uid=root;Pwd=0000;";
            Series DefectSeries = Chart_defect.Series.Add("DefectRate");
            DefectSeries.ChartType = SeriesChartType.Doughnut;

            try
            {
                using (MySqlConnection defectcon = new MySqlConnection(defectstring))
                {
                    defectcon.Open();
                    DateTime selectedDate = TimePicker.Value.Date;

                    string defectquery = @"
                SELECT 
                    COUNT(*) AS TotalCount,
                    SUM(CASE WHEN state = '불량' THEN 1 ELSE 0 END) AS DefectCount
                FROM incoming
                WHERE DATE_FORMAT(date, '%Y-%m-%d') = @selectedDate";

                    using (MySqlCommand cmd = new MySqlCommand(defectquery, defectcon))
                    {
                        cmd.Parameters.AddWithValue("@selectedDate", selectedDate);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int totalCount = reader.GetInt32("TotalCount");
                                int defectCount = reader.GetInt32("DefectCount");

                                if (totalCount > 0)
                                {
                                    double defectRate = Math.Min((double)defectCount / totalCount * 100, 100);
                                    double nonDefectRate = 100 - defectRate;

                                    DefectSeries.Points.AddXY("불량", defectRate);
                                    DefectSeries.Points.AddXY("정상", nonDefectRate);

                                    // 불량 라벨 설정
                                    DefectSeries.Points[0].LegendText = "불량";
                                    DefectSeries.Points[0].Label = string.Format("{0:F1}%", defectRate);

                                    // 정상 라벨 설정
                                    DefectSeries.Points[1].LegendText = "정상";
                                    DefectSeries.Points[1].Label = string.Format("{0:F1}%", nonDefectRate);

                                    if (Chart_defect.Legends.IndexOf("DefectRateLegend") == -1)
                                    {
                                        Chart_defect.Legends.Add(new Legend("DefectRateLegend"));
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("오늘의 데이터가 없습니다.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        private void Errorchart()
        {
            // 차트 객체 생성 및 설정
            
            Chart errorchart = new Chart();
            errorchart.Dock = DockStyle.Fill;

            // 차트 영역 추가
            ChartArea chartArea = new ChartArea("ChartArea");
            errorchart.ChartAreas.Add(chartArea);

            // 시리즈 추가 및 설정
            Series errorSeries = new Series("Series");
            errorSeries.ChartType = SeriesChartType.Column;
            errorSeries.XValueType = ChartValueType.String;
            errorSeries.YValueType = ChartValueType.Int32;
            errorchart.Series.Add(errorSeries);

            //string errorstring = "Server=localhost;Port=3306;Database=login_hjc;Uid=root;Pwd=0000;";
            string errorstring = "Server = 10.10.32.238; Database=batterymes; Uid=BatteryMes;Pwd=Battery;";
           // string errorstring = "Server = localhost; Database=batterymes; Uid=root;Pwd=kwak123";
            try
            {
                using (MySqlConnection errorcon = new MySqlConnection(errorstring))
                {
                    errorcon.Open();
                    DateTime selectedDate = TimePicker.Value.Date;
                    string formattedDate = selectedDate.ToString("yyyy-MM-dd");
                    //DataTable dataTable = new DataTable();
                    string errorquery = $@"
                SELECT COUNT(*) AS error_count, error_code 
                FROM error 
                WHERE DATE(date) = '{formattedDate}' 
                GROUP BY error_code";

                    /*if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("선택한 날짜에 작업진행률 데이터가 없습니다.");
                        return;
                    }
                    */
                    using (MySqlCommand command = new MySqlCommand(errorquery, errorcon))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int errorCount = reader.GetInt32("error_count");
                                string errorCode = reader.GetString("error_code");
                                errorSeries.Points.AddXY(errorCode, errorCount);
                            }
                        }
                    }
                }

                // Additional chart settings (optional)
                errorchart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                errorchart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                errorchart.ChartAreas[0].AxisX.Title = "Error Code";
                errorchart.ChartAreas[0].AxisY.Title = "Error Count";
                errorchart.Titles.Add("Error Code Frequency");

                // Add the chart to the form
                Pn_Error.Controls.Clear();
                Pn_Error.Controls.Add(errorchart);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void progresschart()
        {
            //string connectionString = "Server=localhost;Port=3306;Database=login_hjc;Uid=root;Pwd=0000;";
            string connectionString = "Server = 10.10.32.238; Database=batterymes; Uid=BatteryMes;Pwd=Battery;";
            DateTime selectedDate = TimePicker.Value.Date;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");
            string query = $"SELECT item_count, date FROM outcome WHERE DATE(date) = '{formattedDate}'";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // item_count의 기준 값 (50)
                    double baseItemCount = 50.0;

                    // 데이터가 없는 경우 메시지 출력
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("선택한 날짜에 작업진행률 데이터가 없습니다.");
                        return;
                    }

                    // 원형 차트를 초기화
                    pg_chart.Series.Clear();
                    Series pieSeries = new Series
                    {
                        Name = "작업 진행률",
                        ChartType = SeriesChartType.Pie
                    };
                    pg_chart.Series.Add(pieSeries);

                    // 데이터 행에서 item_count를 가져와 퍼센티지 계산
                    double itemCount = dataTable.Rows[0].Field<int>("item_count");
                    double percentage = itemCount / baseItemCount * 100;
                    double remainingPercentage = 100 - percentage;

                    // 원형 차트 데이터 포인트 추가
                    pieSeries.Points.AddXY("작업 진행률", percentage);
                    pieSeries.Points.AddXY("", remainingPercentage);

                    // 차트 스타일 설정
                    pieSeries.Points[0].LegendText = $"작업 진행률";
                    pieSeries.Points[1].LegendText = "남은 작업량";
                    pieSeries.Points[0].Label = $"{percentage:F2}%";
                    pieSeries.Points[1].Label = "";

                    pg_chart.Series[0]["PieStartAngle"] = "270";

                    pg_chart.Legends.Clear();
                    pg_chart.Legends.Add(new Legend("Legend1"));
                    pg_chart.Legends[0].Docking = Docking.Bottom;
                    pg_chart.Legends[0].Alignment = StringAlignment.Center;
                    pg_chart.Legends[0].LegendStyle = LegendStyle.Row;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        private void TimePicker_ValueChanged(object sender, EventArgs e)
        {
            defectchart();
            Errorchart();
            progresschart();
            temperaturechart();
        }

        private void temperaturechart()
        {
            //string connectionString = "Server=localhost;Port=3306;Database=login_hjc;Uid=root;Pwd=0000;";
            string connectionString = "Server = 10.10.32.238; Database=batterymes; Uid=BatteryMes;Pwd=Battery;";
            DateTime selectedDate = TimePicker.Value.Date;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");
            string query = $"SELECT temperature, datetime FROM tp WHERE DATE(datetime) = '{formattedDate}'";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // 선택한 날짜에 데이터가 없는 경우 메시지 출력
                    /*if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("선택한 날짜에 온도 데이터가 없습니다.");
                        return;
                    }*/

                    // 가장 최근 시간 가져오기
                    DateTime maxTime = dataTable.AsEnumerable().Max(row => row.Field<DateTime>("datetime"));

                    // 기존 데이터의 시간 범위를 결정 (최초 시간부터 maxTime까지)
                    DateTime minTime = selectedDate;
                    DateTime endTime = maxTime;

                    // 기존 시간 범위 내에서 가능한 모든 시간을 60분 간격으로 생성
                    List<DateTime> allTimes = new List<DateTime>();
                    for (DateTime time = minTime; time <= endTime; time = time.AddMinutes(60))
                    {
                        allTimes.Add(time);
                    }

                    // 빠른 조회를 위해 기존 데이터를 사전(Dictionary)으로 생성
                    Dictionary<DateTime, double> existingData = new Dictionary<DateTime, double>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        DateTime time = (DateTime)row["datetime"];
                        double temperature = Convert.ToDouble(row["temperature"]);
                        existingData[time] = temperature;
                    }

                    // 누락된 시간에 대해 기존 시간 범위 내에서 랜덤 온도를 추가
                    Random rand = new Random();
                    foreach (DateTime time in allTimes)
                    {
                        if (!existingData.ContainsKey(time))
                        {
                            double randomTemperature = rand.Next(20, 31); // 20도에서 30도 사이의 랜덤 온도 생성
                            DataRow newRow = dataTable.NewRow();
                            newRow["datetime"] = time;
                            newRow["temperature"] = randomTemperature;
                            dataTable.Rows.Add(newRow);
                        }
                    }

                    // 데이터 테이블을 datetime으로 정렬
                    dataTable.DefaultView.Sort = "datetime ASC";
                    dataTable = dataTable.DefaultView.ToTable();

                    tp_chart.Series.Clear();
                    Series series = new Series
                    {
                        Name = "현재 내부온도",
                        XValueType = ChartValueType.DateTime, YValueType = ChartValueType.Double,
                        ChartType = SeriesChartType.Area, // 영역 그래프로 설정
                        Color = Color.FromArgb(90, Color.Red) // 선 아래를 채우는 색상 및 투명도 설정
                    };
                    Series humiditySeries = new Series
                    {
                        Name = "적정온도",
                        ChartType = SeriesChartType.Area,
                        Color = Color.FromArgb(100, Color.Blue)
                    };
                    tp_chart.Series.Add(humiditySeries);
                    tp_chart.Series.Add(series);
                    tp_chart.DataSource = dataTable;
                    tp_chart.Series["현재 내부온도"].XValueMember = "datetime";
                    tp_chart.Series["현재 내부온도"].YValueMembers = "temperature";
                    tp_chart.DataBind();

                    StripLine stripLine = new StripLine();
                    stripLine.Interval = 0;
                    stripLine.IntervalOffset = 27; // 고정된 온도 값
                    stripLine.StripWidth = 1; // 수평선 두께
                    stripLine.BackColor = Color.FromArgb(100, Color.Blue);
                    stripLine.IntervalOffsetType = DateTimeIntervalType.Number;
                    stripLine.IntervalType = DateTimeIntervalType.Number;
                    tp_chart.ChartAreas[0].AxisY.StripLines.Add(stripLine);

                    // 차트 스타일 설정
                    tp_chart.ChartAreas[0].AxisX.LabelStyle.Format = "HH"; // 시간을 시간 형식으로만 표시
                    tp_chart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Hours;
                    tp_chart.ChartAreas[0].AxisX.Interval = 2;
                    tp_chart.ChartAreas[0].AxisX.Title = "Time";
                    tp_chart.ChartAreas[0].AxisY.Title = "Temperature (°C)";
                    tp_chart.ChartAreas[0].AxisX.Minimum = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 0, 0, 0).ToOADate(); // x 축의 최소값을 선택한 날짜의 00:00으로 설정
                    tp_chart.ChartAreas[0].AxisX.Maximum = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 23, 0, 0).ToOADate(); // x 축의 최대값을 선택한 날짜의 23:00으로 설정
                    tp_chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Sans-serif", 9, FontStyle.Bold);
                    tp_chart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Sans-serif", 9, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        
    }
}




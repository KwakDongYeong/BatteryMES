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
       //     defectchart();
            TimePicker.Value = DateTime.Today;
            Errorchart();
        }

        /*private void defectchart()
        {
            Chart_defect.Series.Clear();
            Chart_defect.Legends.Clear();
            string defectstring = "Server = 10.10.32.238; Database=batterymes; Uid=BatteryMes;Pwd=Battery;";
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
                                    MessageBox.Show("오늘의 데이터가 없습니다.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }*/
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


             string errorstring = "Server = 10.10.32.238; Database=batterymes; Uid=BatteryMes;Pwd=Battery;";
           // string errorstring = "Server = localhost; Database=batterymes; Uid=root;Pwd=kwak123";
            try
            {
                using (MySqlConnection errorcon = new MySqlConnection(errorstring))
                {
                    errorcon.Open();
                    DateTime selectedDate = TimePicker.Value.Date;
                    string formattedDate = selectedDate.ToString("yyyy-MM-dd");

                    string errorquery = $@"
                SELECT COUNT(*) AS error_count, error_code 
                FROM error 
                WHERE DATE(date) = '{formattedDate}' 
                GROUP BY error_code";

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
        private void TimePicker_ValueChanged(object sender, EventArgs e)
        {
            //defectchart();
            Errorchart();
        }
    }
}




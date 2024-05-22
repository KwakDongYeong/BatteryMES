using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
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
        }

      /*   private void defectchart()
        {
          /*  Chart_defect.Series.Clear();
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

                             //   int totalCount = goodCount + defectCount;

                                if (totalCount > 0)
                                {
                                    double defectRate = (double)defectCount / totalCount * 100;

                                    DefectSeries.Points.AddXY("Defective", defectRate);
                                    DefectSeries.Points.AddXY("Non-Defective", 100 - defectRate);

                                    Chart_defect.Legends.Add(new Legend("DefectRateLegend"));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }*/
        //}
    }
}




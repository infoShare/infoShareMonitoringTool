using MonitoringTool.Configuration;
using MonitoringTool.Models;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;

namespace MonitoringTool.Retrievers
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DataRetriever
    {
      
        public List<string> getCategories()
        {
            var con = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            List<string> categories = new List<string>();
            using (MySqlConnection myConnection = new MySqlConnection(con))
            {
                string oString = "SELECT DISTINCT name FROM categories ORDER BY name ASC";
                MySqlCommand oCmd = new MySqlCommand(oString, myConnection);
                myConnection.Open();
                using (MySqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        categories.Add(oReader["name"].ToString());
                    }
                    myConnection.Close();
                }
            }
            return categories;
        }

        public List<ChartDataItem> RetrieveData(string category, Config config)
        {
            var con = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            List<ChartDataItem> data = new List<ChartDataItem>();
            using (MySqlConnection myConnection = new MySqlConnection(con))
            {
                string oString = "SELECT COUNT(DISTINCT i.id) , DATE(i.creationDate) FROM Informations i INNER JOIN categories c ON i.categoryId = c.id WHERE c.name = @category AND i.creationDate BETWEEN @startDate AND @endDate GROUP BY DATE(i.creationDate)";
                MySqlCommand oCmd = new MySqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@startDate", config.rangeStart);
                oCmd.Parameters.AddWithValue("@endDate", config.rangeEnd);
                oCmd.Parameters.AddWithValue("@category", category);
                myConnection.Open();
                using (MySqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        ChartDataItem item = new ChartDataItem();
                        item.value = double.Parse(oReader["COUNT(DISTINCT i.id)"].ToString());
                        item.time = Convert.ToDateTime(oReader["DATE(i.creationDate)"].ToString());
                        data.Add(item);
                    }
                    myConnection.Close();
                }
            }
            return data;
        }
    }
}
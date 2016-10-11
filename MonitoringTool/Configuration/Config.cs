using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MonitoringTool.Configuration
{
    public class Config
    {
        private static string DATE_FORMAT = "dd/MM/yyyy";

        public Config()
        {
            rangeStart = new DateTime(DateTime.Now.Year, 1, 1);
            rangeEnd = new DateTime(DateTime.Now.Year, 12, 31);
        }

        public DateTime rangeStart { get; set; }
        public DateTime rangeEnd { get; set; }
       
        public static Config FromHolder(ConfigHolder holder)
        {
            Config config = new Config();
            config.rangeStart = format(holder.rangeStart);
            config.rangeEnd = format(holder.rangeEnd);
            return config;
        }

        private static DateTime format(string date)
        {
            return DateTime.ParseExact(date, DATE_FORMAT, CultureInfo.InvariantCulture);
        }
    }
}
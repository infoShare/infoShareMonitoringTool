using MonitoringTool.Statistics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitoringTool.Models
{
    public class ChartData
    {

        public ChartData(string category)
        {
            this.category = this.category;
        }

        [JsonProperty(PropertyName = "category")]
        public string category { get; set; }

        [JsonProperty(PropertyName = "meanValue")]
        public double meanValue;

        [JsonProperty(PropertyName = "statistics")]
        public List<ChartDataItem> statistics { get; set; }
    }
}
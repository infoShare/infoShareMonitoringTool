using Newtonsoft.Json;
using System;

namespace MonitoringTool.Models
{
    public class ChartDataItem
    {
        [JsonProperty(PropertyName = "time")]
        public DateTime time { get; set; }

        [JsonProperty(PropertyName = "value")]
        public double value { get; set; }
    }
}

using MonitoringTool.Configuration;
using MonitoringTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonitoringTool.Statistics
{
    public class StatisticCalculator
    {
        public double CalculateMeanValue(List<ChartDataItem> items)
        {
            return items.Average(item => item.value);
        }

    }
}

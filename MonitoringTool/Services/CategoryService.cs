using MonitoringTool.Statistics;
using MonitoringTool.Models;
using MonitoringTool.Retrievers;
using System;
using System.Collections.Generic;
using System.Linq;
using MonitoringTool.Configuration;

namespace MonitoringTool.Services
{
    public class CategoryService : ICategoryService
    {
        private static ChartDataItemComparer _comparer = new ChartDataItemComparer();
        private static Config _config = new Config();
        private DataRetriever _dataRetriever = new DataRetriever();
        private StatisticCalculator _statCalculator = new StatisticCalculator();

        public ChartData GetCategoryChartData(string category)
        { 
            return PrepareChartData(category);
        }

        private ChartData PrepareChartData(string category)
        {
            ChartData chartData = new ChartData(category);
            List<ChartDataItem> statistics = _dataRetriever.RetrieveData(category, _config);
            if (statistics.Count == 0)
            {
                return chartData;
            }
            chartData.statistics = statistics;
            chartData.meanValue = _statCalculator.CalculateMeanValue(statistics);
            return chartData;
        }

       
        public List<string> GetCategories()
        {
           return _dataRetriever.getCategories();
        }

        public void SetConfiguration(Config newConf)
        {
            _config = newConf;   
        }
    }

    public class ChartDataItemComparer : IComparer<ChartDataItem>
    {
        public int Compare(ChartDataItem x, ChartDataItem y)
        {
            return x.time.CompareTo(y.time);
        }
    }
}
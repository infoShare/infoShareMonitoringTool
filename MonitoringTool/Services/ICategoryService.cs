using MonitoringTool.Configuration;
using MonitoringTool.Models;
using System.Collections.Generic;

namespace MonitoringTool.Services
{
   public interface ICategoryService
   {
        ChartData GetCategoryChartData(string category);
        List<string> GetCategories();
        void SetConfiguration(Config config);
    }
}

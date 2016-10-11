using MonitoringTool.Configuration;
using MonitoringTool.Models;
using MonitoringTool.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace MonitoringTool.Controllers
{
    public class CategoryApiController : ApiController
    {
        private ICategoryService _service;

        public CategoryApiController(ICategoryService service)
        {
            _service = service;
        }

        // GET: api/Category
        public ChartData Get()
        {
            return _service.GetCategoryChartData(getParam(Request, "category"));
        }

        // GET: api/Category/GetCategories
        public List<string> GetCategories()
        {
            return _service.GetCategories();
        }

        // GET: api/Category/PostConfigure
        public void PostConfigure(ConfigHolder configHolder)
        {
            _service.SetConfiguration(Config.FromHolder(configHolder));
        }

        private string getParam(HttpRequestMessage request, string key)
        {
            return request.RequestUri.ParseQueryString().Get(key);
        }
    }
}

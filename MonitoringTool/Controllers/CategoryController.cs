using MonitoringTool.Category;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MonitoringTool.Controllers
{
   public class CategoryController : Controller
   {
      public ActionResult Index()
      {
         return View();
      }

      public ActionResult CategoryTabs(List<CategoryTabData> categoriesData)
      {
         return PartialView("_CategoriesTabs", categoriesData);
      }
   }
}
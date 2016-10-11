using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using MonitoringTool.Services;
using System.Web.Http;

namespace MonitoringTool
{
   public static class UnityConfig
   {
      public static void RegisterComponents()
      {
         var container = new UnityContainer();
         container.RegisterType<ICategoryService, CategoryService>();
         DependencyResolver.SetResolver(new UnityDependencyResolver(container));

         GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
      }
   }
}
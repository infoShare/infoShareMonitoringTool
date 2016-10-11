using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MonitoringTool.Startup))]
namespace MonitoringTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}

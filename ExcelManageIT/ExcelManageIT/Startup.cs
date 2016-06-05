using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExcelManageIT.Startup))]
namespace ExcelManageIT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

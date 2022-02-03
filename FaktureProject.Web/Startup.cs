using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FaktureProject.Web.Startup))]
namespace FaktureProject.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

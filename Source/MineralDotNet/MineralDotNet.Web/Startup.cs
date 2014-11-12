using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MineralDotNet.Web.Startup))]
namespace MineralDotNet.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

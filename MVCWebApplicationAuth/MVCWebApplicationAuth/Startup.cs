using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCWebApplicationAuth.Startup))]
namespace MVCWebApplicationAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

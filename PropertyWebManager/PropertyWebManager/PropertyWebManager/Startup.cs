using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PropertyWebManager.Startup))]
namespace PropertyWebManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

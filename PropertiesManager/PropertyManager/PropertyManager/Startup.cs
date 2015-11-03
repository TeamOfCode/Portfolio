using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PropertyManager.Startup))]
namespace PropertyManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

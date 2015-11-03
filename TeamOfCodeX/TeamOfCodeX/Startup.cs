using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamOfCodeX.Startup))]
namespace TeamOfCodeX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

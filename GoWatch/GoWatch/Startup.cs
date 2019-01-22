using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoWatch.Startup))]
namespace GoWatch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

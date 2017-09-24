using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PLOLMS.Startup))]
namespace PLOLMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

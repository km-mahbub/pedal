using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pedal.Web.Startup))]
namespace Pedal.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

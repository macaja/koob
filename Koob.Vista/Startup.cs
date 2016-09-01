using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Koob.Vista.Startup))]
namespace Koob.Vista
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

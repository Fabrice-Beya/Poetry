using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Poe_tryService.Startup))]

namespace Poe_tryService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}
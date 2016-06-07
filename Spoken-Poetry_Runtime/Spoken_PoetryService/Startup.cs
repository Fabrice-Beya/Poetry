using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Spoken_PoetryService.Startup))]

namespace Spoken_PoetryService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecAOnto.Startup))]
namespace SecAOnto
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

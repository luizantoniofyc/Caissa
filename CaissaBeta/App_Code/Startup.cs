using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(framework_beta.Startup))]
namespace framework_beta
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

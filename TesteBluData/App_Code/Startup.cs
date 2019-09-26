using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TesteBluData.Startup))]
namespace TesteBluData
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

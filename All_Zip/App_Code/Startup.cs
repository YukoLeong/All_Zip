using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(All_Zip.Startup))]
namespace All_Zip
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClientSideApp.Startup))]
namespace ClientSideApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

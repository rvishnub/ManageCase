using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManageCase.Startup))]
namespace ManageCase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

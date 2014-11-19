using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SzelektivABC.Startup))]
namespace SzelektivABC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

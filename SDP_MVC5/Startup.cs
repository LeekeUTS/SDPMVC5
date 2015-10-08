using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SDP_MVC5.Startup))]
namespace SDP_MVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

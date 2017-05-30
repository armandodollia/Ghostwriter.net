using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GhostWriter.Startup))]
namespace GhostWriter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

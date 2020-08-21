using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NAA.Startup))]
namespace NAA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

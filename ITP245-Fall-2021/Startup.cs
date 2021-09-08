using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITP245_Fall_2021.Startup))]
namespace ITP245_Fall_2021
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

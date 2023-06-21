using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CinemaHubFinalProject.Startup))]
namespace CinemaHubFinalProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

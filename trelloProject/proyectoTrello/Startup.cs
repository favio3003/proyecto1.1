using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proyectoTrello.Startup))]
namespace proyectoTrello
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

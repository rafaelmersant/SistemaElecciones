using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaElecciones.Startup))]
namespace SistemaElecciones
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

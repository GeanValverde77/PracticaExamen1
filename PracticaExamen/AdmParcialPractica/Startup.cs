using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdmParcialPractica.Startup))]
namespace AdmParcialPractica
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

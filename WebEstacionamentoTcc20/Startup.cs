using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebEstacionamentoTcc20.Startup))]
namespace WebEstacionamentoTcc20
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}

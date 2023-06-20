using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(A2projeto.Startup))]
namespace A2projeto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

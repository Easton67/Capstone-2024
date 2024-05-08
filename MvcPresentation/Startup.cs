using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcPresentation.Startup))]
namespace MvcPresentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

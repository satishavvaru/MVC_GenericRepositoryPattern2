using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_GenericRepositoryPattern2.Startup))]
namespace MVC_GenericRepositoryPattern2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

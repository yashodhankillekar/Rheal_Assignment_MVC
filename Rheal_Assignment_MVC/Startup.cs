using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rheal_Assignment_MVC.Startup))]
namespace Rheal_Assignment_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

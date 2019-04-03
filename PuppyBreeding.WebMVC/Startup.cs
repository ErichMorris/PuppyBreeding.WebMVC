using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PuppyBreeding.WebMVC.Startup))]
namespace PuppyBreeding.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhonebookUsingMVC.Startup))]
namespace PhonebookUsingMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

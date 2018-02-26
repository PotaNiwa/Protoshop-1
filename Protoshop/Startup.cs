using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Protoshop.Startup))]
namespace Protoshop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

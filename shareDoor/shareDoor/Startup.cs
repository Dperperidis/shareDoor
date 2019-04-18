using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(shareDoor.Startup))]
namespace shareDoor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

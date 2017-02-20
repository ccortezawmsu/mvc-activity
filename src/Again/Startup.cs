using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Again.Startup))]
namespace Again
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

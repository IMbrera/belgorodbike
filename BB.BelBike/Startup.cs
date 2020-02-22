using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BB.BelBike.Startup))]
namespace BB.BelBike
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

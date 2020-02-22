using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BelgorodBike.Startup))]
namespace BelgorodBike
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

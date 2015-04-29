using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HarvestBandFestival.Startup))]
namespace HarvestBandFestival
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

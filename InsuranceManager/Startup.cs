using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InsuranceManager.Startup))]
namespace InsuranceManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCApplicationTest.Startup))]
namespace MVCApplicationTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

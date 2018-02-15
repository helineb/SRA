using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SRA.Startup))]
namespace SRA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

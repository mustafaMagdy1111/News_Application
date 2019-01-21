using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(News_Application.Startup))]
namespace News_Application
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

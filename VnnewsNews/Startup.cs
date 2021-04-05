using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VnnewsNews.Startup))]
namespace VnnewsNews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}

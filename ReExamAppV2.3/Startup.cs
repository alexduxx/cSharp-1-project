using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReExamAppV2._3.Startup))]
namespace ReExamAppV2._3
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

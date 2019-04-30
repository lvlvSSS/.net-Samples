using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SignalDemo.Startup))]
namespace SignalDemo
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

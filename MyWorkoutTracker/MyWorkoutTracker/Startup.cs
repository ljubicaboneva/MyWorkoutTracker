using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWorkoutTracker.Startup))]
namespace MyWorkoutTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

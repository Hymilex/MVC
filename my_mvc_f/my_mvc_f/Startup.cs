using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(my_mvc_f.Startup))]
namespace my_mvc_f
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

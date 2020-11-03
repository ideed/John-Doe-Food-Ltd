using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(John_Doe_Food_Ltd.Startup))]
namespace John_Doe_Food_Ltd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

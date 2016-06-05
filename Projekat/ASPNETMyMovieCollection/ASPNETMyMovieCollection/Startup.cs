using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNETMyMovieCollection.Startup))]
namespace ASPNETMyMovieCollection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

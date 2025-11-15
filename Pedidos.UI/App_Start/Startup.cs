using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(Producto.UI.Startup))]

namespace Producto.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
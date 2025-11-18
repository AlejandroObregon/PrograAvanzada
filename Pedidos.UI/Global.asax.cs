using Producto.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Producto.UI
{
	public class MvcApplication : System.Web.HttpApplication
	{
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            var httpException = exception as HttpException;

            Response.Clear();
            Server.ClearError();

            var routeData = new RouteData();
            routeData.Values["controller"] = "Home";
            routeData.Values["action"] = "Error500";

            if (httpException != null)
            {
                switch (httpException.GetHttpCode())
                {
                    case 404:
                        routeData.Values["action"] = "Error404";
                        break;
                    case 500:
                        routeData.Values["action"] = "Error500";
                        break;
                }
            }

            Response.TrySkipIisCustomErrors = true;
            IController errorController = new HomeController();
            errorController.Execute(new RequestContext(
                new HttpContextWrapper(Context), routeData));
        }
    }
}

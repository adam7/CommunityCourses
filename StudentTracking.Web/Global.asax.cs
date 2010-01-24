using System.Web.Mvc;
using System.Web.Routing;

namespace StudentTracking.Web
{
  // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
  // visit http://go.microsoft.com/?LinkId=9394801

  public class MvcApplication : System.Web.HttpApplication
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
          "Default",                                                  // Route name
          "{controller}/{action}/{id}",                               // URL with parameters
          new { controller = "TasterSession", action = "Index", id = "" }   // Parameter defaults
      );

      //routes.MapRoute(
      //  null,                                                       // Route name
      //  "",                                                         // Matches the root URL, i.e. ~/
      //  new { controller = "Student", action = "Index", page = 1 }  // Parameter defaults
      //);

      //routes.MapRoute(
      //    null,                                                     // Route name
      //    "{controller}/{action}/{id}/Page{page}",                  // URL pattern e.g. ~/Page683
      //    new { controller = "Student", action = "Index", id = "" },// Parameter defaults
      //    new { page = @"\d+" }                                     // Constraints: page must be numercal
      //);

    }

    protected void Application_Start()
    {
      RegisterRoutes(RouteTable.Routes);
    }
  }
}
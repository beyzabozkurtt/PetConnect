using finalp.Models.manager;
using System.Web.Mvc;
using System.Web.Routing;

namespace finalp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            using (databasecontext db = new databasecontext())
            {
                db.Database.CreateIfNotExists();
            }
            ////tum sayfalara authorize
            //GlobalFilters.Filters.Add(new AuthorizeAttribute());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }


}

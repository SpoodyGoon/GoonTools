using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookmarkSharp.DataAccess
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            ); 
            
            routes.MapRoute(
                 name: "Bookmark",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Bookmark", action = "Get", id = UrlParameter.Optional }
             );

            routes.MapRoute(
                 name: "Folder",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "Folder", action = "Get", id = UrlParameter.Optional }
             );
        }
    }
}
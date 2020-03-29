using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Apostille
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "BlogSingle",
                url: "blog/blog-single",
                defaults: new { controller = "Blog", action = "BlogSingle", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Blos",
                url: "blog",
                defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "Login",
              url: "login",
              defaults: new { controller = "Admin", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "List",
              url: "admin/list",
              defaults: new { controller = "Admin", action = "ListView", id = UrlParameter.Optional }
            );
            routes.MapRoute(
             name: "AdminFaqs",
             url: "admin/faqs",
             defaults: new { controller = "Admin", action = "Faqs", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "Create",
              url: "admin/create",
              defaults: new { controller = "Admin", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "Dashboard",
              url: "admin",
              defaults: new { controller = "Admin", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "Contact",
              url: "contact-us",
              defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "Faqs",
              url: "faqs",
              defaults: new { controller = "Home", action = "Faqs", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
           

        }
    }
}

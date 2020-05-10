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
                name: "Blos",
                url: "blog",
                defaults: new { controller = "Blog", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Category",
               url: "Category/{url}",
               defaults: new { controller = "blog", action = "Category" }
           );

            routes.MapRoute(
               name: "blog",
               url: "blog/{url}",
               defaults: new { controller = "blog", action = "blog" }
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
               name: "search",
               url: "search",
               defaults: new { controller = "Home", action = "search" }
           );

            
            routes.MapRoute(
               name: "page",
               url: "{url}",
               defaults: new { controller = "Home", action = "page" }
           );

            routes.MapRoute(
               name: "tag",
               url: "tag/{url}",
               defaults: new { controller = "Home", action = "tag" }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "404-PageNotFound",
                "{*url}",
                new { controller = "StaticContent", action = "PageNotFound" }
                );
        }
    }
}

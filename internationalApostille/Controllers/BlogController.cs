using internationalApostille.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace internationalApostille.Controllers
{
    public class BlogController : Controller
    {
        private apostilleDBEntities db = new apostilleDBEntities();
        // GET: Blog
        public ActionResult Index(int? page)
        {
            ViewBag.robots = "<meta name='robots' content='noodp,noydir' />";

            return View(db.BlogPosts.Where(a=>a.Visibility == "Public").ToList().ToPagedList(page ?? 1,5));
        }


        public ActionResult blog(string url)
        {
            if (url != "")
            {
                var post = db.BlogPosts.Where(a => a.url == url && a.Visibility == "Public").FirstOrDefault();
                if (post == null)
                {
                    return RedirectToAction("PageNotFound", "Home");
                }

                ViewBag.MetaDescription = post.DescriptionMeta;
                ViewBag.keywords = post.Keywords;

                return View(post);
            }
            
            return RedirectToAction("blog", "Blog");
        }

        public ActionResult Category(string url)
        {
            if (url != "")
            {
                string urlBlog = url.Replace("-", " ");
                var Category = db.Categories.Where(a => a.name == urlBlog).FirstOrDefault();
                var posts = db.BlogPosts.Where(a => a.CategoryID == Category.id).ToList();

                if (Category == null)
                {
                    return RedirectToAction("PageNotFound", "Home");
                }
                return View(posts);
            }
            
            return RedirectToAction("PageNotFound", "Home");
        }


    }
}
using internationalApostille.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace internationalApostille.Controllers
{
    public class AdminController : Controller
    {
        private apostilleDBEntities db = new apostilleDBEntities();
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }
        public ActionResult ListView()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }
        public ActionResult Login()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("index", "Admin");
            }
            return View();
        }

        [HttpPost]
        public JsonResult Login(string email,string password)
        {
            var userdatails = db.Users.Where(a => a.email == email && a.password == password).FirstOrDefault();
            if (userdatails == null)
            {
                return Json("no", JsonRequestBehavior.AllowGet);
            }
            Session["UserID"] = userdatails.id;
            Session["FullName"] = userdatails.fullname;
            Session["type"] = userdatails.type;
            return Json("index", "Admin");
        }

        [HttpPost]
        public ActionResult register(User user)
        {
            User userDetails = db.Users.Where(a => a.email == user.email).FirstOrDefault();
            if (userDetails != null)
            {
                return Json("no", JsonRequestBehavior.AllowGet);
            }
            db.Users.Add(user);
            user.type = "Creator";
            db.SaveChanges();
            var userdatails = db.Users.Where(a => a.email == user.email && a.password == user.password).FirstOrDefault();
            Session["UserID"] = userdatails.id;
            Session["FullName"] = userdatails.fullname;
            return Json("index", "Admin");
        }

        public ActionResult CreateUser()
        {
            if (Session["UserID"] == null )
            {
                return RedirectToAction("Login", "Admin");
            }

            if (Session["type"].ToString() != "Admin")
            {
                return RedirectToAction("index", "Admin");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            var userDetails = db.Users.Where(a => a.email == user.email).FirstOrDefault();
            if (userDetails != null)
            {
                ViewBag.Message = "The Email Used Before!";
                return View(user);
            }
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("UserList", "Admin");
        }

        public ActionResult UserList()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View(db.Users.ToList());
        }

        [HttpGet]
        public ActionResult DeleteUser(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Session["type"].ToString() != "Admin")
            {
                return RedirectToAction("index", "Admin");
            }
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("UserList", "Admin");
        }

        [HttpGet]
        public ActionResult EditUser(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (Session["type"].ToString() != "Admin")
            {
                return RedirectToAction("index", "Admin");
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(User user)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            var userDetails = db.Users.Where(a => a.email == user.email && a.id != user.id).FirstOrDefault();

            if (userDetails != null )
            {
                ViewBag.Message = "The Email Used Before!";
                return View(user);
            }
            if (ModelState.IsValid)
            {
               
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserList");
            }
            return View(user);
        }


        public ActionResult Create()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        public ActionResult Faqs(int? page)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View(db.FAQs.ToList().ToPagedList(page ?? 1, 5));
        }

        [HttpPost]
        public ActionResult AddFAQ(FAQ faq)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            db.FAQs.Add(faq);
            db.SaveChanges();
            return RedirectToAction("Faqs", "Admin");
        }

        [HttpPost]
        public ActionResult EditFAQ(FAQ faq)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (ModelState.IsValid)
            {
                
                db.Entry(faq).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Faqs");
            }
            return View(faq);
        }

        [HttpPost]
        public ActionResult DeleteFAQ(FAQ faqs)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            FAQ faq = db.FAQs.Find(faqs.id);
            db.FAQs.Remove(faq);
            db.SaveChanges();
            return RedirectToAction("Faqs", "Admin");
        }


        public ActionResult CreateBlogPost()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "id", "name");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateBlogPost(BlogPost blog, HttpPostedFileBase UploadImage)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            string filename = "blog-" + DateTime.Now.ToString("ddMMyyhhmmss") + Path.GetExtension(UploadImage.FileName);
            string path = Path.Combine(Server.MapPath("~/uploads"), filename);
            UploadImage.SaveAs(path);
            blog.FeaturedImage = filename;

            blog.url = blog.url.ToLower();

            blog.UserID = Convert.ToInt32(Session["UserID"]);
            ViewBag.CategoryID = new SelectList(db.Categories, "id", "name", blog.CategoryID);
            db.BlogPosts.Add(blog);
            db.SaveChanges();
            return RedirectToAction("BlogList", "Admin");
        }

        public ActionResult BlogList()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View(db.BlogPosts.ToList());
        }

        [HttpGet]
        public ActionResult DeleteBlogPost(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            BlogPost post = db.BlogPosts.Find(id);
            db.BlogPosts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("BlogList", "Admin");
        }
        
        [HttpGet]
        public ActionResult EditBlogPost(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            
            BlogPost post = db.BlogPosts.Find(id);
            if (post == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "id", "name", post.CategoryID);
            return View(post);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditBlogPost(BlogPost model, HttpPostedFileBase UploadImage)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (ModelState.IsValid)
            {
                ViewBag.CategoryID = new SelectList(db.Categories, "id", "name", model.CategoryID);
                string oldPath = Path.Combine(Server.MapPath("~/uploads"), model.FeaturedImage);
                if (UploadImage != null)
                {
                    string filename = "blog-" + DateTime.Now.ToString("ddMMyyhhmmss") + Path.GetExtension(UploadImage.FileName);
                    System.IO.File.Delete(oldPath);
                    string path = Path.Combine(Server.MapPath("~/uploads"), filename);

                    UploadImage.SaveAs(path);
                    model.FeaturedImage = filename;
                }

                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BlogList");
            }
            return View(model);
        }

        
        public ActionResult PagesList()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View(db.PagesPosts.ToList());
        }

        public ActionResult CreateOtherPost()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateOtherPost(PagesPost post)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            post.url = post.url.ToLower();
            post.type = "Other";
            post.userID = Convert.ToInt32(Session["UserID"]);
            db.PagesPosts.Add(post);
            db.SaveChanges();
            return RedirectToAction("PagesList", "Admin");
        }

        [HttpGet]
        public ActionResult EditPost(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            PagesPost page = db.PagesPosts.Find(id);
            if (page == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            return View(page);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditPost(PagesPost model)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (ModelState.IsValid)
            {
                
                model.userID = Convert.ToInt32(Session["UserID"]);
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PagesList");
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult DeletePage(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            PagesPost post = db.PagesPosts.Find(id);
            db.PagesPosts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("PagesList", "Admin");
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }

            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Categories", "Admin");
        }

        [HttpGet]
        public ActionResult Categories()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View(db.Categories.ToList());
        }

        [HttpGet]
        public ActionResult DeleteCategory(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Categories", "Admin");
        }

        [HttpGet]
        public ActionResult EditCategory(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            Category Category = db.Categories.Find(id);
            if (Category == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            return View(Category);
        }


        [HttpPost]
        public ActionResult EditCategory(Category model)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Categories");
            }
            return View(model);
        }


        public ActionResult Comments()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View(db.Comments.ToList());
        }

        public ActionResult DeleteComment(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            Comment com = db.Comments.Find(id);
            db.Comments.Remove(com);
            db.SaveChanges();
            return RedirectToAction("Comments", "Admin");
        }


        [HttpPost]
        public ActionResult NewComment(Comment cmnt)
        {
            var Details = db.Comments.Where(a => a.Email == cmnt.Email && a.blogPostId != cmnt.blogPostId).FirstOrDefault();

            if (Details != null)
            {
                
            }
            else
            {
                cmnt.date = DateTime.Now;
                db.Comments.Add(cmnt);
                db.SaveChanges();
                
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpGet]
        public ActionResult EditComment(int? id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            Comment cmnt = db.Comments.Find(id);
            if (cmnt == null)
            {
                return RedirectToAction("PageNotFound", "Home");
            }
            return View(cmnt);
        }


        [HttpPost]
        public ActionResult EditComment(Comment model)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Comments");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("login", "Admin");
        }

    }
}
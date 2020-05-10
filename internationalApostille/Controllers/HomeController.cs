using internationalApostille.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Apostille.Controllers
{
    public class HomeController : Controller
    {
        private apostilleDBEntities db = new apostilleDBEntities();
        private USDBEntities db2 = new USDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.MetaDescription = "Specializing in document authentication, certification, attestation, legalization, and Apostille services through all 50 U.S. Secretary of State Offices and the U.S. Department of State in Washington, DC. We also provide Consulate and Embassy Legalization in Los Angeles, New York, San Francisco, Texas, Florida, Illinois, and in Washington, DC.";
            ViewBag.keywords = "Alabama apostille, Alaska apostille, Arizona apostille, Arkansas apostille, California apostille, Colorado apostille, Connecticut apostille, Delaware apostille, Florida apostille, Georgia apostille, Hawaii apostille, Idaho apostille, Illinois apostille, Indiana apostille, Iowa apostille, Kansas apostille, Kentucky apostille, Louisiana apostille, Maine apostille, Maryland apostille, Massachusetts apostille, Michigan apostille, Minnesota apostille, Mississippi apostille, Missouri apostille, Montana apostille, Nebraska apostille, Nevada apostille, New Hampshire apostille, New Jersey apostille, New Mexico apostille, New York apostille, North Carolina apostille, North Dakota apostille, Ohio apostille, Oklahoma apostille, Oregon apostille, Pennsylvania apostille, Rhode Island apostille, South Carolina apostille, South Dakota apostille, Tennessee apostille, Texas apostille, Utah apostille, Vermont apostille, Virginia apostille, Washington apostille, West Virginia apostille, Wisconsin apostille, Wyoming apostille, US Department of State Apostille, Washington DC Apostille, Secretary of DC Apostille";
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Faqs()
        {
            return View(db.FAQs.ToList());
        }

        public ActionResult page(string url)
        {
            if (url == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (url.Contains("apostille"))
            {
                string name = url.Replace("-apostille","").Replace("-"," ");
                var state = db2.States.Where(a => a.StateName == name).FirstOrDefault();
                
                if (state == null)
                {
                    var country = db2.Countries.Where(a => a.CountryName == name).FirstOrDefault();
                    if (state == null && country == null)
                    {
                        
                        var post = db.PagesPosts.Where(a => a.url == url && a.Visibility == "Public").FirstOrDefault();
                        if (post == null)
                        {
                            return RedirectToAction("PageNotFound", "Home");
                        }
                        ViewBag.MetaDescription = post.metaDescription;
                        ViewBag.keywords = post.metaKeywords;
                        return View(post);

                    }
                    else
                    {
                        ViewBag.MetaDescription = "We provide fast "+ country.CountryName + " Apostille service for documents originating from the United States (State Federal).  Common documents we receive are: Birth Certificates, Marriage Certificates, Death Certificates, Divorce Decree, Single Status Affidavit, and more.";
                        ViewBag.keywords = country.CountryName + " apostille, apostille " + country.CountryName;
                        return View("country", country);
                    }
                }
                else
                {
                    ViewBag.MetaDescription = "We provide FAST " + state.StateName + " Apostille service through the " + state.StateName + " Secretary of States Office.";
                    ViewBag.keywords = state.StateName+" apostille, apostille "+ state.StateName + " secretary of state, "+state.StateAbb;
                    return View("state",state);
                }
                
            }
            else
            {
                var post = db.PagesPosts.Where(a => a.url == url && a.Visibility == "Public").FirstOrDefault();
                if (post == null)
                {
                    return RedirectToAction("PageNotFound", "Home");
                }

                ViewBag.MetaDescription = post.metaDescription;
                ViewBag.keywords = post.metaKeywords;

                return View(post);
            }

            
        }
        [HttpGet]
        public ActionResult search(int? page)
        {

            var value = db.BlogPosts.Where(a=>a.Visibility == "Public").ToList().ToPagedList(page ?? 1, 5);
            return View(value);

        }

        [HttpPost]
        public ActionResult search(string SearchKeyword, int? page)
        {
            var value = db.BlogPosts.Where(a => a.title.Contains(SearchKeyword) && a.Visibility == "Public").ToList().ToPagedList(page ?? 1, 5);
            return View(value);
        }

        [HttpPost]
        public ActionResult SendMessage(string fullname, string email, string subject, string message, string Type)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("إيميل الشركة", "E-mail");
                    var receiverEmail = new MailAddress(email, "Receiver");
                    var password = "باسورد الإيميل";
                    var sub = subject;
                    var body = message;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    return RedirectToAction("index", "Home");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return RedirectToAction("index", "Home");
        }


        public ActionResult PageNotFound()
        {
            return View();
        }

        public ActionResult tag(string url, int? page)
        {
            if (url != "" )
            {
                string name = url.Replace("-", " ");
                var tag = db.BlogPosts.Where(a => a.tags.Contains(name)).ToList().ToPagedList(page ?? 1, 5);
                return View(tag);
            }
            
            return RedirectToAction("PageNotFound", "Home");
        }
    }
}
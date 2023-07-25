using CricZat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CricZat.Controllers
{
    public class HomeController : Controller
    {
        int id2;
        bool ch = true;
        CricZatEntities4 db = new CricZatEntities4();
        public ActionResult Index()
        {
            ViewBag.post = db.Posts.ToList();
            ViewBag.users = db.userTables.ToList();
            
            return View();
        }

        public ActionResult Editorial()
        {
            return View();
        }

        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(admin ad)
        {
            admin a = db.admins.Where(temp => temp.adminName == ad.adminName && temp.adminPassword == ad.adminPassword).SingleOrDefault();
            ViewBag.Message = "Your contact page.";
            if (ad != null)
            {
                Session["adminUsername"] = ad.adminName;
                Session["adPassword"] = ad.adminPassword;
                return RedirectToAction("Editorial", "Home");
            }
            return View();

           
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult LoginPage()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(Models.userTable userTables)
        {
            userTable ad = db.userTables.Where(temp => temp.userName == userTables.userName && temp.userPassword == userTables.userPassword).SingleOrDefault();
            ViewBag.Message = "Your contact page.";
            if(ad!=null)
            {
                Session["UserName"] = ad.userName;
                Session["userPassword"] = ad.userPassword;
                return RedirectToAction("editInfo","Home");
            }
            return View();
        }
        public ActionResult CreateUser()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(userTable userTables)
        {
            ViewBag.Message = "Your contact page.";
            if (ModelState.IsValid)
            {
                db.userTables.Add(userTables);
                   db.SaveChanges();

                return View();
            }
            return View();
        }


        public ActionResult DeleteUser()
        {

            ViewBag.users = db.userTables.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult DeleteUser(int UserID)
        {

            userTable user = db.userTables.Where(temp => temp.userId == UserID).FirstOrDefault();
            db.userTables.Remove(user);
            db.SaveChanges();
            ViewBag.users = db.userTables.ToList();
            return View();
        }
        public ActionResult Rankings()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Community()
        {


            ViewBag.post = db.Posts.ToList();
            ViewBag.users = db.userTables.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CommunityHandle(Post post)
        {

            String s = Session["UserName"].ToString();
            ViewBag.ut = db.userTables.Where(temp => temp.userName == s).FirstOrDefault();
            int userid = ViewBag.ut.userId;


            DateTime utcDate = DateTime.UtcNow;
            post.date = utcDate;
            post.userId = userid;
            db.Posts.Add(post);
            db.SaveChanges();



            return RedirectToAction("Community", "Home");
        }

        public ActionResult PlayerProfile()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult editInfo()
        {
            return View();
        }
        public ActionResult newsDetail()
        {

            return View();
        }
        public ActionResult featurePost()
        {

            return View();
        }

    }
}
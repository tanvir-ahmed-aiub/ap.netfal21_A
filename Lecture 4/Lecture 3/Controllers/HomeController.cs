using Lecture_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Lecture_3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        [HttpGet]
        public ActionResult Login() {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Username, string Password) {
            Database db = new Database();
            var user = db.Users.Authenticate(Username, Password);
            if (user != null) {
                FormsAuthentication.SetAuthCookie(user.Username,false);
                //to signout
                //FormsAuthentication.SignOut();
                return RedirectToAction("Index","Student");
            }
            ViewBag.Message = "Invalid username or password";
            /*Session.Remove("logged");
            Session.Abandon();
            Session.RemoveAll();*/
            return View();
        }
    }
}
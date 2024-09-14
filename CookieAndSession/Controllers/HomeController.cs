using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieAndSession.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult SetCookie()
        {
            HttpCookie cookie = new HttpCookie("UserCookie");
            cookie["Username"] = "Sreerag"; 
            cookie["UserType"] = "Admin";   
            cookie.Expires = DateTime.Now.AddDays(5); 

            Response.Cookies.Add(cookie);

            ViewBag.Message = "Cookie has been created!";
            return View();
        }

        public ActionResult GetCookie()
        {
            HttpCookie cookie = Request.Cookies["UserCookie"];

            if (cookie != null)
            {
                string username = cookie["Username"];
                string userType = cookie["UserType"];
                ViewBag.Username = username;
                ViewBag.UserType = userType;
                ViewBag.Message = "Cookie has been retrieved!";
            }
            else
            {
                ViewBag.Message = "No cookie found!";
            }

            return View();
        }

        public ActionResult DeleteCookie()
        {
            if (Request.Cookies["UserCookie"] != null)
            {
                HttpCookie cookie = new HttpCookie("UserCookie");
                cookie.Expires = DateTime.Now.AddDays(-1); 
                Response.Cookies.Add(cookie);

                ViewBag.Message = "Cookie has been deleted!";
            }
            else
            {
                ViewBag.Message = "No cookie found to delete!";
            }

            return View();
        }
    }
}
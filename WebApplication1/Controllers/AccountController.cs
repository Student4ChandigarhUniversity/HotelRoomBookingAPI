using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        //DataDBContext context = new DataDBContext();
        [Route("")]
        [Route("index")]
        [Route("~/")]
        [HttpGet]

        

        public IActionResult Index()
        {
            return View();
        }


        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username != null && password != null && username.Equals("admin") && password.Equals("123456"))
            {
                HttpContext.Session.SetString("uname", username);
                return View("Home");
            }
            else
            {
                ViewBag.Error = "Invalid Credentials";
                return View("Index");
            }
        }


        //[Route("login")]
        //[HttpPost]
        //public IActionResult Login(string username, string password)
        //{
        //    var user = context.UserDetails.Where(x => x.UserName == username).SingleOrDefault();

        //    TempData["uid"] = user.UserId;

        //    HttpContext.Session.SetString("uid", user.UserId.ToString()); ;

        //    if (user == null)
        //    {
        //        ViewBag.Error = "Invalid Credentials";
        //        return View("Index");
        //    }
        //    else
        //    {
        //        var userName = user.UserName;
        //        var passWord = user.UserPassword;
        //        if (username != null && password != null && username.Equals(userName) && password.Equals(passWord))
        //        {
        //            HttpContext.Session.SetString("uname", username);
        //            return View("Home");
        //        }
        //        else
        //        {
        //            ViewBag.Error = "Invalid Credentials";
        //            return View("Index");
        //        }
        //    }


        //}


        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Index");
        }
    }
}
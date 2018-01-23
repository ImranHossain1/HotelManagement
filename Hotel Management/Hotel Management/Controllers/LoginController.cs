using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Management.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("Index")]
        public ActionResult Submit()
        {
            if (Request["username"] == "admin" && Request["password"] == "admin")
            {
                return Redirect("http://localhost:13533/Admin");
            }
            else
            {
                return Redirect("http://localhost:13533/Login/LoginErr");
            }
        }

        [HttpGet]
        public ActionResult LoginErr()
        {
            return View("err");
        }

        [HttpPost, ActionName("LoginErr")]
        public ActionResult SubmitErr()
        {
            if (Request["username"] == "admin" && Request["password"] == "admin")
            {
                return Redirect("http://localhost:13533/Admin");
            }
            else
            {
                return Redirect("http://localhost:13533/Login/LoginErr");
            }
        }
    }
}
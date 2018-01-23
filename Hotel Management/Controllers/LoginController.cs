using EntityLayer;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Management.Controllers
{
    public class LoginController : Controller
    {
        private AdminService adminService = new AdminService();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.loginmessage = "";
            return View();
        }
        [HttpPost, ActionName("Index")]
        public ActionResult Submit(string username, string pass)
        {
            Admin user = this.adminService.GetByEmailPass(username, pass);
            if (user != null)
            {

                if (username == user.UserName && pass == user.Password)
                {
                    
                    Session["logedIn"] = user.UserName;

                    return RedirectToAction("Index", "Admin");

                }
            }
            else
            {
                ViewBag.loginmessage = "Incorrect Email or Password!!";

            }
            return View();
        }

       
        

        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdmin(Admin admin)
        {

            if (ModelState.IsValid)
            {

                this.adminService.Insert(admin);
                return RedirectToAction("Admin");
            }
            else
            {
                return View(admin);
            }
        }
       
    }
}
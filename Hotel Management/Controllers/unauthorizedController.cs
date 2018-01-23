using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Management.Controllers
{
    public class unauthorizedController : Controller
    {
        // GET: UnAuthAcc
        public ActionResult Index()
        {
            return View();
        }
    }
}
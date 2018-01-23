using EntityLayer;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel_Management.Controllers
{
    public class HomeController : Controller
    {
        private MessageService msgService = new MessageService();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        /*[HttpPost, ActionName("Contact")]
        public ActionResult SubmitContact()
        {
            Message msg = new Message()
            {
                SenderName = Request["name"],
                SenderPhone = Request["phone"],
                SenderEmail = Request["email"],
                MessageBody = Request["body"],
                Time = DateTime.Now,
                Seen = false
            };

            this.msgService.Insert(msg);
            return View("Confirmation");
        }*/

        public ActionResult Confirmation()
        {
            return View("Confirmation");
        }


        public ActionResult Getmessages()
        {
            var msg = from item in this.msgService.GetAll()
                      where item.Seen == false
                      select item.MessageId.ToString();
            return Json(new { result = msg }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Gallary()
        {
            return View();
        }
        public ActionResult RoomAndTariff()
        {
            return View();
        }
    }
}
using EntityLayer;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotel_Management.Controllers
{
    public class NotiController : ApiController
    {
        DataContext context = new DataContext();
        private CustomerService cusService = new CustomerService();

        /*
         * GetAll()
            /Noti
         */
        public IHttpActionResult Get()
        {
            //return Content(HttpStatusCode.OK, "Welcome");
            return Ok(context.Set<Notification>().ToList());
        }

        /*
         * Get()
            /Noti/2
         */
        public IHttpActionResult Get([FromUri]int id)
        {
            Notification room = context.Set<Notification>().Find(id);
            if (room == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(room);
        }

        /*
         * Create()
            /Noti
         */
        public IHttpActionResult Post([FromBody]string username)
        {
            Notification n = new Notification()
            {
                CustomerId = this.cusService.Get(username).CustomerId,
                Seen = false,
                Time = DateTime.Now
            };

            context.Set<Notification>().Add(n);
            context.SaveChanges();
            return Created("/Noti/" + n.NotificationId, n);
        }

        /*
         * Update()
            /Noti/5
         */
        public IHttpActionResult Put([FromBody]Notification noti, [FromUri]int id)
        {
            noti.NotificationId = id;
            context.Entry<Notification>(noti).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return Ok(noti);
        }

        /*
         * Delete()
            /Noti/5
         */
        public IHttpActionResult Delete([FromUri]int id)
        {
            Notification noti = context.Set<Notification>().Find(id);
            if (noti != null)
            {
                context.Set<Notification>().Remove(noti);
                context.SaveChanges();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /*
         * Get()
            /Noti/Seen
         */
        [Route("api/Noti/Unseen")]
        public IHttpActionResult GetNotificationByUnseen()
        {
            List<Notification> notilist = context.Set<Notification>().Where(d => d.Seen == false).ToList();
            return Ok(notilist);
        }

        [Route("api/Noti/Seen")]
        public IHttpActionResult GetNotificationBySeen()
        {
            List<Notification> notilist = context.Set<Notification>().Where(d => d.Seen == true).ToList();
            return Ok(notilist);
        }
    }
}

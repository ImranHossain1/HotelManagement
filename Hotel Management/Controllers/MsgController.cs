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
    public class MsgController : ApiController
    {
        DataContext context = new DataContext();
        //List<Message> dlist = context.Set<Message>().ToList();
        //List<Message> deptlist = new List<Message>();
        /*
         * GetAll()
            /Contact
         */
        public IHttpActionResult Get()
        {
            //return Content(HttpStatusCode.OK, "Welcome");
            return Ok(context.Set<Message>().ToList());
        }

        /*
         * Get()
            /Room/2
         */
        public IHttpActionResult Get([FromUri]int id)
        {
            Message room = context.Set<Message>().Find(id);
            if (room == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(room);
        }

        /*
         * Create()
            /Rooms
         */
        public IHttpActionResult Post([FromBody]Message room)
        {
            room.Time = DateTime.Now;
            context.Set<Message>().Add(room);
            context.SaveChanges();
           // return Created(Url.Link("FindDepartment", new { id = .Id }), dept);
            return Created("/Msg/" + room.MessageId, room);
        }

        /*
         * Update()
            /Room/5
         */
        public IHttpActionResult Put([FromBody]Message room, [FromUri]int id)
        {
            room.MessageId = id;
            context.Entry<Message>(room).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return Ok(room);
        }

        /*
         * Delete()
            /Room/5
         */
        public IHttpActionResult Delete([FromUri]int id)
        {
            Message room = context.Set<Message>().Find(id);
            if (room != null)
            {
                context.Set<Message>().Remove(room);
                context.SaveChanges();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /*
         * Get()
            /Room/Search/roomname
         */
        [Route("api/Msg/Unseen")]
        public IHttpActionResult GetMsgByUnseen()
        {
            List<Message> roomlist = context.Set<Message>().Where(d => d.Seen == false).ToList();
            return Ok(roomlist);
        }

        [Route("api/Msg/Seen")]
        public IHttpActionResult GetMsgBySeen()
        {
            List<Message> roomlist = context.Set<Message>().Where(d => d.Seen == true).ToList();
            return Ok(roomlist);
        }
    }
}

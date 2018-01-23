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
    public class RoomAvController : ApiController
    {
        DataContext context = new DataContext();

        /*
         * Get()
            /Room/Search/true
         */
        [Route("api/roomav/true")]
        public IHttpActionResult GetRoomByAvailable()
        {
            List<RoomAv> roomlist = context.Set<RoomAv>().Where(d => d.Availability == true).ToList();
            return Ok(roomlist);
        }

        [Route("api/roomav/false")]
        public IHttpActionResult GetRoomByNotAvailable()
        {
            List<RoomAv> roomlist = context.Set<RoomAv>().Where(d => d.Availability == false).ToList();
            return Ok(roomlist);
        }

        [Route("api/roomav/Search/{name}")]
        public IHttpActionResult GetRoomByCatagory([FromUri]string name)
        {
            List<RoomAv> list = context.Set<RoomAv>().Where(d => d.Room.Catagory.Contains(name) && d.Availability==true).ToList();
            return Ok(list);
        }
    }
}

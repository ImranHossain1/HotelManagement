using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class RoomAv
    {

        public int RoomAvId { get; set; }

        public bool Availability { get; set; }

        public int RoomId { get; set; }
        //[ForeignKey("RoomId")]
        
        public virtual Room Room{ get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        //public virtual ICollection<Booking> Bookings { get; set; }

    }
}

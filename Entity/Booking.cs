using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required(ErrorMessage = "Please Insert customer Id")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please Insert Room Number")]
        public int RoomAvId { get; set; }
        public double TotalCost { get; set; }


        public virtual Customer Customer { get; set; }
        //public virtual RoomAv RoomAv { get; set; }
        public virtual ICollection<UserBalance> UserBalances { get; set; }


    }
}

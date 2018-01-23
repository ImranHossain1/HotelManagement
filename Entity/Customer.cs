using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required (ErrorMessage ="Please insert Your Full Name")]
        public string CustomerName { get; set; }

        public string Username { get; set; }
        public string CustomerEmail { get; set; }
        public string Catagory { get; set; }

        [Required(ErrorMessage = "Please insert Your Contact Number.")]
        public string CustomerContactNumber { get; set; }

        [Required(ErrorMessage = "Please insert How much room You Want")]
        public int RoomNeeded { get; set; }

        [Required(ErrorMessage = "Please Insert When will you come")]
        public DateTime ArrivaleTime { get; set; }

        [Required(ErrorMessage = "Please insert How Many days will you stay Here.")]
        public int Nights { get; set; }


        public virtual RoomAv RoomAvs { get; set; }
        //public virtual ICollection<Booking> Bookings { get; set; }

    }
}

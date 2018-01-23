using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class UserBalanceModel
    {
        public int UserBalanceModelId { get; set; }

        public int UserBalanceId { get; set; }

        public int BookingId { get; set; }

        public float UserBalanceAmount { get; set; }// Customer roomneeded*rent

        public float Paid { get; set; } //customer paid

        public float RemainingAcount { get; set; } //UserBalanceAmount-Paid

        [Required(ErrorMessage = "Please Insert customer Id")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please Insert Check In Date")]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "Please Insert Check Out Date")]
        public DateTime CheckOut { get; set; }

        [Required(ErrorMessage = "Please Insert Room Number")]
        public int RoomAvId { get; set; }


        [Required(ErrorMessage = "Please insert Your Full Name")]
        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Please insert Your Contact Number.")]
        public string CustomerContactNumber { get; set; }

        [Required(ErrorMessage = "Please insert How much room You Want")]
        public int RoomNeeded { get; set; }

        [Required(ErrorMessage = "Please Insert When will you come")]
        public DateTime ArrivaleTime { get; set; }

        [Required(ErrorMessage = "Please insert How Many days will you stay Here.")]
        public int Nights { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class UserBalance
    {
        public int UserBalanceId { get; set; }

        public int CustomerId { get; set; }

        public float UserBalanceAmount { get; set; }// Customer roomneeded*rent

        public float Paid { get; set; } //customer paid

        public float RemainingAcount { get; set; } //UserBalanceAmount-Paid

        public virtual Booking Booking { get; set; }
        public virtual Customer Customer { get; set; }



    }
}

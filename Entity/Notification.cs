using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public int CustomerId { get; set; }

        public DateTime Time { get; set; }

        public bool Seen { get; set; }
    }
}

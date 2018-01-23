using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Message
    {
        public int MessageId { get; set; }

        public DateTime Time { get; set; }

        public string SenderName { get; set; }

        public string SenderEmail { get; set; }

        public string SenderPhone { get; set; }

        public String MessageBody { get; set; }

        public bool Seen { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class RoomAvModel
    {
        public int RoomAvModelId { get; set; }
        public int RoomAvId { get; set; }

        public bool Availability { get; set; }


        public int RoomId { get; set; }
        //[ForeignKey("RoomId")]
        public string Catagory { get; set; }
        public float Rent { get; set; }
        //public virtual Room Room { get; set; }

    }
}

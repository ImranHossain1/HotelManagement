using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Room
    {
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Please Insert Catagory Name")]
        public string Catagory { get; set; }
        [Required(ErrorMessage = "Please Insert Room Cost")]
        public float Rent { get; set; }

        public virtual ICollection<RoomAv> RoomAvs { get; set; }
        

    }
}

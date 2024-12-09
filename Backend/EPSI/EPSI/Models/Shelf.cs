using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSI_Backend.Models
{
    public class Shelf
    {
        public int ID { get; set; }
        public int RoomID { get; set; }
        public Room? Room { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSI_Backend.Models
{
    public class Room
    {
        public int Id { get; set; }
        public required string RoomNumber { get; set; }
    }
}

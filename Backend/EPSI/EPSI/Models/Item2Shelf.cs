using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSI_Backend.Models
{
    public class Item2Shelf
    {
        public int ItemID { get; set; }
        public int ShelfID { get; set; }
        public int Amount { get; set; }
        public Item? Item { get; set; }
        public Shelf? Shelf { get; set; }

    }
}

using EPSI_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPSI_Backend.Context
{
    public class EPSI : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Shelf> Shelfs { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}

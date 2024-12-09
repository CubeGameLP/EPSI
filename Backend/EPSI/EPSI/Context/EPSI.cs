using EPSI.Configs;
using EPSI_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace EPSI.Context
{
    public class EPSIContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Item2Shelf> Item2Shelves { get; set; }


        public EPSIContext(DbContextOptions<EPSIContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string targetDirectory = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\..\EPSI\Database\EPSI.db"));
            optionsBuilder.UseSqlite($@"Data Source={targetDirectory}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new Item2ShelfConfig().Configure(modelBuilder.Entity<Item2Shelf>());
        }
    }
}

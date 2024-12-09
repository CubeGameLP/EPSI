using EPSI_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace EPSI.Configs
{
    public class Item2ShelfConfig : IEntityTypeConfiguration<Item2Shelf>
    {
        public void Configure(EntityTypeBuilder<Item2Shelf> builder)
        {
            builder.HasKey(key => new {key.ShelfID, key.ItemID});
        }
    }
}

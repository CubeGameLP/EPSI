using EPSI.Context;
using EPSI.DTOs;
using EPSI_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPSI.Controllers
{
    [Route("[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class Item2ShelfController : ControllerBase
    {
        private EPSIContext EPSIDB;

        public Item2ShelfController(EPSIContext dbContext)
        {
            EPSIDB = dbContext;
        }

        [HttpGet("GetItemsInRoom")]
        public List<ItemDTO> GetItemsInRoom(string RoomNumber)
        {
            return EPSIDB.Item2Shelves
               .Join(EPSIDB.Items,
                     item2Shelf => item2Shelf.ItemID,
                     item => item.Id,
                     (item2Shelf, item) => new { item2Shelf, item })
               .Join(EPSIDB.Shelves,
                     combined => combined.item2Shelf.ShelfID,
                     shelf => shelf.ID,
                     (combined, shelf) => new { combined.item2Shelf, combined.item, shelf })
               .Join(EPSIDB.Rooms,
                     combined => combined.shelf.RoomID,
                     room => room.Id,
                     (combined, room) => new { combined.item2Shelf, combined.item, combined.shelf, room })
               .Where(combined =>
                   combined.room.RoomNumber.ToLower().Contains(RoomNumber.ToLower()))
               .Select(combined => new ItemDTO
               {
                   ItemID = combined.item.Id,
                   ItemName = combined.item.Name,
                   RoomName = combined.room.RoomNumber,
                   RoomID = combined.room.Id,
                   ShelfID = combined.shelf.ID,
                   ItemAmount = combined.item2Shelf.Amount
               })
               .ToList();
        }

        [HttpPost("ChangeItemInShelf")]
        public void ChangeItemInShelf(string ItemName, int ShelfId, int Amount)
        {
            int ItemId = EPSIDB.Items.FirstOrDefault(x => x.Name == ItemName)!.Id;
            EPSIDB.Item2Shelves.Add(new Item2Shelf { Amount = Amount, ItemID = ItemId, ShelfID = ShelfId });
            EPSIDB.SaveChanges();
        }

        [HttpGet("GetItemsInShelf")]
        public List<Room> GetItemsInShelf(int ShelfId)
        {
            var Items = EPSIDB.Rooms.ToList();
            return Items;
        }
    }
}

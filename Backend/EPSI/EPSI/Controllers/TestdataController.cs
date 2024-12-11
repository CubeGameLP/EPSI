using EPSI.Context;
using EPSI.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EPSI.Controllers
{
    [Route("[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class TestdataController : ControllerBase
    {
        private readonly EPSIContext _EPSIDB;

        public TestdataController(EPSIContext dbContext)
        {
            _EPSIDB = dbContext;
        }

        [HttpGet("GetAllData")]
        public List<ItemDTO> GetData([FromQuery] string? filter)
        {
            filter = filter?.ToLower();

            var itemDTOs = _EPSIDB.Item2Shelves
                .Join(_EPSIDB.Items,
                      item2Shelf => item2Shelf.ItemID,
                      item => item.Id,
                      (item2Shelf, item) => new { item2Shelf, item })
                .Join(_EPSIDB.Shelves,
                      combined => combined.item2Shelf.ShelfID,
                      shelf => shelf.ID,
                      (combined, shelf) => new { combined.item2Shelf, combined.item, shelf })
                .Join(_EPSIDB.Rooms,
                      combined => combined.shelf.RoomID,
                      room => room.Id,
                      (combined, room) => new { combined.item2Shelf, combined.item, combined.shelf, room })
                .Where(combined =>
                    string.IsNullOrEmpty(filter) ||
                    combined.item.Name.ToLower().Contains(filter) ||
                    combined.room.RoomNumber.ToLower().Contains(filter) ||
                    combined.shelf.ID.ToString().Contains(filter))
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

            return itemDTOs;
        }

    }
}

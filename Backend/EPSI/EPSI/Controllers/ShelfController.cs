using EPSI.Context;
using EPSI_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPSI.Controllers
{
    [Route("[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        private EPSIContext EPSIDB;

        public ShelfController(EPSIContext dbContext)
        {
            EPSIDB = dbContext;
        }

        [HttpGet("GetAllShelves")]
        public List<Shelf> GetShelves()
        {
            var shelves = EPSIDB.Shelves.Include(o => o.Room).ToList();
            return shelves;
        }

        [HttpPost("AddShelf")]
        public void AddShelve(string RoomNumber)
        {
            int roomID = EPSIDB.Rooms.FirstOrDefault(r => r.RoomNumber == RoomNumber)?.Id ?? 0;
            EPSIDB.Shelves.Add(new Shelf { RoomID = roomID });
            EPSIDB.SaveChanges();
        }
    }
}

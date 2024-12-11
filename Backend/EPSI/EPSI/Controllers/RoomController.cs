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
    public class RoomController : ControllerBase
    {
        private EPSIContext EPSIDB;

        public RoomController(EPSIContext dbContext)
        {
            EPSIDB = dbContext;
        }

        [HttpGet("GetAllRooms")]
        public List<Room> GetRooms()
        {
            var rooms = EPSIDB.Rooms.ToList();
            return rooms;
        }

        [HttpPost("AddRoom")]
        public void AddRoom(string name)
        {
            EPSIDB.Rooms.Add(new Room { RoomNumber = name });
            EPSIDB.SaveChanges();
        }
        

    }
}

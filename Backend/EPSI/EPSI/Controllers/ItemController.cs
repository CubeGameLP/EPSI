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
    public class ItemController : ControllerBase
    {
        private EPSIContext EPSIDB;

        public ItemController(EPSIContext dbContext)
        {
            EPSIDB = dbContext;
        }

        [HttpGet("GetAllItems")]
        public List<Item> GetItems()
        {
            var items = EPSIDB.Items.ToList();
            return items;
        }

        [HttpPost("AddItem")]
        public void AddItems(string name)
        {
            EPSIDB.Items.Add(new Item { Name = name });
            EPSIDB.SaveChanges();
        }
        

    }
}

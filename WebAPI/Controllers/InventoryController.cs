using Microsoft.AspNetCore.Mvc;
using BL;
using Microsoft.Extensions.Caching.Memory;
using Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IBL _bl;
        private IMemoryCache _memoryCache;
        public InventoryController(IBL bl, IMemoryCache memoryCache)
        {
            _bl = bl;
            _memoryCache = memoryCache;
        }
        // GET: api/<InventoryController>
        [HttpGet]
        public List<Inventory> Get()
        {
            List<Inventory> allInvent;
            if (!_memoryCache.TryGetValue("inventory", out allInvent))
            {
                allInvent = _bl.GetAllInventories();
                _memoryCache.Set("inventory", allInvent, new TimeSpan(0, 0, 30));
            }
            return allInvent;
        }
        /// <summary>
        /// Gets all inventories by storefront Id
        /// </summary>
        /// <param name="storeFrontID">int storeFront id</param>
        /// <returns></returns>
        // GET api/<InventoryController>/5
        [HttpGet("{storeFrontID}")]
        public List<Inventory> Get(int storeFrontID)
        {
            return _bl.GetInventoriesbyStoreId(storeFrontID);
        }

        // POST api/<InventoryController>
        [HttpPost("{storeFrontID}")]
        public void Post(int storeFrontID, [FromBody] Inventory inventoryToAdd)
        {
            _bl.AddInventory(storeFrontID, inventoryToAdd);
        }

        // PUT api/<InventoryController>/5
        [HttpPut("{id}")]
        public void Put(int inventoryID, int addQuantity, [FromBody] string value)
        {
            _bl.AddMoreInventory(inventoryID, addQuantity);
        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

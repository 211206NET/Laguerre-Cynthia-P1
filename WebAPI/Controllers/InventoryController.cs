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
        public InventoryController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<InventoryController>
        [HttpGet]
        public List<Inventory> Get()
        {
            List<Inventory> allInvent = _bl.GetAllInventories();
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
        [HttpPut]
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

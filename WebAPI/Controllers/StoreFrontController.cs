using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Models;
using BL;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StoreFrontController : ControllerBase
    {
        private IBL _bl;
        
        
        public StoreFrontController(IBL bl)
        {
            _bl = bl;
            
        }
        // GET: api/<StoreFrontController>
        [HttpGet]
        public List<StoreFront> Get()
        {
            List<StoreFront> allStores;
            
                allStores = _bl.GetAllStoreFronts();
            
            return allStores;
        }

        // GET api/<StoreFrontController>/5
        [HttpGet("{id}")]
        public ActionResult<StoreFront> Get(int id)
        {
            StoreFront foundStore = _bl.GetStoreFrontbyId(id);
            foundStore.Inventories = _bl.GetInventoriesbyStoreId(id);
            foundStore.Orders = _bl.GetOrdersbyStoreId(id);
                if(foundStore.ID > -1)
            {
                return Ok(foundStore);
            }
                else
            {
                return NoContent();
            }
        }

        // POST api/<StoreFrontController>
        [HttpPost]
        public ActionResult Post([FromBody] StoreFront storeFrontToAdd)
        {
            _bl.AddStoreFront(storeFrontToAdd);
            return Created("StoreFront successfully added", storeFrontToAdd);
        }

        // PUT api/<StoreFrontController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StoreFrontController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [HttpGet("orders sorted by {storeFrontID}")]
        public ActionResult<Order> GetCustomerOrders(int storeFrontID, string sort)
        {
            StoreFront currStore = _bl.GetStoreFrontbyId(storeFrontID);
            if(sort == "newer")
            {
                List<Order> allOrders = _bl.GetOrdersbyStoreFrontIdOrderDESC(storeFrontID);
                if(allOrders.Count == 0)
                {
                    return NoContent();
                }
                return Ok(allOrders);
            }
            else if(sort == "older")
            {
                List<Order> allOrders = _bl.GetOrdersbyStoreFrontIdOrderASC(storeFrontID);
                if(allOrders.Count == 0)
                {
                    return NoContent();
                }
                return Ok(allOrders);
            }
            else if(sort == "higher")
            {
                List<Order> allOrders = _bl.GetOrdersbyStoreFrontIdTotalDESC(storeFrontID);
                if(allOrders.Count == 0)
                {
                    return NoContent();
                }
                return Ok(allOrders);
            }
            else if(sort == "lower")
            {
                List<Order> allOrders = _bl.GetOrdersbyStoreFrontIdTotalASC(storeFrontID);
                if(allOrders.Count == 0)
                {
                    return NoContent();
                }
                return Ok(allOrders);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

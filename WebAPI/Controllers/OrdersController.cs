using Microsoft.AspNetCore.Mvc;
using BL;
using Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IBL _bl;
        
        public OrdersController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public List<Order> Get()
        {
            List<Order> allorders = _bl.GetAllOrders();
            return allorders;
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post(string name, int storeFrontID, [FromBody] Order orderToAdd)
        {
            _bl.AddOrder(name, storeFrontID, orderToAdd);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

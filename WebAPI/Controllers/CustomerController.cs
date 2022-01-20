using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Models;
using BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IBL _bl;
        private IMemoryCache _memoryCache;
        public CustomerController(IBL bl, IMemoryCache memoryCache)
        {
            _bl = bl;
            _memoryCache = memoryCache;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public List<Customer> Get()
        {
            List<Customer> allCust;
            if(!_memoryCache.TryGetValue("customer", out allCust))
            {
            allCust = _bl.GetAllCustomers();
            _memoryCache.Set("customer", allCust, new TimeSpan(0, 0, 30));
            }
            return allCust;
            
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            Customer foundCust = _bl.GetCustomerbyId(id);
            if(foundCust.ID > -1)
            {
                return Ok(foundCust);
            }
            else
            {
                return NoContent();
            }
        }

        //// GET api/<CustomerController>/5
        //[HttpGet("{name}")]
        //public ActionResult<Customer> Get(string name)
        //{
        //    Customer foundCust = _bl.GetCustomerbyName(name);
        //    if (foundCust.ID > -1)
        //    {
        //        return Ok(foundCust);
        //    }
        //    else
        //    {
        //        return NoContent();
        //    }
        //}

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult Post([FromBody] Customer customerToAdd)
        {
                _bl.AddCustomer(customerToAdd);  
                return Created("Customer sucessfully added", customerToAdd);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using CustomExceptions;
using Serilog;
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

        //POST api/<CustomerController>
        [HttpPost]
        public ActionResult Post([FromBody] Customer customerToAdd)
        {
            try
            {
                _bl.AddCustomer(customerToAdd);
                return Created("Customer sucessfully added", customerToAdd);
            }
            catch (DuplicateRecordException ex)
            {
                return Conflict(ex.Message);
            }
        }

        //GET api/<CustomerController>/5
        [HttpGet("Login {email} and {password}")]
        public ActionResult<Customer> Login(string name, string email, string password)
        {
            if(_bl.Login(name, email, password))
            {
                return Ok("Your login information is correct!");
            }
            else
            {
                return BadRequest("Your login information is incorrect");
            }
        }
        // GET api/<CustomerController>/5
        [HttpGet("{name}")]
        public ActionResult<Customer> Get(string name)
        {
            Customer foundCust = _bl.GetCustomerbyName(name);
            if (foundCust.ID != 0)
            {
                return Ok(foundCust);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet("orders sorted with Customer {name}")]
        public ActionResult<Order> GetCustomerOrders(string name, string sort)
        {
            Customer foundCust = _bl.GetCustomerbyName(name);
            if(sort == "newer")
            {
                List<Order> allOrders = _bl.GetOrdersbyCustomerNameOrderDESC(name);
                if(allOrders.Count == 0)
                {
                    return NoContent();
                }
                return Ok(allOrders);
            }
            else if(sort == "older")
            {
                List<Order> allOrders = _bl.GetOrdersbyCustomerNameOrderASC(name);
                if(allOrders.Count == 0)
                {
                    return NoContent();
                }
                return Ok(allOrders);
            }
            else if(sort == "lower") 
            {
                List<Order> allOrders = _bl.GetOrdersbyCustomerNameTotalDESC(name);
                if(allOrders.Count == 0)
                {
                    return NoContent();
                }
                return Ok(allOrders);
            }
            else if(sort == "higher")
            {
                List<Order> allOrders = _bl.GetOrdersbyCustomerNameTotalASC(name);
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

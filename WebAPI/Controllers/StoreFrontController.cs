using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Models;
using BL;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StoreFrontController : ControllerBase
    {
        private IBL _bl;
        private IMemoryCache _memoryCache;
        public StoreFrontController(IBL bl, IMemoryCache memoryCache)
        {
            _bl = bl;
            _memoryCache = memoryCache;
        }
        // GET: api/<StoreFrontController>
        [HttpGet]
        public List<StoreFront> Get()
        {
            List<StoreFront> allStores;
            if (!_memoryCache.TryGetValue("storeFront", out allStores))
            {
                allStores = _bl.GetAllStoreFronts();
                _memoryCache.Set("storeFront", allStores, new TimeSpan(0, 0, 30));
            }
            return allStores;
        }

        // GET api/<StoreFrontController>/5
        [HttpGet("{id}")]
        public ActionResult<StoreFront> Get(int id)
        {
            StoreFront foundStore = _bl.GetStoreFrontbyId(id);
                if(foundStore.ID != 0)
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
    }
}

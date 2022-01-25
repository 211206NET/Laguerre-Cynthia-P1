using Microsoft.AspNetCore.Mvc;
using Models;
using BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineItemController : ControllerBase
    {
        private IBL _bl;

        public LineItemController(IBL bl)
        {
            _bl = bl;
        }

        // GET: api/<LineItemController>
        [HttpGet]
        public List<LineItem> Get()
        {
            List<LineItem> allLineItems = _bl.GetAllLineItems();
            return allLineItems;
        }

        // GET api/<LineItemController>/5
        [HttpGet("Line Order by {orderID}")]
        public List<LineItem> Get(int orderID)
        {
            return _bl.GetLineItemsbyOrderId(orderID);
        }

        // POST api/<LineItemController>
        [HttpPost("Create LineItem by {orderID}")]
        public void Post(int orderID, int inventoryID, int quantity, [FromBody] LineItem lineItemToAdd)
        {
            
            Inventory currInventory = _bl.GetInventorybyId(inventoryID);
            lineItemToAdd.ProductColor = currInventory.ProductColor;
            lineItemToAdd.ProductName = currInventory.ProductName;
            lineItemToAdd.ProductPrice = currInventory.ProductPrice;
            lineItemToAdd.StoreFrontID = currInventory.StoreFrontID;
            _bl.AddLineItem(orderID, inventoryID, quantity, lineItemToAdd);
            int addQuantity = currInventory.Quantity - quantity;
            _bl.AddMoreInventory(inventoryID, addQuantity);
        }

        // PUT api/<LineItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LineItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

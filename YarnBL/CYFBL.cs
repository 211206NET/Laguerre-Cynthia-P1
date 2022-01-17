namespace BL;

public class CYFBL : IBL
{
    private IRepo _dl;

    public CYFBL(IRepo repo)
    {
        _dl = repo;
    }

    /// <summary>
    /// Gets all customers
    /// </summary>
    /// <returns>List of all customers</returns>
    public List<Customer> GetAllCustomers()
    {
        
        return _dl.GetAllCustomers();
    }
    /// <summary>
    /// Adds new customer to the list
    /// </summary>
    /// <param name="customerToAdd">Customer object to add</param>
    public void AddCustomer(Customer customerToAdd)
    {
        _dl.AddCustomer(customerToAdd);
    }

/// <summary>
/// Gets all orders
/// </summary>
/// <returns>List of all orders</returns>
    public List<Order> GetAllOrders()
    {
        return _dl.GetAllOrders();
    }

/// <summary>
/// Addes new order to the list
/// </summary>
/// <param name="orderToAdd">Order object to add</param>
    public void AddOrder(Order orderToAdd)
    {
        _dl.AddOrder(orderToAdd);
    }

    /// <summary>
    /// Adds new lineItem to the list
    /// </summary>
    /// <returns>Lineitem object to add</returns>
    public List<LineItem> GetAllLineItems()
    {
        return _dl.GetAllLineItems();
    }


    /// <summary>
    /// Gets all storefronts
    /// </summary>
    /// <returns>List of all storefronts</returns>
    public List<StoreFront> GetAllStoreFronts()
    {
        
        return _dl.GetAllStoreFronts();
    }

    /// <summary>
    /// Adds new storefront to the list
    /// </summary>
    /// <param name="storefrontToAdd">Storefront object to add</param>
    public void AddStoreFront(StoreFront storefrontToAdd)
    {
        _dl.AddStoreFront(storefrontToAdd);
    }

/// <summary>
/// Gets all inventories
/// </summary>
/// <returns>List of inventories</returns>
    public List<Inventory> GetAllInventories()
    {
        return _dl.GetAllInventories();
    }

/// <summary>
/// Adds a new inventory to the list
/// </summary>
/// <param name="inventoryToAdd">inventory object to add</param>
    public void AddInventory(Inventory inventoryToAdd)
    {
        _dl.AddInventory(inventoryToAdd);
    }

/// <summary>
/// Adds a new lineItem to the list
/// </summary>
/// <param name="lineItemToAdd">lineitem object to add</param>
    public void AddLineItem(LineItem lineItemToAdd)
    {
        _dl.AddLineItem(lineItemToAdd);
    }

/// <summary>
/// Edits the OrderID number from the lineItem
/// </summary>
/// <param name="lineItemID">lineItem object</param>
/// <param name="orderID">order object to be changed</param>
    public void EditLineItem(int lineItemID, int orderID)
    {
        _dl.EditLineItem(lineItemID, orderID);
    }

/// <summary>
/// Gets all products
/// </summary>
/// <returns>List of all products</returns>
    public List<Product> GetAllProducts()
    {
        return _dl.GetAllProducts();
    }

/// <summary>
/// Adds new product to the list
/// </summary>
/// <param name="productToAdd">Product object to add</param>
    public void AddProduct(Product productToAdd)
    {
        _dl.AddProduct(productToAdd);
    }

/// <summary>
/// Adds quantity to inventory object
/// </summary>
/// <param name="inventoryID">Inventory ID</param>
/// <param name="addQuantity">Quantity added</param>
    public void AddMoreInventory(int inventoryID, int addQuantity)
    {
        _dl.AddMoreInventory(inventoryID, addQuantity);
    }

}
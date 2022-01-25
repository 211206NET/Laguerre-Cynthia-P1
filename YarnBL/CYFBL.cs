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
        if(!_dl.IsDuplicate(customerToAdd))
        {
            _dl.AddCustomer(customerToAdd);
        }
        else throw new DuplicateRecordException("A customer with same name, email and password already exists");
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
    public void AddInventory(int storeFrontID, Inventory inventoryToAdd)
    {
        _dl.AddInventory(storeFrontID, inventoryToAdd);
    }

/// <summary>
/// Adds a new lineItem to the list
/// </summary>
/// <param name="lineItemToAdd">lineitem object to add</param>
    public void AddLineItem(int orderID, int inventoryID, int quantity, LineItem lineItemToAdd)
    {
        _dl.AddLineItem(orderID, inventoryID, quantity, lineItemToAdd);
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
/// Adds quantity to inventory object
/// </summary>
/// <param name="inventoryID">Inventory ID</param>
/// <param name="addQuantity">Quantity added</param>
    public void AddMoreInventory(int inventoryID, int addQuantity)
    {
        _dl.AddMoreInventory(inventoryID, addQuantity);
    }

    /// <summary>
    /// Gets a Customer by their Id
    /// </summary>
    /// <param name="customerID">Customer object</param>
    /// <returns>Customer</returns>
    public Customer GetCustomerbyId(int customerID)
    {
        return _dl.GetCustomerbyId(customerID);
    }

    /// <summary>
    /// Gets a store front from its Id
    /// </summary>
    /// <param name="storeFrontID">Store front Object</param>
    /// <returns>StoreFront</returns>
    public StoreFront GetStoreFrontbyId(int storeFrontID)
    {
        return _dl.GetStoreFrontbyId(storeFrontID);
    }

    /// <summary>
    /// Gets inventory from Id
    /// </summary>
    /// <param name="inventoryID">inventory object</param>
    /// <returns>inventory</returns>
    public Inventory GetInventorybyId(int inventoryID)
    {
        return _dl.GetInventorybyId(inventoryID);
    }

    /// <summary>
    /// Gets customer from Name
    /// </summary>
    /// <param name="name">Customer object</param>
    /// <returns>Customer</returns>
    public Customer GetCustomerbyName(string name)
    {
        return _dl.GetCustomerbyName(name);
    }

    /// <summary>
    /// Gets inventories of a Store by store Id
    /// </summary>
    /// <param name="storeFrontID">store front object</param>
    /// <returns>inventory</returns>
    public List<Inventory> GetInventoriesbyStoreId(int storeFrontID)
    {
        return _dl.GetInventoriesbyStoreId(storeFrontID);
    }

    /// <summary>
    /// Gets orders by order Id
    /// </summary>
    /// <param name="orderID">order object</param>
    /// <returns>Order</returns>
    public Order GetOrderbyId(int orderID)
    {
        return _dl.GetOrderbyId(orderID);
    }

    /// <summary>
    /// Adds order to Customer and storefront
    /// </summary>
    /// <param name="name">customer object</param>
    /// <param name="storeFrontID">storefront object</param>
    /// <param name="orderToAdd">order object</param>
    public void AddOrder(string name, int storeFrontID, Order orderToAdd)
    {
        _dl.AddOrder(name, storeFrontID, orderToAdd);    
    }

    /// <summary>
    /// Gets all the line items in an order
    /// </summary>
    /// <param name="orderID">order object</param>
    /// <returns>line items</returns>
    public List<LineItem> GetLineItemsbyOrderId(int orderID)
    {
        return _dl.GetLineItemsbyOrderId(orderID);
    }

    /// <summary>
    /// Gets Orders by Customer Name by time 
    /// </summary>
    /// <param name="name">Customber object</param>
    /// <returns>orders</returns>
    public List<Order> GetOrdersbyCustomerNameOrderDESC(string name)
    {
        return _dl.GetOrdersbyCustomerNameOrderDESC(name);
    }

    /// <summary>
    /// Gets Orders by Customer Name by time 
    /// </summary>
    /// <param name="name">Customber object</param>
    /// <returns>orders</returns>
    public List<Order> GetOrdersbyCustomerNameOrderASC(string name)
    {
        return _dl.GetOrdersbyCustomerNameOrderASC(name);
    }

    /// <summary>
    /// Gets Orders by Customer Name by total 
    /// </summary>
    /// <param name="name">Customber object</param>
    /// <returns>orders</returns>
    public List<Order> GetOrdersbyCustomerNameTotalDESC(string name)
    {
        return _dl.GetOrdersbyCustomerNameTotalDESC(name);
    }

    /// <summary>
    /// Gets Orders by Customer Name by total 
    /// </summary>
    /// <param name="name">Customber object</param>
    /// <returns>orders</returns>
    public List<Order> GetOrdersbyCustomerNameTotalASC(string name)
    {
        return _dl.GetOrdersbyCustomerNameOrderASC(name);
    }

    /// <summary>
    /// Gets Orders by StoreFront Id by time 
    /// </summary>
    /// <param name="name">StoreFront object</param>
    /// <returns>orders</returns>
    public List<Order> GetOrdersbyStoreFrontIdOrderDESC(int storeFrontID)
    {
        return _dl.GetOrdersbyStoreFrontIdOrderDESC(storeFrontID);
    }

    /// <summary>
    /// Gets Orders by StoreFront Id by time 
    /// </summary>
    /// <param name="name">StoreFront object</param>
    /// <returns>orders</returns>
    public List<Order> GetOrdersbyStoreFrontIdOrderASC(int storeFrontID)
    {
        return _dl.GetOrdersbyStoreFrontIdOrderASC(storeFrontID);
    }

    /// <summary>
    /// Gets Orders by StoreFront Id by total 
    /// </summary>
    /// <param name="name">StoreFront object</param>
    /// <returns>orders</returns>
    public List<Order> GetOrdersbyStoreFrontIdTotalDESC(int storeFrontID)
    {
        return _dl.GetOrdersbyStoreFrontIdTotalDESC(storeFrontID);
    }

    /// <summary>
    /// Gets Orders by StoreFront Id by toal 
    /// </summary>
    /// <param name="name">StoreFront object</param>
    /// <returns>orders</returns>
    public List<Order> GetOrdersbyStoreFrontIdTotalASC(int storeFrontID)
    {
        return _dl.GetOrdersbyStoreFrontIdOrderASC(storeFrontID);
    }

    /// <summary>
    /// Gets Orders by StoreFront Id 
    /// </summary>
    /// <param name="name">StoreFront object</param>
    /// <returns>orders</returns>
    public List<Order> GetOrdersbyStoreId(int storeFrontID)
    {
        return _dl.GetOrdersbyStoreId(storeFrontID);
    }

    /// <summary>
    /// Check if login information is in the database
    /// </summary>
    /// <param name="name">Customer object</param>
    /// <param name="email">Customer object</param>
    /// <param name="password">Customer object</param>
    /// <returns></returns>
    public bool Login(string name, string email, string password)
    {
        return _dl.Login(name, email, password);
    }

    /// <summary>
    /// Gets Orders by Customer name  
    /// </summary>
    /// <param name="name">customer object</param>
    /// <returns>orders</returns>
    public List<Order> GetOrdersbyCustomerName(string name)
    {
        return _dl.GetOrdersbyCustomerName(name);
    }
}
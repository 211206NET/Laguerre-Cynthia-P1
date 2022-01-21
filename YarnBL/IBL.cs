namespace BL;

public interface IBL
{
    List<Customer> GetAllCustomers();

    void AddCustomer(Customer customerToAdd);

    List<Order> GetAllOrders();

    void AddOrder(Order orderToAdd);


    List<LineItem> GetAllLineItems();

    void AddLineItem(int orderID, int inventoryID, int quantity, LineItem lineItemToAdd);

    List<StoreFront> GetAllStoreFronts();

    void AddStoreFront(StoreFront storefrontToAdd);

    List<Inventory> GetAllInventories();

    void AddInventory(int storeFrontID, Inventory inventoryToAdd);

    void EditLineItem(int lineItemID, int orderID);

    //List<Product> GetAllProducts();

    //void AddProduct(int storeFrontID, Product productToAdd);
    
    void AddMoreInventory(int inventoryID, int addQuantity);

    Customer GetCustomerbyId(int customerID);
    Customer GetCustomerbyName(string name);
    
    StoreFront GetStoreFrontbyId(int storeFrontID);
    Inventory GetInventorybyId(int orderID);

    List<Inventory> GetInventoriesbyStoreId(int storeFrontID);
    Order GetOrderbyId(int orderID);
    void AddOrder(string name, int storeFrontID, Order orderToAdd);

    //List<Order> GetOrdersbyStoreId(int storeFrontID);
    //List<Order> GetOrdersbyCustomerName(string name);
}
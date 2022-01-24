namespace DL;

public interface IRepo
{
    List<Customer> GetAllCustomers();

    void AddCustomer (Customer customerToAdd);

    List<StoreFront> GetAllStoreFronts();

    void AddStoreFront (StoreFront storefrontToAdd);
    
    //List<Product> GetAllProducts();

    //void AddProduct (int storeFrontID, Product productToAdd);
    
    List<Inventory> GetAllInventories();

    void AddInventory (int storeFrontID, Inventory inventoryToAdd);

    List<Order> GetAllOrders();

    void AddOrder (Order orderToAdd);

    List<LineItem> GetAllLineItems();

    void AddLineItem (int orderID, int inventoryID, int quantity, LineItem lineItemToAdd); 

    void EditLineItem(int lineItemID, int orderID);

    void AddMoreInventory(int inventoryID, int addQuantity);   
    
    Customer GetCustomerbyId(int customerID);
    Customer GetCustomerbyName(string name);

    StoreFront GetStoreFrontbyId(int storeFrontID);
    Inventory GetInventorybyId(int inventoryID);
    List<Inventory> GetInventoriesbyStoreId(int storeFrontID);

    Order GetOrderbyId(int orderID);
    void AddOrder(string name, int storeFrontID, Order orderToAdd);
    List<LineItem> GetLineItemsbyOrderId(int orderID);

    List<Order> GetOrdersbyCustomerNameOrderDESC(string name);

    List<Order> GetOrdersbyCustomerNameOrderASC(string name);
    List<Order> GetOrdersbyCustomerNameTotalDESC(string name);
    List<Order> GetOrdersbyCustomerNameTotalASC(string name);

    List<Order> GetOrdersbyStoreFrontIdOrderDESC(int storeFrontID);

    List<Order> GetOrdersbyStoreFrontIdOrderASC(int storeFrontID);

    List<Order> GetOrdersbyStoreFrontIdTotalDESC(int storeFrontID);

    List<Order> GetOrdersbyStoreFrontIdTotalASC(int storeFrontID);
    List<Order> GetOrdersbyStoreId(int storeFrontID);
    bool Login(string name, string email, string password);

    bool IsDuplicate(Customer customer);
}
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

    void AddLineItem (string name, int inventoryID, int quantity, LineItem lineItemToAdd); 

    void EditLineItem(int lineItemID, int orderID);

    void AddMoreInventory(int inventoryID, int addQuantity);   
    
    Customer GetCustomerbyId(int customerID);
    Customer GetCustomerbyName(string name);

    StoreFront GetStoreFrontbyId(int storeFrontID);
    Inventory GetInventorybyId(int inventoryID);
    List<Inventory> GetInventoriesbyStoreId(int storeFrontID);
}
namespace DL;

public interface IRepo
{
    List<Customer> GetAllCustomers();

    void AddCustomer (Customer customerToAdd);

    List<StoreFront> GetAllStoreFronts();

    void AddStoreFront (StoreFront storefrontToAdd);
    
    List<Product> GetAllProducts();

    void AddProduct (Product productToAdd);
    
    List<Inventory> GetAllInventories();

    void AddInventory (Inventory inventoryToAdd);

    List<Order> GetAllOrders();

    void AddOrder (Order orderToAdd);

    List<LineItem> GetAllLineItems();

    void AddLineItem (LineItem lineItemToAdd); 

    void EditLineItem(int lineItemID, int orderID);

    void AddMoreInventory(int inventoryID, int addQuantity);   
}
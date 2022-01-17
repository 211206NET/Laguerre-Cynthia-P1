namespace BL;

public interface IBL
{
    List<Customer> GetAllCustomers();

    void AddCustomer(Customer customerToAdd);

    List<Order> GetAllOrders();

    void AddOrder(Order orderToAdd);


    List<LineItem> GetAllLineItems();

    void AddLineItem(LineItem lineItemToAdd);

    List<StoreFront> GetAllStoreFronts();

    void AddStoreFront(StoreFront storefrontToAdd);

    List<Inventory> GetAllInventories();

    void AddInventory(Inventory inventoryToAdd);

    void EditLineItem(int lineItemID, int orderID);

    List<Product> GetAllProducts();

    void AddProduct(Product productToAdd);
    
    void AddMoreInventory(int inventoryID, int addQuantity);

    // List<StoreOrder> GetAllStoreOrders();

    // void AddStoreOrders(StoreOrder storeOrderToAdd);
}
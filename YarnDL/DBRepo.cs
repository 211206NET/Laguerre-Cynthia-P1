using Microsoft.Data.SqlClient;
using System.Data;

namespace DL;

public class DBRepo : IRepo
{
    private string _connectionString;
    public DBRepo(string connectionString)
    {
        _connectionString = connectionString;
        //Console.WriteLine(_connectionString);
    }

    public List<Customer> GetAllCustomers()
    {
        List<Customer> allCustomers = new List<Customer>();

        using SqlConnection connection = new SqlConnection(_connectionString);
        string custSelect = "Select * From Customer";
        string orderSelect = "Select * From Orders";
        string lineItemSelect = "Select * From LineItem";

        DataSet CYFSet = new DataSet();

        using SqlDataAdapter custAdapter = new SqlDataAdapter(custSelect, connection);
        using SqlDataAdapter orderAdapter = new SqlDataAdapter(orderSelect, connection);
        using SqlDataAdapter lineItemAdapter = new SqlDataAdapter(lineItemSelect, connection);


        custAdapter.Fill(CYFSet, "Customer");
        orderAdapter.Fill(CYFSet, "Orders");
        lineItemAdapter.Fill(CYFSet, "LineItem");

        DataTable? custTable = CYFSet.Tables["Customer"];
        DataTable? orderTable = CYFSet.Tables["Orders"];
        DataTable? lineItemTable = CYFSet.Tables["LineItem"];

        if(custTable != null)
        {
            foreach(DataRow row in custTable.Rows)
            {
                Customer cust = new Customer(row);
                if (orderTable != null){
                    cust.Orders = orderTable.AsEnumerable().Where(r => (int) r["CustomerId"] == cust.ID).Select(
                        r => new Order(r)
                    ).ToList();

                    if(lineItemTable != null)
                    {
                        foreach(Order custOrder in cust.Orders!)
                        {
                            custOrder.LineItems = lineItemTable!.AsEnumerable().Where(r => (int) r["OrdersId"] == custOrder.ID).Select(
                            r => new LineItem(r)
                        ).ToList();
                        }
                    }
                }
                

                allCustomers.Add(cust);
            }
        }
        return allCustomers;
    }

    public void AddCustomer(Customer customerToAdd)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        string cmd = "INSERT INTO Customer (Id, Name, Email, Password) Values (@ID, @name, @email, @password)";
        using SqlCommand cmdAddCust = new SqlCommand(cmd, connection);
        cmdAddCust.Parameters.AddWithValue("@ID", customerToAdd.ID);
        cmdAddCust.Parameters.AddWithValue("@name", customerToAdd.Name);
        cmdAddCust.Parameters.AddWithValue("@email", customerToAdd.Email);
        cmdAddCust.Parameters.AddWithValue("@password", customerToAdd.Password);
        cmdAddCust.ExecuteNonQuery();
        Log.Information($"A customer with ID {customerToAdd.ID} and name {customerToAdd.Name} was added");
        connection.Close();
    }

    public List<StoreFront> GetAllStoreFronts()
    {
        List<StoreFront> allStoreFronts = new List<StoreFront>();

        using SqlConnection connection = new SqlConnection(_connectionString);
        string storeSelect = "SELECT * From StoreFront";
        string inventSelect = "SELECT * FROM Inventory";
        string orderSelect = "SELECT * FROM Orders";
        string lineItemSelect = "SELECT * FROM LineItem";

        DataSet CYFSet = new DataSet();

        using SqlDataAdapter storeAdapter = new SqlDataAdapter(storeSelect, connection);
        using SqlDataAdapter inventAdapter = new SqlDataAdapter(inventSelect, connection);
        using SqlDataAdapter orderAdapter = new SqlDataAdapter(orderSelect, connection);
        using SqlDataAdapter lineItemAdapter = new SqlDataAdapter(lineItemSelect, connection);

        storeAdapter.Fill(CYFSet, "StoreFront");
        inventAdapter.Fill(CYFSet, "Inventory");
        orderAdapter.Fill(CYFSet, "Orders");
        lineItemAdapter.Fill(CYFSet, "LineItem");

        DataTable? storeFrontTable = CYFSet.Tables["StoreFront"];
        DataTable? inventoryTable = CYFSet.Tables["Inventory"];
        DataTable? ordersTable = CYFSet.Tables["Orders"];
        DataTable? lineItemTable = CYFSet.Tables["LineItem"];

        if(storeFrontTable != null)
        {
            foreach(DataRow row in storeFrontTable.Rows)
            {
                StoreFront stores = new StoreFront(row);
                if (inventoryTable != null){
                    stores.Inventories = inventoryTable.AsEnumerable().Where(r => (int) r["StoreFrontId"] == stores.ID).Select(
                        r => new Inventory(r)
                    ).ToList();
                }
                if (ordersTable != null){
                    stores.Orders = ordersTable.AsEnumerable().Where(r => (int) r["StoreFrontId"] == stores.ID).Select(
                        r => new Order(r)
                    ).ToList();
                    if(lineItemTable != null)
                    {
                        foreach(Order storeOrder in stores.Orders!)
                        {
                            storeOrder.LineItems = lineItemTable!.AsEnumerable().Where(r => (int) r["OrdersId"] == storeOrder.ID).Select(
                            r => new LineItem(r)
                        ).ToList();
                        }
                    }
                }
                allStoreFronts.Add(stores);
            }
        }
        return allStoreFronts;
    }

    public void AddStoreFront(StoreFront storeFrontToAdd)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        string cmd = "INSERT INTO StoreFront (Id, Name, Address, City, State) Values (@ID, @name, @address, @city, @state)";
        using SqlCommand cmdAddStoreFront = new SqlCommand(cmd, connection);
        cmdAddStoreFront.Parameters.AddWithValue("@ID", storeFrontToAdd.ID);
        cmdAddStoreFront.Parameters.AddWithValue("@name", storeFrontToAdd.Name);
        cmdAddStoreFront.Parameters.AddWithValue("@address", storeFrontToAdd.Address);
        cmdAddStoreFront.Parameters.AddWithValue("@city", storeFrontToAdd.City);
        cmdAddStoreFront.Parameters.AddWithValue("@state", storeFrontToAdd.State);
        cmdAddStoreFront.ExecuteNonQuery();
        Log.Information($"A store  with Id {storeFrontToAdd.ID} store name {storeFrontToAdd.Name} was added.");
        connection.Close();
    }



        public List<Product> GetAllProducts()
    {
        List<Product> allProducts = new List<Product>();

        using SqlConnection connection = new SqlConnection(_connectionString);
        string productSelect = "Select * From Product";

        DataSet CYFSet = new DataSet();

        using SqlDataAdapter productAdapter = new SqlDataAdapter(productSelect, connection);

        productAdapter.Fill(CYFSet, "Product");

        DataTable? productTable = CYFSet.Tables["Product"];

        if(productTable != null)
        {
            foreach(DataRow row in productTable.Rows)
            {
                Product prod = new Product(row);
                allProducts.Add(prod);
            }
        }
        return allProducts;
    }

        public void AddProduct(Product productToAdd)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        string cmd = "INSERT INTO Product (Id, Name, Color, Description, Price) Values (@ID, @prodname,@color, @descrip, @price)";
        using SqlCommand cmdAddProduct = new SqlCommand(cmd, connection);
        cmdAddProduct.Parameters.AddWithValue("@ID", productToAdd.ID);
        cmdAddProduct.Parameters.AddWithValue("@prodname", productToAdd.ProductName);
        cmdAddProduct.Parameters.AddWithValue("@color", productToAdd.Color);
        cmdAddProduct.Parameters.AddWithValue("@descrip", productToAdd.Description);
        cmdAddProduct.Parameters.AddWithValue("@price", productToAdd.Price);
        Log.Information($"An product with id {productToAdd.ID} name {productToAdd.Color} {productToAdd.ProductName} that costs {productToAdd.Price} was added.");
        cmdAddProduct.ExecuteNonQuery();
        connection.Close();
    }

        public List<Inventory> GetAllInventories()
    {
        List<Inventory> allInventories = new List<Inventory>();

        using SqlConnection connection = new SqlConnection(_connectionString);
        string inventSelect = "Select * From Inventory";

        DataSet CYFSet = new DataSet();

        using SqlDataAdapter inventAdapter = new SqlDataAdapter(inventSelect, connection);

        inventAdapter.Fill(CYFSet, "Inventory");

        DataTable? inventoryTable = CYFSet.Tables["Inventory"];

        if(inventoryTable != null)
        {
            foreach(DataRow row in inventoryTable.Rows)
            {
                Inventory invent = new Inventory(row);
                allInventories.Add(invent);
            }
        }
        return allInventories;
    }
    public void AddInventory(Inventory inventoryToAdd)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string cmd = "INSERT INTO Inventory (Id, StoreFrontId, ProductId, Name, Color, Description, Price, Quantity) Values (@id, @storeID, @prodId, @prodName, @color, @descrip, @price, @qty)";

        using SqlCommand cmdAddInvent = new SqlCommand(cmd, connection);

        cmdAddInvent.Parameters.AddWithValue("@id", inventoryToAdd.ID);
        cmdAddInvent.Parameters.AddWithValue("@storeID", inventoryToAdd.StoreFrontID);
        cmdAddInvent.Parameters.AddWithValue("@prodId", inventoryToAdd.ProductID);
        cmdAddInvent.Parameters.AddWithValue ("@prodName", inventoryToAdd.ProductName);
        cmdAddInvent.Parameters.AddWithValue ("@color", inventoryToAdd.ProductColor);
        cmdAddInvent.Parameters.AddWithValue ("@descrip", inventoryToAdd.ProductDescription);
        cmdAddInvent.Parameters.AddWithValue ("@price", inventoryToAdd.ProductPrice);
        cmdAddInvent.Parameters.AddWithValue("@qty", inventoryToAdd.Quantity);
        cmdAddInvent.ExecuteNonQuery();
        Log.Information($"An inventory item with id {inventoryToAdd.ID} store Id {inventoryToAdd.StoreFrontID} and product name {inventoryToAdd.ProductName} of amount {inventoryToAdd.Quantity} was added.");
        connection.Close();
    }

    public List<Order> GetAllOrders()
    {
        List<Order> allOrders = new List<Order>();

        using SqlConnection connection = new SqlConnection(_connectionString);
        string orderSelect = "Select * From Orders";
        string lineItemSelect = "Select * From LineItem";

        DataSet CYFSet = new DataSet();

        using SqlDataAdapter orderAdapter = new SqlDataAdapter(orderSelect, connection);
        using SqlDataAdapter lineItemAdapter = new SqlDataAdapter(lineItemSelect, connection);

        orderAdapter.Fill(CYFSet, "Orders");
        lineItemAdapter.Fill(CYFSet, "LineItem");

        DataTable? orderTable = CYFSet.Tables["Orders"];
        DataTable? lineItemTable = CYFSet.Tables["LineItem"];

        if(orderTable != null)
        {
            foreach(DataRow row in orderTable.Rows)
            {
                Order orders = new Order(row);
                if (lineItemTable != null){
                    orders.LineItems = lineItemTable.AsEnumerable().Where(r => (int) r["OrdersId"] == orders.ID).Select(
                        r => new LineItem(r)
                    ).ToList();
                }
                allOrders.Add(orders);
            }
        }
        return allOrders;
    }
    public void AddOrder(Order orderToAdd)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        string cmd = "INSERT INTO Orders (Id, OrderDate, Total, CustomerId, StoreFrontId) Values (@ID, @OrderDate, @total, @custId, @storeId)";
        using SqlCommand cmdAddOrder = new SqlCommand(cmd, connection);
        cmdAddOrder.Parameters.AddWithValue("@ID", orderToAdd.ID);
        cmdAddOrder.Parameters.AddWithValue("@OrderDate", orderToAdd.OrderDate);
        cmdAddOrder.Parameters.AddWithValue("@total", orderToAdd.Total);
        cmdAddOrder.Parameters.AddWithValue("@custId", orderToAdd.CustomerID);
        cmdAddOrder.Parameters.AddWithValue("@storeId", orderToAdd.StoreFrontID);
        cmdAddOrder.ExecuteNonQuery();
        Log.Information($"An order item with id {orderToAdd.ID} store Id {orderToAdd.StoreFrontID} and customer Id {orderToAdd.CustomerID} of amount {orderToAdd.Total} was added.");
        connection.Close();
    }

        public List<LineItem> GetAllLineItems()
    {
        List<LineItem> allLineItems = new List<LineItem>();

        using SqlConnection connection = new SqlConnection(_connectionString);
        string lineItemSelect = "Select * From LineItem";

        DataSet CYFSet = new DataSet();

        using SqlDataAdapter lineItemAdapter = new SqlDataAdapter(lineItemSelect, connection);

        lineItemAdapter.Fill(CYFSet, "LineItem");

        DataTable? LineItemTable = CYFSet.Tables["LineItem"];

        if(LineItemTable != null)
        {
            foreach(DataRow row in LineItemTable.Rows)
            {
                LineItem items = new LineItem(row);
                allLineItems.Add(items);
            }
        }
        return allLineItems;
    }

    public void AddLineItem(LineItem lineItemToAdd)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        string cmd = "INSERT INTO LineItem (Id, ProductId, ProductName, ProductColor, ProductPrice, Quantity, OrdersId) Values (@id, @prodID, @prodName, @prodColor, @prodPrice, @qty, @orderId)";
        using SqlCommand cmdAddLineItem = new SqlCommand(cmd, connection);
        cmdAddLineItem.Parameters.AddWithValue("@id", lineItemToAdd.ID);
        cmdAddLineItem.Parameters.AddWithValue("@prodID", lineItemToAdd.ProductID);
        cmdAddLineItem.Parameters.AddWithValue("@prodName", lineItemToAdd.ProductName);
        cmdAddLineItem.Parameters.AddWithValue("@prodColor", lineItemToAdd.ProductColor);
        cmdAddLineItem.Parameters.AddWithValue("@prodPrice", lineItemToAdd.ProductPrice);
        cmdAddLineItem.Parameters.AddWithValue("@qty", lineItemToAdd.Quantity);
        cmdAddLineItem.Parameters.AddWithValue("@orderId", lineItemToAdd.OrderID);
        Log.Information($"An lineitem with id {lineItemToAdd.ID} and quantity {lineItemToAdd.Quantity} was add to Cart.");
        cmdAddLineItem.ExecuteNonQuery();
        connection.Close();
    }

    public void EditLineItem(int LineItemID, int OrderID)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string editlineItem = $"UPDATE LineItem SET OrdersId = @orderID WHERE ID = @LineItemID";
        using SqlCommand lineItemcmd = new SqlCommand(editlineItem, connection);

        lineItemcmd.Parameters.AddWithValue("@LineItemID", LineItemID);
        lineItemcmd.Parameters.AddWithValue("@orderID", OrderID);
        lineItemcmd.ExecuteNonQuery();
        Log.Information($"Line Item with ID {LineItemID} order ID was changed to {OrderID}");
        connection.Close();
    }

    public void AddMoreInventory(int InventoryID, int addQuantity)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string addInventCmd = $"UPDATE Inventory SET Quantity = @qty WHERE ID = @InventoryId";
        using SqlCommand inventcmd = new SqlCommand(addInventCmd, connection);

        inventcmd.Parameters.AddWithValue("InventoryId", InventoryID);
        inventcmd.Parameters.AddWithValue("@qty", addQuantity);
        inventcmd.ExecuteNonQuery();
        Log.Information($"The item with Inventory ID {InventoryID} was increase to Quantity {addQuantity}");
        connection.Close();
        
    }

}
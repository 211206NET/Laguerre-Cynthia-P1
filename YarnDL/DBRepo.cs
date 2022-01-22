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
        string cmd = "INSERT INTO Customer (Name, Email, Password) Values (@name, @email, @password)";
        using SqlCommand cmdAddCust = new SqlCommand(cmd, connection);
        cmdAddCust.Parameters.AddWithValue("@name", customerToAdd.Name);
        cmdAddCust.Parameters.AddWithValue("@email", customerToAdd.Email);
        cmdAddCust.Parameters.AddWithValue("@password", customerToAdd.Password);
        cmdAddCust.ExecuteNonQuery();
        Log.Information($"A customer with and name {customerToAdd.Name} and email {customerToAdd.Email} was added");
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
        string cmd = "INSERT INTO StoreFront (Name, Address, City, State) Values (@name, @address, @city, @state)";
        using SqlCommand cmdAddStoreFront = new SqlCommand(cmd, connection);
        cmdAddStoreFront.Parameters.AddWithValue("@name", storeFrontToAdd.Name);
        cmdAddStoreFront.Parameters.AddWithValue("@address", storeFrontToAdd.Address);
        cmdAddStoreFront.Parameters.AddWithValue("@city", storeFrontToAdd.City);
        cmdAddStoreFront.Parameters.AddWithValue("@state", storeFrontToAdd.State);
        cmdAddStoreFront.ExecuteNonQuery();
        Log.Information($" Store name {storeFrontToAdd.Name} was added.");
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
    public void AddInventory(int storeFrontID, Inventory inventoryToAdd)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string cmd = "INSERT INTO Inventory (StoreFrontId, Quantity, ProductName, ProductColor, ProductDescription, ProductPrice) Values (@storeID, @qty, @prodname, @prodcolor, @desc, @price)";

        using SqlCommand cmdAddInvent = new SqlCommand(cmd, connection);

        cmdAddInvent.Parameters.AddWithValue("@storeID", inventoryToAdd.StoreFrontID);
        cmdAddInvent.Parameters.AddWithValue("@qty", inventoryToAdd.Quantity);
        cmdAddInvent.Parameters.AddWithValue("@prodname", inventoryToAdd.ProductName);
        cmdAddInvent.Parameters.AddWithValue("@prodcolor", inventoryToAdd.ProductColor);
        cmdAddInvent.Parameters.AddWithValue("@desc", inventoryToAdd.ProductDescription);
        cmdAddInvent.Parameters.AddWithValue("@price", inventoryToAdd.ProductPrice);
        cmdAddInvent.ExecuteNonQuery();
        //Log.Information($"An inventory item with store Id {inventoryToAdd.StoreFrontID} and product name {inventoryToAdd.Item.ProductName} of amount {inventoryToAdd.Quantity} was added.");
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
    public void AddOrder(string name, int storeFrontID, Order orderToAdd)
    {
        //Order newOrder = new Order();
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        string cmd = "INSERT INTO Orders (OrderDate, Total, CustomerId, StoreFrontId) Values (@OrderDate, @total, @custId, @storeId)";
        using SqlCommand cmdAddOrder = new SqlCommand(cmd, connection);
        Customer currCustomer = GetCustomerbyName(name);
        int CustomerID = currCustomer.ID;
        StoreFront currStoreFront = GetStoreFrontbyId(storeFrontID);
        int StoreFrontID = currStoreFront.ID;
        DateTime OrderDate = DateTime.Now;
        decimal Total = orderToAdd.CalculateTotal();

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

    public void AddLineItem(int orderID, int inventoryID, int quantity, LineItem lineItemToAdd)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        string cmd = "INSERT INTO LineItem (InventoryId, ProductName, ProductColor, ProductPrice, Quantity, OrdersId) Values (@inventID, @name, @color, @price, @qty, @orderId)";
        using SqlCommand cmdAddLineItem = new SqlCommand(cmd, connection);

        Inventory currInvent = GetInventorybyId(inventoryID);
        int InventoryID = GetInventorybyId(inventoryID).ID;
        string? ProductName = GetInventorybyId(inventoryID).ProductName;
        string? ProductColor = GetInventorybyId(inventoryID).ProductColor;
        decimal ProductPrice = GetInventorybyId(inventoryID).ProductPrice;
        Order currOrder = GetOrderbyId(orderID);
        int OrderID = currOrder.ID;
        cmdAddLineItem.Parameters.AddWithValue("@inventID", lineItemToAdd.InventoryID);
        cmdAddLineItem.Parameters.AddWithValue("@name", lineItemToAdd.ProductName);
        cmdAddLineItem.Parameters.AddWithValue("@color", lineItemToAdd.ProductColor);
        cmdAddLineItem.Parameters.AddWithValue("@price", lineItemToAdd.ProductPrice);
        cmdAddLineItem.Parameters.AddWithValue("@qty", lineItemToAdd.Quantity);
        cmdAddLineItem.Parameters.AddWithValue("@orderId", lineItemToAdd.OrderID);
        //Log.Information($"An lineitem with product id {lineItemToAdd.Item.ID} and quantity {lineItemToAdd.Quantity} was add to Cart.");
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

    public Customer GetCustomerbyId(int customerID)
    {
        string query = "Select * From Customer Where Id = @custId";
        SqlConnection connection = new SqlConnection(_connectionString);

        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        SqlParameter param = new SqlParameter("@custId", customerID);
        cmd.Parameters.Add(param);

        using SqlDataReader reader = cmd.ExecuteReader();
        Customer customer = new Customer();
        if(reader.Read())
        {
            customerID = reader.GetInt32(0);
            customer.Name = reader.GetString(1);
            customer.Email = reader.GetString(2);
            customer.Password = reader.GetString(3);
        }
        connection.Close();
        return customer;
    }

    public StoreFront GetStoreFrontbyId(int storeFrontID)
    {
        string query = "Select * From StoreFront Where Id = @storeID";
        using SqlConnection connection = new SqlConnection(_connectionString);

        connection.Open();

        using SqlCommand cmd = new SqlCommand(query, connection);
        SqlParameter param = new SqlParameter("@storeID", storeFrontID);
        cmd.Parameters.Add(param);

        using SqlDataReader reader = cmd.ExecuteReader();
        StoreFront store = new StoreFront();
        if (reader.Read())
        {
            storeFrontID = reader.GetInt32(0);
            store.Name = reader.GetString(1);
            store.Address = reader.GetString(2);
            store.City = reader.GetString(3);
            store.State = reader.GetString(4);
        }
        connection.Close();
        return store;
    }
    public Inventory GetInventorybyId(int inventoryID)
    {
        string query = "Select * From Inventory Where Id = @inventID";
        using SqlConnection connection = new SqlConnection(_connectionString);

        connection.Open();

        using SqlCommand cmd = new SqlCommand(query, connection);
        SqlParameter param = new SqlParameter("@inventID", inventoryID);
        cmd.Parameters.Add(param);


        using SqlDataReader reader = cmd.ExecuteReader();
        Inventory invent = new Inventory();
        if (reader.Read())
        {
            inventoryID = reader.GetInt32(0);
            invent.StoreFrontID = reader.GetInt32(1);
            invent.Quantity = reader.GetInt32(2);
            invent.ProductName = reader.GetString(3);
            invent.ProductColor = reader.GetString(4);
            invent.ProductDescription = reader.GetString(5);
            invent.ProductPrice = reader.GetDecimal(6);
        }
        connection.Close();
        return invent;

    }
    

    public Customer GetCustomerbyName(string name)
    {
        string query = "Select * From Customer Where Name = @name";
        SqlConnection connection = new SqlConnection(_connectionString);

        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        SqlParameter param = new SqlParameter("@name", name);
        cmd.Parameters.Add(param);

        using SqlDataReader reader = cmd.ExecuteReader();
        Customer customer = new Customer();
        if (reader.Read())
        {
            customer.ID = reader.GetInt32(0);
            customer.Name = reader.GetString(1);
            customer.Email = reader.GetString(2);
            customer.Password = reader.GetString(3);
        }
        connection.Close();
        return customer;
    }

    public bool Login(string name, string email, string password)
    {
        Customer currentCust = GetCustomerbyName(name);
        if(currentCust.Email == email && currentCust.Password == password)
        {
            return true;
        }
        return false;
        
    }

    public List<Inventory> GetInventoriesbyStoreId(int storeFrontID)
    {
        string selectcmd = "Select * From Inventory Where StoreFrontId = @storeID";
        SqlConnection connection = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand(selectcmd, connection);
        SqlParameter param = new SqlParameter("@storeID", storeFrontID);
        cmd.Parameters.Add(param);

        DataSet inventSet = new DataSet();

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        adapter.Fill(inventSet, "inventory");

        DataTable inventTable = inventSet.Tables["inventory"];

        List<Inventory> inventories = new List<Inventory>();
        foreach (DataRow row in inventTable.Rows)
        {
            inventories.Add(new Inventory
            {
                ID = (int)row["Id"],
                Quantity = (int) row["Quantity"],
                ProductName = row["ProductName"].ToString(),
                ProductPrice = (decimal) row["ProductPrice"],
                ProductDescription = row["ProductDescription"].ToString(),
                ProductColor = row["ProductColor"].ToString()

            });
            
        }
        return inventories;
    }

    public Order GetOrderbyId(int orderID)
    {
        string query = "Select * From Orders Where Id = @orderID";
        using SqlConnection connection = new SqlConnection(_connectionString);

        connection.Open();

        using SqlCommand cmd = new SqlCommand(query, connection);
        SqlParameter param = new SqlParameter("@orderID", orderID);
        cmd.Parameters.Add(param);


        using SqlDataReader reader = cmd.ExecuteReader();
        Order orders = new Order();
        if (reader.Read())
        {
            orderID = reader.GetInt32(0);
            orders.OrderDate = reader.GetDateTime(1);
            orders.Total = reader.GetDecimal(2);
            orders.CustomerID = reader.GetInt32(3);
            orders.StoreFrontID = reader.GetInt32(4);
        }
        connection.Close();
        return orders;

    }

    public List<LineItem> GetLineItemsbyOrderId(int orderID)
    {

        string selectcmd = "Select * From LineItem Where OrdersId = @orderID";
        SqlConnection connection = new SqlConnection(_connectionString);
        SqlCommand cmd = new SqlCommand(selectcmd, connection);
        SqlParameter param = new SqlParameter("@orderID", orderID);
        cmd.Parameters.Add(param);

        DataSet lineItemSet = new DataSet();

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        adapter.Fill(lineItemSet, "lineItem");

        DataTable lineItemTable = lineItemSet.Tables["lineItem"];

        List<LineItem> lineItems = new List<LineItem>();
        foreach (DataRow row in lineItemTable.Rows)
        {
            lineItems.Add(new LineItem
            {
                ID = (int)row["Id"],
                InventoryID = (int) row["InventoryId"],
                ProductName = row["ProductName"].ToString(),
                ProductColor = row["ProductColor"].ToString(),
                ProductPrice = (decimal)row["ProductPrice"],
                Quantity = (int)row["Quantity"],
                OrderID = (int) row["OrdersId"]

            });

        }
        return lineItems;
    }
}
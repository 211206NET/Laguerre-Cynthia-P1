// using System.Text.Json;

// namespace DL;

// public class FileRepo : IRepo
// {
//     public FileRepo()
//     {}

// private string filePath = "../YarnDL/Customers.json";
// /// <summary>
// /// Gets all customers from a file
// /// </summary>
// /// <returns>List of all customers</returns>
//     public List<Customer> GetAllCustomers()
//     {
//         string jsonString = "";
//         try
//         {
//             jsonString = File.ReadAllText(filePath);
//         }
//         catch(FileNotFoundException ex)
//         {
//             Console.WriteLine(ex.Message);
//         }
//         catch(Exception ex)
//         {
//             Console.WriteLine(ex.Message);
//         }
//         return JsonSerializer.Deserialize<List<Customer>>(jsonString) ?? new List<Customer>();
//     }

// /// <summary>
// /// Adds a customer to the list and then writes to a file
// /// </summary>
// /// <param name="customerToAdd">customer object to be added</param>
//     public void AddCustomer (Customer customerToAdd)
//     {
//         //adds a customer to a file

//         List<Customer> allCustomers = GetAllCustomers();
//         allCustomers.Add(customerToAdd);

//         string JsonString = JsonSerializer.Serialize(allCustomers);
//         File.WriteAllText(filePath, JsonString);
//     }
//         public List<Order> GetAllOrders()
//     {
//         string jsonString = File.ReadAllText(filePath);
//         return JsonSerializer.Deserialize<List<Order>>(jsonString);
//     }


//     public void AddOrder (Order orderToAdd)
//     {
        

//         List<Order> allOrder = GetAllOrders();
//         allOrder.Add(orderToAdd);

//         string JsonString = JsonSerializer.Serialize(allOrder);
//         File.WriteAllText(filePath, JsonString);
//     }

//     public List<LineItem> GetAllLineItems()
//     {
//         string jsonString = File.ReadAllText(filePath);
//         return JsonSerializer.Deserialize<List<LineItem>>(jsonString);
//     }


//     public void AddLineItem (LineItem lineItemToAdd)
//     {
        

//         List<LineItem> allLineItem = GetAllLineItems();
//         allLineItem.Add(lineItemToAdd);

//         string JsonString = JsonSerializer.Serialize(allLineItem);
//         File.WriteAllText(filePath, JsonString);
//     }

//     private string filePathStore = "../YarnDL/StoreFronts.json";
// /// <summary>
// /// Gets all storefronts
// /// </summary>
// /// <returns>List of all storefronts</returns>
//     public List<StoreFront> GetAllStoreFronts()
//     {
//         //returns all customers written in the file
//         string jsonString = File.ReadAllText(filePathStore);
//         return JsonSerializer.Deserialize<List<StoreFront>>(jsonString);
//     }

// /// <summary>
// /// Adds a storefront to the list and then writes to a file
// /// </summary>
// /// <param name="storefrontToAdd">storefront object to be added</param>
//     public void AddStoreFront (StoreFront storefrontToAdd)
//     {
//         //adds a storefront to a file

//         List<StoreFront> allStoreFronts = GetAllStoreFronts();
//         allStoreFronts.Add(storefrontToAdd);

//         string JsonString = JsonSerializer.Serialize(allStoreFronts);
//         File.WriteAllText(filePathStore, JsonString);
//     }

// //     private string fileProductPath = "../YarnDL/Products.json";
// //     public List<Product> GetAllProducts()
// //     {
// //         string jsonString = File.ReadAllText(fileProductPath);
// //         return JsonSerializer.Deserialize<List<Product>>(jsonString);
// //     }

// // /// <summary>
// // /// Adds a product to the list and then writes to a file
// // /// </summary>
// // /// <param name="productToAdd">product object to be added</param>
// //     public void AddProduct (Product productToAdd)
// //     {
        

// //         List<Product> allProducts = GetAllProducts();
// //         allProducts.Add(productToAdd);

// //         string JsonString = JsonSerializer.Serialize(allProducts);
// //         File.WriteAllText(fileProductPath, JsonString);
// //     }    

// private string filePathInv = "../YarnDL/Inventory.json";
//     public List<Inventory> GetAllInventories()
//     {
//         string jsonString = File.ReadAllText(filePathInv);
//         return JsonSerializer.Deserialize<List<Inventory>>(jsonString);
//     }


//     public void AddInventory (Inventory inventoryToAdd)
//     {
        

//         List<Inventory> allInventory = GetAllInventories();
//         allInventory.Add(inventoryToAdd);

//         string JsonString = JsonSerializer.Serialize(allInventory);
//         File.WriteAllText(filePathInv, JsonString);
//     }

//     public List<StoreOrder> GetAllStoreOrders()
//     {
//         string jsonString = File.ReadAllText(filePathStore);
//         return JsonSerializer.Deserialize<List<StoreOrder>>(jsonString);
//     }


//     public void AddStoreOrder (StoreOrder storeOrderToAdd)
//     {
        

//         List<StoreOrder> allStoreOrder = GetAllStoreOrders();
//         allStoreOrder.Add(storeOrderToAdd);

//         string JsonString = JsonSerializer.Serialize(allStoreOrder);
//         File.WriteAllText(filePathStore, JsonString);
//     }
// }
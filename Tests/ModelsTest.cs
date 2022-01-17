using Xunit;
using Models;
using CustomExceptions;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace Tests;

public class ModelsTest
{
    
    [Fact]
    public void CustomerShouldCreate()
    {
        //Arrange adding model and reference to models

        //Act

        Customer testCustomer = new Customer();

        //Assert 

        Assert.NotNull(testCustomer);
    }

    [Fact]
    public void OrderShouldCreate()
    {
        //Arrange adding model and reference to models

        //Act

        Order testOrder = new Order();

        //Assert 
        Assert.NotNull(testOrder);
    }

    [Fact]
    public void StoreFrontShouldSetValidData()
    {
        //Arrange
        StoreFront testStoreFront = new StoreFront();
        
        string name = "Test Name";
        string address = "Test Address";
        string city = "Test City";
        string state = "Test State";

        //Act
        testStoreFront.Name = name;
        testStoreFront.Address = address;
        testStoreFront.City = city;
        testStoreFront.State = state;

        //Assert
        Assert.Equal(name, testStoreFront.Name);
        Assert.Equal(address, testStoreFront.Address);
        Assert.Equal(city, testStoreFront.City);
        Assert.Equal(state, testStoreFront.State);
    }

    // [Fact]
    // public void InventoryShouldSetValidData()
    // {
    //     //Arrange
    //     Inventory testInventory = new Inventory();

    //     string inventoryName = "Test Inventory Name";
    //     string color = "Test color";
    //     string description = "Test description";

    //     //Act

    //     testInventory.InventoryName = inventoryName;
    //     testInventory.Color = color;
    //     testInventory.Description = description;

    //     //Assert

    //     Assert.Equal(inventoryName, testInventory.InventoryName);
    //     Assert.Equal(color, testInventory.Color);
    //     Assert.Equal(description, testInventory.Description);
    // }

        [Fact]
    public void ProductShouldSetValidData()
    {
        //Arrange
        Product testProduct = new Product();

        string productName = "Test Product Name";
        string color = "Test color";
        string description = "Test City";

        //Act

        testProduct.ProductName = productName;
        testProduct.Color = color;
        testProduct.Description = description;

        //Assert

        Assert.Equal(productName, testProduct.ProductName);
        Assert.Equal(color, testProduct.Color);
        Assert.Equal(description, testProduct.Description);
    }

    // [Fact]
    // public void CustomerShouldBeAbleToSignIn()
    // {
    //     //Assert
        
    // }
    // [Theory]
    // [InlineData("$$2hr#a$%")]
    // [InlineData("     ")]
    // [InlineData(null)]
    // [InlineData("")]
    // public void CustomerShouldNotSetInvalidName(string input)
    // {

    //     //Arrange: 
    //     Customer testCustomer = new Customer();

    //     //Act: setting an invalid name as the customer

    //     //Assert:
    //     Assert.Throw<InputInvalidException>(() => testCustomer.Name = input);
    // }

    // [Fact]
    // public void StoreShouldhaveCustomToStringMethod()
    // {
    //     //Arrange 
    //     StoreFront testStoreFront = new StoreFront{
    //         Name = "Test Name",
    //         Address = "Test Address",
    //         City = "Test City",
    //         State = "Test State",
    //     };
    //     string expectedOutput = "Name: Test Name \nAddress: Test Address \nCity: Test City \nState: Test State";
    //     Assert.Equal(expectedOutput, testStoreFront.Tostring());
    // }


    // [Fact]
    // public void OrderShouldhaveCustomToStringMethod()
    // {
    //     //Arrange 
    //     Order testOrder = new Order{
    //         ID = 9836,
    //         Name = "Tests Name",
    //         Color = "Test Color",
    //         Description = "Test Description",
    //         Price = 4.50,
    //     };
    //     string expectedOutput = "Name: Test Name \nColor: Test Color \nDescription: Test Description \nPrice: 4.50";
    //     Assert.Equal(expectedOutput, testOrder.Tostring());
    // }

    [Fact]
    public void StoreInventoryShouldBeAbleToBeSet()
    {
        //Arrange
        StoreFront testStoreFront = new StoreFront();
        List<Inventory> testInventories = new List<Inventory>();
        int testInventoryCount = 0;
        
        //Act
        testStoreFront.Inventories = testInventories;

        //Assert
        Assert.NotNull(testStoreFront.Inventories);
        Assert.Equal(testInventoryCount, testStoreFront.Inventories.Count);
    }

    [Fact]
    public void StoreFrontOrderShouldBeAbleToBeSet()
    {
        //Arrange
        StoreFront testStoreFront = new StoreFront();
        List<Order> testOrders = new List<Order>();
        int testOrderCount = 0;
        
        //Act
        testStoreFront.Orders = testOrders;

        //Assert
        Assert.NotNull(testStoreFront.Orders);
        Assert.Equal(testOrderCount, testStoreFront.Orders.Count);
    }

    [Fact]
    public void LineItemShouldBeAbleToBeSet()
    {
        //Arrange
        Order testOrder = new Order();
        List<LineItem> testLineItems = new List<LineItem>();
        int testLineItemCount = 0;
        
        //Act
        testOrder.LineItems = testLineItems;

        //Assert
        Assert.NotNull(testOrder.LineItems);
        Assert.Equal(testLineItemCount, testOrder.LineItems.Count);
    }

    [Fact]
    public void CustomerOrdersShouldBeAbleToBeSet()
    {
        //Arrange
        Customer testCustomer = new Customer();
        List<Order> testOrders = new List<Order>();
        int testOrderCount = 0;
        
        //Act
        testCustomer.Orders = testOrders;

        //Assert
        Assert.NotNull(testCustomer.Orders);
        Assert.Equal(testOrderCount, testCustomer.Orders.Count);
    }
}
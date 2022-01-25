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


    [Theory]
    [InlineData(3)]
    [InlineData(25)]
    [InlineData(55)]
    public void InventoryProductShouldHaveQuantity(int quantity)
    {

        //Arrange
        Inventory testInventory = new Inventory();

        //Act
        testInventory.Quantity = quantity;

        //Assert
        Assert.Equal(testInventory.Quantity,quantity);

    }

    [Theory]
    [InlineData(7)]
    [InlineData(33)]
    [InlineData(98)]
    public void LineItemProductShouldHaveQuantity(int quantity)
    {

        //Arrange
        LineItem testLineItem = new LineItem();

        //Act
        testLineItem.Quantity = quantity;

        //Assert
        Assert.Equal(testLineItem.Quantity,quantity);

    }

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
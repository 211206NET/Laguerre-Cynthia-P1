using Xunit;
using Moq;
using System.Collections.Generic;
using WebAPI.Controllers;
using BL;
using Models;
using Microsoft.Extensions.Caching.Memory;
using DL;

namespace Tests;

public class ControllerTest
{
    [Fact]
    public void InventoryControllerGetShouldGetAllInventoriesByStoreFrontId()
    {
        //Arrange
        var mockBL = new Mock<IBL>();
        int i = 1;
        mockBL.Setup(x => x.GetInventoriesbyStoreId(i)).Returns(
            new List<Inventory>
            {
                new Inventory
                {
                    ID = 1,
                    StoreFrontID = 1,
                    Quantity = 1,
                    ProductName =  "Name",
                    ProductColor = "Red",
                    ProductDescription = "Description",
                    ProductPrice =  3.45M
                },
                new Inventory
                {
                    ID = 2,
                    StoreFrontID = 2,
                    Quantity = 1,
                    ProductName =  "Name2",
                    ProductColor = "Yellow",
                    ProductDescription = "Description Two",
                    ProductPrice =  3.45M
                }
            }
        );
        var inventoryCtrllr = new InventoryController(mockBL.Object);

        var result = inventoryCtrllr.Get(i);

        Assert.NotNull(result);
        Assert.IsType<List<Inventory>>(result);
        Assert.Equal(2, result.Count);

    }

    [Fact]
    public void ShouldReturnListofCustomers()
    {
        //Assert
        var mockBL = new Mock<IBL>();
        
        mockBL.Setup(x => x.GetAllCustomers()).Returns(
            new List<Customer>
            {
                new Customer
                {
                    ID = 1,
                    Name = "Name One",
                    Email = "Email One",
                    Password = "Password One"

                },
                new Customer
                {
                    ID = 2,
                    Name = "Name Two",
                    Email = "Email Two",
                    Password = "Password Two"
                }
            }
        );
        IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());
        var custCntrllr = new CustomerController(mockBL.Object, cache);

        //Act
        var result = custCntrllr.Get();

        //Assert
        Assert.IsType<List<Customer>>(result);
    }

    [Fact]
    public void ShouldReturnListofStoreFronts()
    {
        //Assert
        var mockBL = new Mock<IBL>();
        
        mockBL.Setup(x => x.GetAllStoreFronts()).Returns(
            new List<StoreFront>
            {
                new StoreFront
                {
                    ID = 1,
                    Name = "Name One",
                    Address = "Address One",
                    City = "City One",
                    State = "State One"

                },
                new StoreFront
                {
                    ID = 2,
                    Address = "Address Two",
                    City = "City Two",
                    State = "State Two"
                }
            }
        );
        var storeCntrllr = new StoreFrontController(mockBL.Object);

        //Act
        var result = storeCntrllr.Get();

        //Assert
        Assert.IsType<List<StoreFront>>(result);
    }

        [Fact]
    public void ShouldReturnListofOrders()
    {
        //Assert
        var mockBL = new Mock<IBL>();
        int i = 1;
        mockBL.Setup(x => x.GetAllOrders()).Returns(
            new List<Order>
            {
                new Order
                {
                    ID = 1,
                    CustomerID = 1,
                    StoreFrontID = 1,
                    Total = 1

                },
                new Order
                {
                    ID = 2,
                    CustomerID = 2,
                    StoreFrontID = 2,
                    Total = 2
                }
            }
        );
        var orderCntrllr = new OrdersController(mockBL.Object);

        //Act
        var result = orderCntrllr.Get();

        //Assert
        Assert.IsType<List<Order>>(result);
    }

        [Fact]
    public void ShouldReturnListofLineItems()
    {
        //Assert
        var mockBL = new Mock<IBL>();
        
        mockBL.Setup(x => x.GetAllLineItems()).Returns(
            new List<LineItem>
            {
                new LineItem
                {
                    ID = 1,
                    StoreFrontID = 1,
                    InventoryID = 1,
                    OrderID = 1,
                    CustomerID = 1,
                    Quantity = 1,
                    ProductName =  "Name2",
                    ProductColor = "Yellow",
                    ProductPrice =  3.45M

                },
                new LineItem
                {
                    ID = 2,
                    StoreFrontID = 2,
                    InventoryID = 2,
                    OrderID = 2,
                    CustomerID = 2,
                    Quantity = 1,
                    ProductName =  "Name2",
                    ProductColor = "Red",
                    ProductPrice =  3.45M
                }
            }
        );
        
        var lineItemCntrllr = new LineItemController(mockBL.Object);

        //Act
        var result = lineItemCntrllr.Get();

        //Assert
        Assert.IsType<List<LineItem>>(result);
    }

    [Fact]
    public void LineItemControllerGetShouldGetAllLineItemsbyOrderId()
    {
        //Arrange
        var mockBL = new Mock<IBL>();
        int i = 1;
        mockBL.Setup(x => x.GetLineItemsbyOrderId(i)).Returns(
            new List<LineItem>
            {
                new LineItem
                {
                    ID = 1,
                    StoreFrontID = 1,
                    Quantity = 1,
                    ProductName =  "Name",
                    ProductColor = "Red",
                    ProductPrice =  3.45M
                },
                new LineItem
                {
                    ID = 2,
                    StoreFrontID = 2,
                    Quantity = 1,
                    ProductName =  "Name2",
                    ProductColor = "Yellow",
                    ProductPrice =  3.45M
                }
            }
        );
        var lineItemCtrllr = new LineItemController(mockBL.Object);

        var result = lineItemCtrllr.Get(i);

        Assert.NotNull(result);
        Assert.IsType<List<LineItem>>(result);
        Assert.Equal(2, result.Count);

    }

    [Fact]
    public void ShouldReturnListofInventories()
    {
        //Assert
        var mockBL = new Mock<IBL>();

        mockBL.Setup(x => x.GetAllInventories()).Returns(
            new List<Inventory>
            {
                new Inventory
                {
                    ID = 1,
                    StoreFrontID = 1,
                    Quantity = 1,
                    ProductName =  "Name2",
                    ProductColor = "Yellow",
                    ProductPrice =  3.45M

                },
                new Inventory
                {
                    ID = 2,
                    StoreFrontID = 2,
                    Quantity = 1,
                    ProductName =  "Name2",
                    ProductColor = "Red",
                    ProductPrice =  3.45M
                }
            }
        );

        var inventoryCntrllr = new InventoryController(mockBL.Object);

        //Act
        var result = inventoryCntrllr.Get();

        //Assert
        Assert.IsType<List<Inventory>>(result);
    }
}
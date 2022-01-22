namespace Models;

public class LineItem
{
    public LineItem() {}
    public int ID { get; set; }
    //public Product? Item { get; set; }
    public int InventoryID { get; set; }
    public int StoreFrontID { get; set; }
    public string? ProductName { get; set; }
    public string? ProductColor { get; set; }
    public decimal ProductPrice { get; set; }
    public int OrderID { get; set; }
    public int Quantity { get; set; }

//public override string ToString()
//    {
//        return $"ProductId: {Item.ID} \nProductName: {Item.Color} {Item.ProductName} \nQuantity: {Quantity}";
//    }

    public LineItem(DataRow row)
    {
        ID = (int) row["Id"];
        InventoryID = (int)row["InventoryId"];
        ProductName = row["ProductName"].ToString();
        ProductColor = row["ProductColor"].ToString();
        ProductPrice= (decimal) row["ProductPrice"];
        Quantity = (int) row["Quantity"];
        OrderID = (int) row["OrdersId"];
    }

    public void ToDataRow(ref DataRow row)
    {
        row["Id"] = ID;
        row["InventoryId"] = InventoryID;
        row["ProductName"] = ProductName;
        row["ProductColor"] = ProductColor;
        row["ProductPrice"] = ProductPrice;
        row["Quantity"] = Quantity;
        row["OrderID"] = OrderID;
    }
}
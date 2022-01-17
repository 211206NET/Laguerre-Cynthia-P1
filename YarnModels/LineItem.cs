namespace Models;

public class LineItem
{
    public LineItem() {}
    public int ID { get; set; }
    public Inventory? Item { get; set; }
    public int ProductID { get; set; }
    public string? ProductName { get; set; }
    public string? ProductColor { get; set; }
    public decimal ProductPrice { get; set; }
    public int OrderID { get; set; }
    public int Quantity { get; set; }
    public int InventoryID { get; set; }

public override string ToString()
    {
        return $"ProductId: {ProductID} \nProductName: {ProductName} \nQuantity: {Quantity}";
    }

    public LineItem(DataRow row)
    {
        ID = (int) row["Id"];
        ProductID = (int) row["ProductId"];
        ProductName = row["ProductName"].ToString();
        ProductColor = row["ProductColor"].ToString();
        ProductPrice= (decimal) row["ProductPrice"];
        Quantity = (int) row["Quantity"];
        OrderID = (int) row["OrdersId"];
    }

    public void ToDataRow(ref DataRow row)
    {
        row["Id"] = ID;
        row["ProductId"] = ProductID;
        row["ProductName"] = ProductName;
        row["ProductColor"] = ProductColor;
        row["ProductPrice"] = ProductPrice;
        row["Quantity"] = Quantity;
        row["OrderID"] = OrderID;
    }
}
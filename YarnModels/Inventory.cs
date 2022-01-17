namespace Models;
using System.Data;

public class Inventory 
{
    public Inventory() {}
    public int ID { get; set; }
    public int StoreFrontID { get; set; }
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string? ProductDescription { get; set; }
    public string? ProductColor { get; set; }
    

    public override string ToString()
    {
        return $"StoreId: {StoreFrontID} \nProductId: {ProductID} ProductName: {ProductName} \nColor: {ProductColor} \nDescription: {ProductDescription} \nPrice: {ProductPrice} \nQuantity: {Quantity}";
    }
    public Inventory(DataRow row)
    {    
        ID = (int) row["Id"];
        Quantity = (int) row["Quantity"];
        StoreFrontID = (int) row["StoreFrontId"];
        ProductID = (int) row["ProductId"];
        ProductName = row["Name"].ToString() ?? "";
        ProductColor = row["Color"].ToString() ?? "";
        ProductDescription = row["Description"].ToString() ?? "";
        ProductPrice = (decimal) row["Price"];
    }

    public void ToDataRow(ref DataRow row)
    {
        row["Id"] = ID;
        row["Quantity"] = Quantity;
        row["StoreFrontID"] = StoreFrontID;
        row["ProductID"] = ProductID;
        ProductName = row["Name"].ToString() ?? "";
        ProductColor = row["Color"].ToString() ?? "";
        ProductDescription = row["Description"].ToString() ?? "";
        ProductPrice = (decimal) row["Price"];
    }
}
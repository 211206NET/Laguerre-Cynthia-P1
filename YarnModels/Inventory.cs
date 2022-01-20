namespace Models;
using System.Data;

public class Inventory 
{
    public Inventory() {}
    public int ID { get; set; }
    public int StoreFrontID { get; set; }
    //public Product? Item { get; set; }
    public int Quantity { get; set; }
    public string? ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string? ProductDescription { get; set; }
    public string? ProductColor { get; set; }


    public override string ToString()
    {
        return $"StoreId: {StoreFrontID} \nId: {ID} ProductName: {ProductName} \nColor: {ProductColor} Description: {ProductDescription} \nPrice: {ProductPrice} \nQuantity: {Quantity}";
    }
    public Inventory(DataRow row)
    {    
        ID = (int) row["Id"];
        Quantity = (int) row["Quantity"];
        StoreFrontID = (int) row["StoreFrontId"];
        ProductName = row["ProductName"].ToString();
        ProductPrice = (decimal) row["ProductPrice"];
        ProductDescription = row["ProductDescription"].ToString();
        ProductColor = row["ProductColor"].ToString();
    }

    public void ToDataRow(ref DataRow row)
    {
        row["Id"] = ID;
        row["Quantity"] = Quantity;
        row["StoreFrontID"] = StoreFrontID;
        row["ProductName"] = ProductName;
        row["ProductPrice"] = ProductPrice;
        row["ProductDescription"] = ProductDescription;
        row["ProductColor"] = ProductColor;
    }
}
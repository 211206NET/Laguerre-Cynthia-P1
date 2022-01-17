namespace Models;

public class Product
{
    public Product () {}
    public int ID { get; set; }

    public string? ProductName { get; set; }
    public string? Color { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public Product(DataRow row)
    {
        ID = (int) row["Id"];
        ProductName = row["Name"].ToString() ?? "";
        Color = row["Color"].ToString() ?? "";
        Description = row["Description"].ToString() ?? "";
        Price = (decimal) row["Price"];
    }

    public void ToDataRow(ref DataRow row)
    {
        row["Id"] = ID;
        row["Name"] = ProductName;
        row["Color"] = Color;
        row["Description"] = Description;
        row["Price"] = Price;
    }

    public override string ToString()
    {
        return $"ProductName: {ProductName} \nColor: {Color} \nDescription: {Description} \nPrice: {Price}";
    }
}
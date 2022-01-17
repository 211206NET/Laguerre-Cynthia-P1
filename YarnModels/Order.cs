namespace Models;

public class Order
{
    public Order() {}

    public int ID { get; set; }
    public string OrderDate { get; set; }
    public int CustomerID { get; set; }
    public int StoreFrontID { get; set; }
    public List<LineItem>? LineItems { get; set; }
    public decimal Total { get; set; }
    public decimal CalculateTotal() {
        decimal total = 0;
        if(this.LineItems?.Count > 0)
        {
            foreach(LineItem lineitem in this.LineItems)
            {
                total += lineitem.ProductPrice * lineitem.Quantity;
            }
        }
        this.Total = total;
        return total;
    }

    public override string ToString()
    {
        return $"OrderId: {this.ID} \nDate: {this.OrderDate} \nStoreId: {this.StoreFrontID} \nCustomerId: {this.CustomerID} \nTotal: {this.Total}";
    }

    public Order(DataRow row)
    {
        ID = (int) row["Id"];
        StoreFrontID = (int) row["StoreFrontId"];
        OrderDate = row["OrderDate"].ToString();
        CustomerID = (int) row["CustomerId"];
        Total = (decimal) row["Total"];
    }

    public void ToDataRow(ref DataRow row)
    {
        row["Id"] = ID;
        row["StoreFrontId"] = StoreFrontID;
        row["CustomerId"] = CustomerID;
        row["Total"] = Total;
    }
}
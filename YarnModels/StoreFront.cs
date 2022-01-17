namespace Models;
public class StoreFront
{
    public StoreFront() {}

    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public List<Inventory>? Inventories { get; set; }
    public List<Order>? Orders { get; set; }

    public override string ToString()
    {
        return ($"Store: {Name}\n City: {City}, State: {State}\n Address: {Address})");
    }

    public StoreFront(DataRow row)
    {
        ID = (int) row["Id"];
        Name = row["Name"].ToString() ?? "";
        Address = row["Address"].ToString() ?? "";
        City = row["City"].ToString() ?? "";
        State = row["State"].ToString() ?? "";
    }

    public void ToDataRow(ref DataRow row)
    {
        row["Id"] = ID;
        row["Name"] = Name;
        row["Address"] = Address;
        row["City"] = City;
        row["State"] = State;
    }

}

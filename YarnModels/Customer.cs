using CustomExceptions;
using System.Text.RegularExpressions;

namespace Models;

public class Customer
{
    public Customer() {}
    public int ID { get; set; }
    //public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public List<Order>? Orders { get; set; }

    public override string ToString()
    {
        return $"Id: {this.ID} \nName: {this.Name} \nCity: {this.Email} \nPassword: {this.Password}";
    }

    public Customer(DataRow row)
    {
        ID = (int) row["Id"];
        Name = row["Name"].ToString() ?? "";
        Email = row["Email"].ToString() ?? "";
        Password = row["Password"].ToString() ?? "";
    }

    public void ToDataRow(ref DataRow row)
    {
        row["Name"] = Name;
        row["Email"] = Email;
        row["Password"] = Password;
    }

    private string _name;
    public string Name {
        get => _name;
        set{
            Regex pattern = new Regex("[a-zA-Z0-9 !?']+$");
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new InputInvalidException("Name can't be empty");
            }
            else if(!pattern.IsMatch(value))
            {
                throw new InputInvalidException("Customer name can only can alphanumeric characters white space, !, ?, and '.");
            }
            else{
                _name = value;
            }
        }
    }

}
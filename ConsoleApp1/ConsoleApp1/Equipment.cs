namespace ConsoleApp1;

public class Equipment
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
    public int Id { get; set; }

    public Equipment(string name, string description, bool status, double price, string category)
    {
        Name = name;
        Description = description;
        Status = status;
        Price = price;
        Category = category;
        Id = GenerateRandomId();
    }

    private int GenerateRandomId()
    {
        return new Random().Next(1000, 10000);
    }

    public virtual string ToString()
    {
        if (Status)
        {
            return Name + " " + Description +  " " + Price + " " + Category;    
        }

        return null;

    }

}
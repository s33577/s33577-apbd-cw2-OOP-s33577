namespace ConsoleApp1;

public class Equipment
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsAvailable { get; set; }
    public double Price { get; set; }
    public int Id { get; set; }

    public Equipment(string name, string description, double price)
    {
        Id = GenerateRandomId();
        Name = name;
        Description = description;
        IsAvailable = true;
        Price = price;
    }
    
    

    private int GenerateRandomId()
    {
        return new Random().Next(1000, 10000);
    }

    public override string ToString()
    {
        var status = IsAvailable ? "Avaiable" : "Unavailable";
        return $"[{Id}] {Name} {status} - {Price}/day";

    }

}
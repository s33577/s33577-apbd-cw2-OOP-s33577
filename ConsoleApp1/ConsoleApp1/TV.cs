namespace ConsoleApp1;

public class TV : Equipment
{
    private string _name;
    private string _description;
    private double _price;
    private string _category;
    private string status;
    public TV() : base()
        {
        Name = _name;
        Description = _description;
        Price = _price;
        Category = _category;
        Id = 1;
        Status = status;
        }
    
}
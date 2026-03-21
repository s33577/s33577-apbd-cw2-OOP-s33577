namespace ConsoleApp1;

public class TV : Equipment
{
    private string _name;
    private string _description;
    private double _price;

    public int screenSize { get; set; }
    public bool isSmartTv { get; set; }

    public TV(string name, string description, double price, bool IsSmartTV, int ScreenSize) : base(name, description, price)
        {
            _name = name;
            _description = description;
            _price = price;
            screenSize = ScreenSize;
            isSmartTv = IsSmartTV;
        }
    
    
}
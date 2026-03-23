namespace ConsoleApp1;

public class TV : Equipment
{

    public int screenSize { get; set; }
    public bool isSmartTv { get; set; }

    public TV(string name, string description, double price, bool IsSmartTV, int ScreenSize) : base(name, description, price)
        {
            screenSize = ScreenSize;
            isSmartTv = IsSmartTV;
        }

    public override string ToString()
    {
        return base.ToString() + $" Screen size: {screenSize}, SmartTV: {isSmartTv} ";
        
    }
}
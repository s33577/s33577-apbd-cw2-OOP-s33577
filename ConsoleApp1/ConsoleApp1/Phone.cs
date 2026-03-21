namespace ConsoleApp1;

public class Phone : Equipment
{
    
    public string OperatingSystem { get; set; }
    public int BatteryCapacity { get; set; }

    public Phone(string name, string description, double price, string operatingSystem, int batteryCapacity) : base(
        name, description, price)
    {
        OperatingSystem = operatingSystem;
        BatteryCapacity = batteryCapacity;
    }
}
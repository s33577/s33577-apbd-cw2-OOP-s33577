namespace ConsoleApp1;

public class Laptop : Equipment
{
    public int Ram { get; set; }
    public string Processor { get; set; }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    
    
    public Laptop(string name, string description, double price, int ram, string processor, string model, string manufacturer) :  base(name, description, price)
    
    {
        Ram = ram;
        Processor = processor;
        Model = model;
        Manufacturer = manufacturer;
    }

    public override string ToString()
    {
        return base.ToString() + $" {Ram} RAM, Model: {Model}, Manufacturer: {Manufacturer}, Processor: {Processor}";
    }
    
    
}
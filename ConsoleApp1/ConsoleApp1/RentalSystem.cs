namespace ConsoleApp1;

public class RentalSystem
{
    private List<Equipment> _avaiableEquipments;
    private List<RentalSystem> _rentedEquipments;

    public RentalSystem()
    {
        _avaiableEquipments = new List<Equipment>();
        _rentedEquipments = new List<RentalSystem>();
    }

    public void AddEquipment(Equipment equipment)
    {
        _avaiableEquipments.Add(equipment);
    }

    public List<Equipment> GetAvaiableEquipments()
    {
        return _avaiableEquipments;
    }

    public List<Equipment> GetRentedEquipments()
    {
        return _rentedEquipments;
    }

    public void rentEquipment(Equipment equipment)
    {
        if (_avaiableEquipments.Contains(Equipment))
        {
            _avaiableEquipments.Remove(Equipment);
            
        }
    }
    
    
}
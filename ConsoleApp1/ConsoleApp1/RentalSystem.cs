namespace ConsoleApp1;

public class RentalSystem
{
    private List<Rental> _rentals = new List<Rental>();
    private List<Equipment> _inventory = new List<Equipment>();
    private List<User> _users = new List<User>();
    private double _penaltyRate = 10.0;
    
    
    //Users
    public void AddUser(User user)
    {
        _users.Add(user);
    }
    
    public IReadOnlyList<User> GetAllUsers() => _users;
    
    public User? FindUser(int id) => _users.Find(u => u.Id == id);
    
    //Equipment
    public void AddEquipment(Equipment e)
    {
        _inventory.Add(e);
    }
    
    public IReadOnlyList<Equipment> GetAllEquipments() => _inventory;
    public Equipment? FindEquipment(int id) => _inventory.Find(e => e.Id == id);
    
    


    public IEnumerable<Equipment> getAvailableEquipments()
    {
        _inventory.Where(e => e.IsAvailable);
        return _inventory;
        
    }

    public void MarkEquipmentAsUnavaiable(Equipment e)
    {
        if  (!e.IsAvailable)
        {
            throw new InvalidOperationException("Equipment is not available");
            
        }
        e.IsAvailable = false;
    }
    
    // rentals
    public void RentEquipment(User user, Equipment e, int days)
    {
        if (!e.IsAvailable)
        {
            throw new InvalidOperationException("Equipment is not available");
        }   
        int activeRentalsCount = _rentals.Count(r => r.User.Id == user.Id && r.IsActive);
        if (activeRentalsCount >= user.MaxActiveRentals)
        {
            throw new InvalidOperationException("You cannot rent more rentals");
        }

        e.IsAvailable = false;
        _rentals.Add(new Rental(user, e, days));
        Console.WriteLine($"Rental created: '{{equipment.Name}}' : {{user.Name}} {{user.LastName}} for {{days}} day(s).");
        
    }
    
    public void RetrunEquipment(Rental rental, DateTime actualRetrunDate) 
    {
        if (!rental.IsActive)
        {
            throw new InvalidOperationException("Rental is not active");
        }
        rental.MarkReturned(actualRetrunDate, _penaltyRate);
        
        Console.WriteLine(rental.Penalty > 0 ? $"retruned late, penalty: {rental.Penalty}" : "retruned on time. No penalty.");
        
        
        
    }

    public IEnumerable<Rental> GetActiveRentalsForUser(User user)
    {
        return _rentals.Where(r => r.User.Id == user.Id && r.IsActive);
    }

    public IEnumerable<Rental> GetActiveAllRentals()
    {
        return _rentals.Where(r => r.IsActive);
    }
    public IEnumerable<Rental> GetOverDueRentals()
    {
        return _rentals.Where(r => r.IsOverdue);
    }
    
    public IReadOnlyList<Rental> GetAllRentals() => _rentals;
    
    // User UI Report
    public void PrintSummary()
    {
        Console.WriteLine($"Users: {_users.Count}");
        Console.WriteLine($"Equipments: {_rentals.Count}");
        Console.WriteLine($"Avaiable: {_inventory.Count(e => e.IsAvailable)}");
        Console.WriteLine($"Unavailable: {_inventory.Count(e => !e.IsAvailable)}");
        Console.WriteLine($"Total rentals: {_rentals.Count}");
        Console.Write($"Active rentals: {_rentals.Count(e => e.IsActive)}");
        Console.Write($"Overdue: {_rentals.Count(e=> e.IsOverdue)}" );
        Console.WriteLine($"Rental count: {_rentals.Count}");
        Console.WriteLine($"Total penalty: {_penaltyRate}");
        
        
        
    }

}
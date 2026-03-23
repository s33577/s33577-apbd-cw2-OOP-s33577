namespace ConsoleApp1;

public class RentalSystem
{
    private List<Rental> _rentals = new List<Rental>();
    private List<Equipment> _inventory = new List<Equipment>();
    private List<User> _users = new List<User>();
    private double _penaltyRate = 10.0;

    public void AddEquipment(Equipment e)
    {
        _inventory.Add(e);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public IEnumerable<Rental> getAvailableEquipments()
    {
        _inventory.Where(e => e.IsAvailable);
        return _rentals;
        
    }

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
        var rental = new Rental(user, e, days);
        _rentals.Add(rental);
    }
    
    public void RetrunEquipment(Rental rental, DateTime actualRetrunDate) 
    {
        if (!rental.IsActive)
        {
            throw new InvalidOperationException("Rental is not active");
        }
        rental.MarkReturned(actualRetrunDate, _penaltyRate);
        
    }

}
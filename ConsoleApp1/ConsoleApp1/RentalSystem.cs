namespace ConsoleApp1;

public class RentalSystem
{
    private List<Rental> Rentals;
    private List<Equipment> inventory;
    private List<User> Users;
    private double penaltyRate = 10.0;

    public void AddEquipment(Equipment e)
    {
        inventory.Add(e);
    }

    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public IEnumerable<Rental> getAvailableEquipments()
    {
        inventory.Where(e => e.IsAvailable);
        return Rentals;
        
    }

    public void RentEquipment(User user, Equipment e, int days)
    {
        if (!e.IsAvailable)
        {
            throw new InvalidOperationException("Equipment is not available");
        }   
        int activeRentalsCount = Rentals.Count(r => r.User.Id == user.Id && r.IsActive);
        if (activeRentalsCount >= user.MaxActiveRentals)
        {
            throw new InvalidOperationException("You cannot rent more rentals");
        }

        e.IsAvailable = false;
        var rental = new Rental(user, e, days);
        Rentals.Add(rental);
    }
    
    public void RetrunEquipment(Rental rental, DateTime actualRetrunDate) 
    {
        if (!rental.IsActive)
        {
            throw new InvalidOperationException("Rental is not active");
        }
        rental.MarkReturned(actualRetrunDate, penaltyRate);
        
    }

}
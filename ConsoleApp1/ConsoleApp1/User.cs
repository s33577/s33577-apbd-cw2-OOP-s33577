public abstract class User
{
    
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    
    public string UserType { get; private set; }
    
    public abstract int MaxActiveRentals { get; }

    public User(string name, string lastName, string userType)
    {
        Id = GenerateRandomId();
        Name = name;
        LastName = lastName;
        UserType = userType;
    }

    private int GenerateRandomId()
    {
        return new Random().Next(1000, 10000);
    }

    public override string ToString()
    {
        return $"[{Id}] [{UserType}] {Name} {LastName} Max rentals: {MaxActiveRentals}";
    }
    
}
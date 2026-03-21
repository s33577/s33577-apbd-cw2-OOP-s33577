namespace ConsoleApp1;

public class Student : User
{
    public override int MaxActiveRentals => 2;

    public string Name;
    public string LastName;
    public string UserType;
    public Student(string name, string lastName, string userType) : base(name, lastName, userType)
    {
        Name = name;
        LastName = lastName;
        UserType = userType;
    }
    
}
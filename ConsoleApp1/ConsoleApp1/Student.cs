namespace ConsoleApp1;

public class Student : User
{
    public override int MaxActiveRentals => 2;
    
    public Student(string name, string lastName, string userType) : base(name, lastName, userType)
    {
    }
    
}
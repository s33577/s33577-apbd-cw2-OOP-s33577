namespace ConsoleApp1;

public class Employee : User
{
    public override int MaxActiveRentals => 5;


    public Employee(string name, string lastname, string usertype) : base(name, lastname, usertype)
    {
    }
    
}
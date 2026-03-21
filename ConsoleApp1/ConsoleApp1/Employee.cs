namespace ConsoleApp1;

public class Employee : User
{
    public override int MaxActiveRentals => 5;

    public string Name;
    public string Lastname;
    public string Usertype;


    public Employee(string name, string lastname, string usertype) : base(name, lastname, usertype)
    {
        Name = name;
        Lastname = lastname;
        Usertype = usertype;
    }
    
}
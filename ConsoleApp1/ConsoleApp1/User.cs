public class User
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public int Id { get; set; }
    public string UserType { get; set; }

    public User(string name, string surname, int age, string userType)
    {
        Name = name;
        Surname = surname;
        Age = age;
        UserType = userType;
        Id = GenerateRandomId();
    }

    private int GenerateRandomId()
    {
        return new Random().Next(1000, 10000);
    }
}
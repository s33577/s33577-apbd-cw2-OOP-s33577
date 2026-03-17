// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

public class Program
{
    public static void Main()
    {
        User user1 = new User("Andrew", "Kotowiecki", 21, "Admin");
        Equipment tool = new Equipment("Hammer", "cool", true, 233.1, "woodWork");
        
        Console.WriteLine(user1.Name);
        Console.WriteLine(tool.Name);
    }
}
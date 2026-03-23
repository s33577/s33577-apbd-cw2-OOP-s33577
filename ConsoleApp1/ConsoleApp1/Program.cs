// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

public class Program
{
    public static void Main()
    {
        var service = new RentalSystem();

        var student = new Student("Andrew", "Kotowiecki", "Student");
        var laptop = new Laptop("Mac Book", "Great for studnets", 333.33, 16, "ARM", "M4", "China");
        
        service.AddUser(student);
        service.AddEquipment(laptop);

        Console.WriteLine("Attempt to rent");
        service.RentEquipment(student, laptop, 10);
        Console.WriteLine(laptop);

        try
        {
            var student2 = new Student("Mteusz", "Kowalski", "student");
            service.RentEquipment(student2, laptop, 3);

        }
        catch (Exception e)
        {
            Console.WriteLine($"Failure: " + e.Message);
        }


    }
}
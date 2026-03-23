// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

public class Program
{
    static RentalSystem _service = new RentalSystem();
    public static void Main()
    {

        Console.Write($"Equipment Rental System\n");
        bool running = true;
        

        while (running)
        {
            PrintMen();
            Console.Write("Enter an option: ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                AddUser();
            } 
            else if (choice == "2") 
            {
                AddEquipment();
            } 
            else if (choice == "3")
            {
                ListAllEquipment();
            }
            else if (choice == "4")
            {
                ListAllAvaiableEquipment();
            } 
            else if (choice == "5")
            {
                ShowAllUsers();
            }
            else if (choice == "6")
            {
                MarkUnavailableEquipment();
            }
            else if (choice == "7")
            {
                RentEquipment();
            }
            else if (choice == "8")
            {
                ReturnEquipment();
            }
            else if (choice == "9")
            {
                ShowUserRentals();
            } 
            else if (choice == "10")
            {
                ShowOverDueRentals();
            } 
            else if (choice == "11")
            {
                _service.PrintSummary();
            } 
            else if (choice == "12")
            {
                running = false;
            }
           
        }

    }

    private static void PrintMen()
    {
        Console.Write($"**** MENU ****\n");
        Console.WriteLine("1. Add user");
        Console.WriteLine("2. Add equipment");
        Console.WriteLine("3. List all equipment");
        Console.WriteLine("4. List all Avaiable equipment");
        Console.WriteLine("5. List all users");
        Console.WriteLine("6. Mark equipment as unavailable");
        
        Console.WriteLine("RENTALS");
        Console.WriteLine("7. Rent equipment");
        Console.WriteLine("8. Return equipment");
        Console.WriteLine("9. Show active rentals for a user");
        Console.WriteLine("10. Show overdue rentals");
        
        Console.WriteLine("REPORTS");
        Console.WriteLine("11. Summary Report");
        Console.WriteLine("END Session");
        Console.WriteLine("13. QUIT");
    }

    private static void AddUser()
    {
        Console.WriteLine("User type: 1 = Student");
        Console.WriteLine("User type: 2 = Employee");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Surname: ");
            string surname = Console.ReadLine();
            User user = new Student(name, surname, "Student");
            _service.AddUser(user);
        }
        else if (choice == "2")
            {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Surname: ");
            string surname = Console.ReadLine();
            User user = new Employee(name, surname, "Employee");
            _service.AddUser(user);
            }
        
    }

    private static void ListAllUsers()
    {
        var users = _service.GetAllUsers();
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
        
    }

    private static void AddEquipment()
    {
        Console.WriteLine("Equipment type: 1 = Laptop");
        Console.WriteLine("Equipment type: 2 = Phone");
        Console.WriteLine("Equipment type: 3 = TV");
        string choice = Console.ReadLine();
 
        if (choice == "1")
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Price per day: ");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("RAM (GB): ");
            int ram = int.Parse(Console.ReadLine());
            Console.WriteLine("Processor: ");
            string processor = Console.ReadLine();
            Console.WriteLine("Model: ");
            string model = Console.ReadLine();
            Console.WriteLine("Manufacturer: ");
            string manufacturer = Console.ReadLine();
            Equipment equipment = new Laptop(name, description, price, ram, processor, model, manufacturer);
            _service.AddEquipment(equipment);
            Console.WriteLine("Laptop added: " + equipment);
        }
        else if (choice == "2")
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Price per day: ");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("Operating system: ");
            string os = Console.ReadLine();
            Console.WriteLine("Battery capacity (mAh): ");
            int battery = int.Parse(Console.ReadLine());
            Equipment equipment = new Phone(name, description, price, os, battery);
            _service.AddEquipment(equipment);
            Console.WriteLine("Phone added: " + equipment);
        }
        else if (choice == "3")
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Price per day: ");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("Screen size (inches): ");
            int screenSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Smart TV? (y/n): ");
            string smartInput = Console.ReadLine();
            bool isSmart = smartInput == "y";
            Equipment equipment = new TV(name, description, price, isSmart, screenSize);
            _service.AddEquipment(equipment);
            Console.WriteLine("TV added: " + equipment);
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }
    
    private static void ListAllEquipment()
    {
        var equipments = _service.GetAllEquipments();
        foreach (var equipment in equipments)
        {
            Console.WriteLine(equipment);
        }
    }

    private static void ListAllAvaiableEquipment()
    {
        var items = _service.getAvailableEquipments();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
    
    private static void RentEquipment()
    {
        var users = _service.GetAllUsers();
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
        Console.WriteLine("Enter user ID: ");
        int userId = int.Parse(Console.ReadLine());
        User selected = _service.FindUser(userId);
        var available = _service.getAvailableEquipments().ToList();
        foreach (var equipment in available)
            {
            Console.WriteLine(equipment);
            }
        
        Console.WriteLine("enter equipment ID: ");
        int equipmentId = int.Parse(Console.ReadLine());
        Equipment selectedEquipment = _service.FindEquipment(equipmentId);
        
        Console.WriteLine("Number of rental days: ");
        int rentalDays = int.Parse(Console.ReadLine());
        try
        {
            _service.RentEquipment(selected, selectedEquipment, rentalDays);
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
    }
    private static void ReturnEquipment()
    {
        var active = _service.GetActiveAllRentals().ToList();

        for (int i = 0; i < active.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + active[i]);
        }
        
        Console.WriteLine("Select rental number: ");
        int index = int.Parse(Console.ReadLine());
        Rental rental = active[index];

        DateTime returnDate;
        returnDate = DateTime.Today;


        try
        {
            _service.RetrunEquipment(rental, returnDate);
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
    private static void MarkUnavailableEquipment()
    {
        var items = _service.GetAllEquipments().ToList();
        
        Console.WriteLine("All equipment: ");
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine("Enter equipment ID: ");
        int equipmentId = int.Parse(Console.ReadLine());
        Equipment equipment = _service.FindEquipment(equipmentId);
        if (equipment == null)
        {
            Console.WriteLine("Equipment not found.");
        }

        try
        {
            _service.MarkEquipmentAsUnavaiable(equipment);
            Console.WriteLine(equipment.Name + " mareked as unavailable.");
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        
        
    }

    private static void ShowUserRentals()
    {
        var users = _service.GetAllUsers();
        Console.WriteLine("Users: ");
        foreach (var user in users)
            {
            Console.WriteLine(user);
            }
        Console.WriteLine("Enter user ID: ");
        int userId = int.Parse(Console.ReadLine());
        User selected = _service.FindUser(userId);
        if (selected == null)
        {
            Console.WriteLine("User not found.");
        }
        var rentals = _service.GetActiveRentalsForUser(selected).ToList();

        foreach (var rental in rentals)
        {
            Console.WriteLine(rental);
        }
        
    }
    
    private static void ShowOverDueRentals()
    {
        var overdue =  _service.GetOverDueRentals().ToList();
        foreach (var rental in overdue)
        {
            Console.WriteLine(rental);
        }
    }
    private static void ShowAllUsers()
    {
        var users = _service.GetAllUsers().ToList();
        foreach (var user in users)
        {
            Console.WriteLine(user);
        }
    }
}
namespace ConsoleApp1;

public class Rental
{
    
    public User? User { get; set; }
    public Equipment? Equipment { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public double Penalty { get; set; }

    public bool IsActive => ReturnDate == null;

    public Rental(User user, Equipment equipment, int retalDays)
    {
        User = user;
        Equipment = equipment;
        RentDate = DateTime.Now;
        DueDate = DateTime.Now.AddDays(retalDays);
    } 
    
    public void MarkReturned(DateTime returnDate, double penalityPerDay)
    {
        ReturnDate = returnDate;
        Equipment.IsAvailable = true;
        if (returnDate > DueDate)
        {
            int overDue = (int)(returnDate - DueDate).TotalDays;
            Penalty = overDue * penalityPerDay;
        }
        else
        {
            Penalty = 0;
        }
        
    }
    


}
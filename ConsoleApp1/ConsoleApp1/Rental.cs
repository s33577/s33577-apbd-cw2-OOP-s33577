namespace ConsoleApp1;

public class Rental
{
    
    public User? User { get; set; }
    public Equipment? Equipment { get; set; }
    public DateTime RentDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public double Penalty { get; set; }

    public bool IsActive => ReturnDate == null;
    public bool IsOverdue => IsActive && DateTime.Now > ReturnDate;
    

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

    public override string ToString()
    {
        var status = IsActive ? (IsOverdue ? "Overdue" : "Active") : "retuned";
        var penaltyInfo = Penalty > 0 ? $"Penalty: {Penalty}" : "";
        return $"{status} {User.Name} {User.LastName} rented on {RentDate} Penalty: {penaltyInfo}";
    }
    


}
namespace EFitness.Models;

public class Reservation
{
    public int Id { get; set; } // Primary Key
    public int MemberId { get; set; } // Foreign Key
    public Member Member { get; set; } // Navigation Property
    public int ActivityId { get; set; } // Foreign Key
    public Activity1 Activity1 { get; set; } // Navigation Property
    public DateTime Date { get; set; } // Reservation Date
}

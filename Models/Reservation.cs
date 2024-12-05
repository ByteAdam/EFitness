namespace EFitness.Models;

public class Reservation
{
    public int Id { get; set; }

    public int MemberId { get; set; }
    public Member Member { get; set; }

    public int ActivityId { get; set; } // Foreign key to Activity1
    public Activity1 Activity1 { get; set; } // Navigation property

    public DateTime Date { get; set; }
}

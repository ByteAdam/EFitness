namespace EFitness.Models;

public class Achievement
{
    public int Id { get; set; }
    public int MemberId { get; set; }
    public Member Member { get; set; }
    public string Description { get; set; }
    public DateTime DateAchieved { get; set; }
}

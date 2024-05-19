namespace Happy.Domain.Entities;

public class Week : Base<long>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Year { get; set; }
    public int WeekNumber { get; set; }
}

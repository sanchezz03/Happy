namespace Happy.Domain.Entities;

public class ComplexWeek : Base<long>
{
    public long WeekId { get; set; }
    public Week Week { get; set; }

    public long ComplexId { get; set; }
    public Complex Complex { get; set; }
}

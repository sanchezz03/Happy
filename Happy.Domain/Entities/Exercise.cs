namespace Happy.Domain.Entities;

public class Exercise : Base<long>
{
    public string Name { get; set; }
    public string Description { get; set; } 
    public int Weight { get; set; }
    public int NumberOfRepetitions { get; set; }
}

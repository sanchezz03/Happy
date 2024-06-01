namespace Happy.Service.Dtos;

public class ExerciseDto
{
    public long Id { get; set; }    
    public string Name { get; set; }
    public string Description { get; set; }
    public int? Weight { get; set; }
    public int NumberOfRepetitions { get; set; }
}

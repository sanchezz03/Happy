using Happy.Common.Enums;

namespace Happy.Service.Dtos.Progresses;

public class ModificationProgressDto
{
    public int? Weight { get; set; }
    public int NumberOfRepetitions { get; set; }
    public DateTime Date { get; set; }
    public ERateOfPerceivedExertion? RateOfPerceivedExertion { get; set; }
    public string ExerciseName { get; set; }
}

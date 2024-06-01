using Happy.Common.Enums;

namespace Happy.Service.Dtos;

public class ProgressDto
{
    public int? Weight { get; set; }
    public int NumberOfRepetitions { get; set; }
    public DateTime Date { get; set; }
    public ERateOfPerceivedExertion? RateOfPerceivedExertion { get; set; }
}

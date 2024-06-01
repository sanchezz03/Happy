using Happy.Common.Enums;

namespace Happy.Domain.Entities;

public class Progress : Base<long>
{
    public int? Weight { get; set; }
    public int NumberOfRepetitions { get; set; }
    public DateTime Date { get; set; }
    public ERateOfPerceivedExertion? RateOfPerceivedExertion { get; set; }

    #region Navigation properties

    public string UserId { get; set; }
    public User User { get; set; }

    public long ExerciseId { get; set; }
    public Exercise Exercise { get; set; }

    #endregion
}

using Happy.Common.Enums;

namespace Happy.Service.Dtos;

public class ProgressDto
{
    public int? Weight { get; set; }
    public int NumberOfRepetitions { get; set; }
    public DateTime Date { get; set; }
    public string? RateOfPerceivedExertion { get; set; }
    public string ExerciseName { get; set; }

    #region public methods

    public ERateOfPerceivedExertion GetRateOfPerceivedExertion(string rateOfPerceivedExertion)
    {
        switch (rateOfPerceivedExertion)
        {
            case "Undefined":
                return ERateOfPerceivedExertion.Undefined;
            case "Very easy, almost no exertion":
                return ERateOfPerceivedExertion.VeryEasy;
            case "Very light activity":
                return ERateOfPerceivedExertion.VeryLight;
            case "Light activity":
                return ERateOfPerceivedExertion.Light;
            case "Moderate activity":
                return ERateOfPerceivedExertion.Moderate;
            case "Somewhat hard":
                return ERateOfPerceivedExertion.SomewhatHard;
            case "Hard, but can continue":
                return ERateOfPerceivedExertion.Hard;
            case "Very hard, but can still sustain":
                return ERateOfPerceivedExertion.VeryHard;
            case "Very hard, significantly increased effort":
                return ERateOfPerceivedExertion.VeryVeryHard;
            case "Extremely hard, activity barely sustainable":
                return ERateOfPerceivedExertion.ExtremelyHard;
            case "Maximal effort, cannot continue":
                return ERateOfPerceivedExertion.MaximalEffort;
            default:
                throw new ArgumentException("Invalid rate of perceived exertion");
        }
    }

    #endregion
}

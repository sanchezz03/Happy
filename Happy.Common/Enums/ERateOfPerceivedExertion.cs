using System.ComponentModel;

namespace Happy.Common.Enums;

public enum ERateOfPerceivedExertion
{
    [Description("Undefined")]
    Undefined = 0, 

    [Description("Very easy, almost no exertion")]
    VeryEasy = 1,

    [Description("Very light activity")]
    VeryLight = 2,

    [Description("Light activity")]
    Light = 3,

    [Description("Moderate activity")]
    Moderate = 4,

    [Description("Somewhat hard")]
    SomewhatHard = 5,

    [Description("Hard, but can continue")]
    Hard = 6,

    [Description("Very hard, but can still sustain")]
    VeryHard = 7,

    [Description("Very hard, significantly increased effort")]
    VeryVeryHard = 8,

    [Description("Extremely hard, activity barely sustainable")]
    ExtremelyHard = 9,

    [Description("Maximal effort, cannot continue")]
    MaximalEffort = 10
}

using System.ComponentModel.DataAnnotations;

namespace Happy.Common.Enums;

public enum EWeekDay
{
    [Display(Name = "Undefiend")]
    Undefiend,

    [Display(Name = "Monday")]
    Monday,

    [Display(Name = "Tuesday")]
    Tuesday,

    [Display(Name = "Wednesday")]
    Wednesday,

    [Display(Name = "Thursday")]
    Thursday,

    [Display(Name = "Friday")]
    Friday,

    [Display(Name = "Saturday")]
    Saturday,

    [Display(Name = "Sunday")]
    Sunday
}

using System.ComponentModel.DataAnnotations;

namespace Happy.Common.Enums;

public enum ERole
{
    Underfiend = 0,

    [Display(Name = "User")]
    User = 1,

    [Display(Name = "Member")]
    Member = 2
}

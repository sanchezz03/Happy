using Microsoft.AspNetCore.Identity;

namespace Happy.Domain.Entities;

public class User : IdentityUser
{
    public string DisplayName { get; set; }
    public string Bio { get; set; }

    #region Navigation properties

    public ICollection<Progress> Progresses { get; set; } = new List<Progress>();
    
    #endregion
}

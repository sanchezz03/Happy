using Happy.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Happy.WebApi.Models;

public class AuthResult
{
    public IdentityResult Result { get; set; }
    public User User { get; set; }
}

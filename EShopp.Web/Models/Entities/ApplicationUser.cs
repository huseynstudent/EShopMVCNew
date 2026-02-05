using Microsoft.AspNetCore.Identity;

namespace AspnetMvcAuth.Models.Entities;

public class ApplicationUser:IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
}

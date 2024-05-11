using Microsoft.AspNetCore.Identity;

namespace NsiKlk1.Domain.Entities;

public class ApplicationRole : IdentityRole
{
    public IList<ApplicationUserRole> UserRoles { get; set; }
}
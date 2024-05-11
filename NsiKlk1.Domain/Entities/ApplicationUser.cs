using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace NsiKlk1.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public IList<ApplicationUserRole> Roles { get; } = new List<ApplicationUserRole>();
}
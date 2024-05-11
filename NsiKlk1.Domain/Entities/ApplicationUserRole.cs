using System.Transactions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace NsiKlk1.Domain.Entities;

public class ApplicationUserRole : IdentityUserRole<string>
{
    public ApplicationUser User { get; set; }
    public ApplicationRole Role { get; set; }
}
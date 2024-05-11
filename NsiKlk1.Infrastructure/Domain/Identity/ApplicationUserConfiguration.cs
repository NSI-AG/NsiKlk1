using NsiKlk1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NsiKlk1.Infrastructure.Domain.Identity;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    private const string AdminId = "4DAF65CB-CC0E-4C81-9183-20097EA81F5A";

    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users");

        var admin = new ApplicationUser
        {
            Id = AdminId,
            UserName = "agrocic@gmail.com",
            NormalizedUserName = "AGROCIC@gmail.com",
            Email = "agrocic@gmail.com",
            NormalizedEmail = "AGROCIC@gmail.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = new Guid().ToString("D"),
            FirstName = "Aleksa",
            LastName = "Grocic",
            ConcurrencyStamp = "c188a435-cfc8-45fd-836c-9a18bb9de405",
            AccessFailedCount =  0
        };

        builder.HasData(admin);

        builder.HasMany(x => x.Roles).WithOne()
            .HasForeignKey(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
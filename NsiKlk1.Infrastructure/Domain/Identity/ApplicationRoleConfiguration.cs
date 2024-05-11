using NsiKlk1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NsiKlk1.Infrastructure.Domain.Identity;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    private const string AdminId = "40FEB7B4-B530-4EA2-B96F-582D88277E4B";
    
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.ToTable("Roles");
        builder.HasData(
            new ApplicationRole
            {
                Id = AdminId,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = "a09ab67f-02d6-4910-8659-3385759d8036",
            }
        );
    }
}
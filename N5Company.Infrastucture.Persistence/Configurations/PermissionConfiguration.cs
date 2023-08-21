using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N5Company.Core.Domain.Entities;

namespace N5Company.Infrastucture.Persistence.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permissions>
    {
        public void Configure(EntityTypeBuilder<Permissions> builder)
        {
            builder.ToTable(nameof(Permissions));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EmployeName).IsRequired();
            builder.Property(x => x.EmpolyeLastname).IsRequired();
            builder.Property(x => x.PermissionType).IsRequired();
            builder.Property(x => x.PermissionDate).IsRequired();
            builder.HasMany(x => x.PermissionTypes);
        }
    }
}

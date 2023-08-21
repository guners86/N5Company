using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N5Company.Core.Domain.Entities;

namespace N5Company.Infrastucture.Persistence.Configurations
{
    internal class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionTypes>
    {
        public void Configure(EntityTypeBuilder<PermissionTypes> builder)
        {
            builder.ToTable(nameof(PermissionTypes));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired();
            builder.HasMany(x => x.Permissions);
        }
    }
}

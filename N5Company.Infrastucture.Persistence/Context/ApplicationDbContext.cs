using Microsoft.EntityFrameworkCore;
using N5Company.Core.Domain.Entities;
using System.Reflection;

namespace N5Company.Infrastucture.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<PermissionTypes> PermissionTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

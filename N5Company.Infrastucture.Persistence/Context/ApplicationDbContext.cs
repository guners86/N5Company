using Microsoft.EntityFrameworkCore;
using N5Company.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5Company.Infrastucture.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Permissions> Permissions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}

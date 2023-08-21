using Ardalis.Specification.EntityFrameworkCore;
using N5Company.Core.Application.Interfaces;
using N5Company.Infrastucture.Persistence.Context;

namespace N5Company.Infrastucture.Persistence.Repository
{
    public class RepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public RepositoryAsync(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

using Ardalis.Specification;

namespace N5Company.Core.Application.Interfaces
{
    public interface IRepositoryAsync<T> : IRepositoryBase<T> where T : class
    {
    }

    public interface IReaadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class
    {
    }
}

using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using Domain.Common;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IAsyncRepository<T> where T : IAggregateRoot
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<T> FirstAsync(ISpecification<T> spec);
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec);
    }
}

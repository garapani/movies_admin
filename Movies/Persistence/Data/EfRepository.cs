using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using ApplicationCore.Interfaces.Repositories;

namespace Persistence.Data
{
    public class EfRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : AuditableEntity, IAggregateRoot
    {
        protected readonly MoviesDBContext _dbContext;

        public EfRepository(MoviesDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> ListAsync(ISpecification<TEntity> spec)
        {
            return ApplySpecification(spec);
        }

        public async Task<int> CountAsync(ISpecification<TEntity> spec)
        {
            if (spec != null)
            {
                var specificationResult = ApplySpecification(spec);
                return await specificationResult.CountAsync();
            }
            else
            {
                return await _dbContext.Set<TEntity>().CountAsync();
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TEntity> FirstAsync(ISpecification<TEntity> spec)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> spec)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstOrDefaultAsync();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            var evaluator = new SpecificationEvaluator();
            return evaluator.GetQuery(_dbContext.Set<TEntity>().AsQueryable(), spec);
        }
    }
}

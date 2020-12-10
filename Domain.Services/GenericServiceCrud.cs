using DesignPatternSamples.Domain.Core.Entity;
using DesignPatternSamples.Domain.Core.Interfaces.Repository;
using DesignPatternSamples.Domain.Core.Interfaces.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternSamples.Domain.Services
{
    public class GenericServiceCrud<TKey, TEntity> : IServiceCrud<TKey, TEntity> where TKey : struct where TEntity : BaseEntity<TKey>
    {
        private readonly IRepositoryCrud<TKey, TEntity> _Repository;
        protected readonly IUnitOfWork _UnitOfWork;

        public GenericServiceCrud(IRepositoryCrud<TKey, TEntity> repository, IUnitOfWork unitOfWork)
        {
            _Repository = repository;
            _UnitOfWork = unitOfWork;
        }

        public virtual async Task<TEntity> AddAsync(TEntity obj)
        {
            await _Repository.AddAsync(obj);
            await _UnitOfWork.CommitAsync();
            return obj;
        }
        public virtual async Task<TEntity> DeleteAsync(TKey id)
        {
            await _Repository.DeleteAsync(id);
            await _UnitOfWork.CommitAsync();
            return await _Repository.GetAsync(id);
        }
        public virtual async Task<TEntity> GetAsync(TKey id) => await _Repository.GetAsync(id);
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _Repository.GetAllAsync();
        public virtual async Task<TEntity> UpdateAsync(TEntity obj)
        {
            await _Repository.UpdateAsync(obj);
            await _UnitOfWork.CommitAsync();
            return obj;
        }
    }
}

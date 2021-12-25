using Core.Data;
using Core.Entities;
using Core.Services;
using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class ServiceBase<TEntity> : IService<TEntity> where TEntity : class, IEntity, new()
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IEntityRepository<TEntity> _entityRepository;

        public ServiceBase(IUnitOfWork unitOfWork, IEntityRepository<TEntity> entityRepository)
        {
            _unitOfWork = unitOfWork;
            _entityRepository = entityRepository;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _entityRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entityRepository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entityRepository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _entityRepository.GetByIdAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _entityRepository.Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entityRepository.RemoveRange(entities);
            _unitOfWork.Commit();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entityRepository.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity updateEntity = _entityRepository.Update(entity);
            return updateEntity;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entityRepository.Where(predicate);
        }
    }
}

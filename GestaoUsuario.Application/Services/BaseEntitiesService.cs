using GestaoUsuario.Application.Repositories;
using GestaoUsuario.Domain.Entities;
using GestaoUsuario.Domain.Repositories;

namespace GestaoUsuario.Application.Services
{
    public class BaseEntitiesService<T> : IBaseEntitiesService<T> where T : BaseEntities
    {
        private readonly IBaseEntitiesRepository<T> _repository;

        public BaseEntitiesService(IBaseEntitiesRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task CreateAsync(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            await _repository.CreateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity != null)
                _repository.Delete(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            var entity = _repository.GetByIdAsync(id);
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            var entityToUpdate = await _repository.GetByIdAsync(entity.Id);

            if (entityToUpdate != null)
            {
                entity.UpdatedAt = DateTime.UtcNow;
                _repository.Update(entity);
            }
        }
    }
}

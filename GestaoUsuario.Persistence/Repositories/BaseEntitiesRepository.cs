using GestaoUsuario.Domain.Entities;
using GestaoUsuario.Domain.Repositories;
using GestaoUsuario.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoUsuario.Persistence.Repositories
{
    public class BaseEntitiesRepository<T> : IBaseEntitiesRepository<T> where T : BaseEntities
    {
        private readonly GestaoUsuarioContext _context;

        public BaseEntitiesRepository(GestaoUsuarioContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            //var user = await _context.Set<T>().FindAsync(id);
            var user = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}

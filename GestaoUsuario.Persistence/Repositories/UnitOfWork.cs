using GestaoUsuario.Domain.Repositories;
using GestaoUsuario.Persistence.Context;

namespace GestaoUsuario.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GestaoUsuarioContext _context;

        public UnitOfWork(GestaoUsuarioContext context)
        {
            _context = context;
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

using GestaoUsuario.Domain.Entities;
using GestaoUsuario.Domain.Repositories;
using GestaoUsuario.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoUsuario.Persistence.Repositories
{
    public class UserRepository : BaseEntitiesRepository<User>, IUserRepository
    {
        private readonly GestaoUsuarioContext _context;

        public UserRepository(GestaoUsuarioContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}

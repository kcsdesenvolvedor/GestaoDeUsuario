using GestaoUsuario.Domain.Entities;

namespace GestaoUsuario.Domain.Repositories
{
    public interface IUserRepository : IBaseEntitiesRepository<User>
    {
        Task<User?> GetUserByEmail(string email);
    }
}

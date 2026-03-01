using GestaoUsuario.Domain.Entities;

namespace GestaoUsuario.Application.Repositories
{
    public interface IUserService : IBaseEntitiesService<User>
    {
        Task<User?> GetUserByEmail(string email);
    }
}

using GestaoUsuario.Application.Repositories;
using GestaoUsuario.Domain.Entities;
using GestaoUsuario.Domain.Repositories;

namespace GestaoUsuario.Application.Services
{
    public class UserService : BaseEntitiesService<User>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task CreateAsync(User entity)
        {
            entity.IsActive = true;
            await base.CreateAsync(entity);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _repository.GetUserByEmail(email);
        }
    }
}

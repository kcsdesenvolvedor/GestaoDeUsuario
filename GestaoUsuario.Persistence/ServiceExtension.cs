using GestaoUsuario.Domain.Repositories;
using GestaoUsuario.Persistence.Context;
using GestaoUsuario.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoUsuario.Persistence
{
    public static class ServiceExtension
    {
        public static void ConfigureServicesPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<GestaoUsuarioContext>(options => options.UseSqlite(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

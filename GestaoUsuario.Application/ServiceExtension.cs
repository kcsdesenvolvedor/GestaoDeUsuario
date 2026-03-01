using GestaoUsuario.Application.Repositories;
using GestaoUsuario.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoUsuario.Application
{
    public static class ServiceExtension
    {
        public static void ConfigureServicesApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}

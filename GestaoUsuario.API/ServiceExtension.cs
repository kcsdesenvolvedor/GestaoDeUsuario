namespace GestaoUsuario.API
{
    public static class ServiceExtension
    {
        public static void ConfigureServicesApi(this IServiceCollection services)
        {
            services.AddAutoMapper(m => m.AddMaps(typeof(ServiceExtension).Assembly));
        }
    }
}

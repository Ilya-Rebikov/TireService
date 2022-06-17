namespace TireService.DAL.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using TireService.DAL.Interfaces;
    using TireService.DAL.Repositories;

    /// <summary>
    /// Configure services from DAL.
    /// </summary>
    public static class ConfigureDalServices
    {
        /// <summary>
        /// Extension method for IServiceCollection to add dal services.
        /// </summary>
        /// <param name="services">Services.</param>
        /// <param name="connection">Connection string to database.</param>
        /// <returns>Added services.</returns>
        public static IServiceCollection AddDalServices(this IServiceCollection services, string connection)
        {
            services.AddDbContext<TireServiceContext>(options =>
                options.UseSqlServer(connection));
            services.AddScoped<DbContext, TireServiceContext>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            return services;
        }
    }
}

using hospital_reservation_system.Data;
using hospital_reservation_system.Repository;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;

namespace hospital_reservation_system.Infrastructure
{
    public static class ApplicationServiceExtensions
    {
        // This method is used to add repositories to the service collection.
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        // This method is used to configure the SQLite database context.
        public static IServiceCollection AddSqliteDatabase(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<DatabaseContext>(options => options.UseSqlite(connectionString));
            return services;
        }
    }
}

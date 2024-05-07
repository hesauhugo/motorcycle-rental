using Microsoft.EntityFrameworkCore;
using MotorcycleRental.Infrastructure.Persistence;
using System.Runtime.CompilerServices;

namespace MotorcycleRental.API.Middleware
{
    public static class MigrationsMiddleware
    {
        public static void MigrateDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<MotorcycleRentalDbContext>();

                // Aplicar migrações pendentes
                dbContext.Database.Migrate();
            }
        }
    }
}

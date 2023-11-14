using University.Persistence.Data;
using University.Persistence;
using Microsoft.EntityFrameworkCore;

namespace University.Web.Extensions
{
    public static class WebAppExtensions
    {
        public static async Task SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var db = serviceProvider.GetRequiredService<UniversityContext>();

                await db.Database.EnsureDeletedAsync();
                await db.Database.MigrateAsync();

                try
                {
                    await SeedData.InitAsync(db);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }

            }
        }
    }
}

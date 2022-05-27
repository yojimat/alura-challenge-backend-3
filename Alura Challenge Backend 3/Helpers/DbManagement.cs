using Alura_Challenge_Backend_3.Contexts;
using Alura_Challenge_Backend_3.Data.Contexts;
using Alura_Challenge_Backend_3.Models;
using Microsoft.AspNetCore.Identity;

namespace Alura_Challenge_Backend_3.Helpers
{
    public static class DbManagement
    {
        public static async void CleanDatabaseForTest(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var transactionContext = services.GetRequiredService<TransactionContext>();
            transactionContext.Database.EnsureDeleted();
            transactionContext.Database.EnsureCreated();

            var appContext = services.GetRequiredService<ApplicationDbContext>();
            appContext.Database.EnsureDeleted();
            appContext.Database.EnsureCreated();

            UserManager<ApplicationUser> userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            ApplicationUser user = new()
            {
                UserName = "admin",
                Email = "admin@email.com.br",
                EmailConfirmed = true
            };

            string passwordGenerated = "123999";

            var result = await userManager.CreateAsync(user, passwordGenerated);

            if (!result.Succeeded) throw new Exception("Admin user was not created.");
        }
    }
}

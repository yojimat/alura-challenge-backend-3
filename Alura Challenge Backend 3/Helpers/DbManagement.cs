using Alura_Challenge_Backend_3.Contexts;
using Alura_Challenge_Backend_3.Data.Contexts;

namespace Alura_Challenge_Backend_3.Helpers
{
    public static class DbManagement
    {
        public static void CleanDatabaseForTest(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var transactionContext = services.GetRequiredService<TransactionContext>();
            transactionContext.Database.EnsureDeleted();
            transactionContext.Database.EnsureCreated();

            var appContext = services.GetRequiredService<ApplicationDbContext>();
            appContext.Database.EnsureDeleted();
            appContext.Database.EnsureCreated();

            // TODO: Populate ApplicationContext with the default user
            // DbInitializer.Initialize(context);
        }
    }
}

using Alura_Challenge_Backend_3.Contexts;

namespace Alura_Challenge_Backend_3.Helpers
{
    public static class DbManagement
    {
        public static void CleanDatabaseForTest(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<TransactionContext>();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            // TODO: Populate ApplicationContext with the default user
            // DbInitializer.Initialize(context);
        }
    }
}

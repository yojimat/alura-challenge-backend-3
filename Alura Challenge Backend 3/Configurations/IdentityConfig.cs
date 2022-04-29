using Alura_Challenge_Backend_3.Data.Contexts;
using Microsoft.AspNetCore.Identity;

namespace Alura_Challenge_Backend_3.Configurations;

public static class IdentityConfig
{
    public static void AddIdentityConfiguration(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequiredLength = 6;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequiredUniqueChars = 0;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>();
    }

    public static void UseIdentityConfiguration(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}


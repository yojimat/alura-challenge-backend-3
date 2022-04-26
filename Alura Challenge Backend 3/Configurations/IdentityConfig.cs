using Microsoft.AspNetCore.Authentication.Cookies;

namespace Alura_Challenge_Backend_3.Configurations;

public static class IdentityConfig
{
    public static void AddIdentityConfiguration(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.LoginPath = "/login";
                options.AccessDeniedPath = "/login";
            });

        services.AddAuthorization(options =>
        {
            options.FallbackPolicy = options.DefaultPolicy;
        });

        services.AddHttpContextAccessor();

    }

    public static void UseIdentityConfiguration(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
    }
}


using LoanApplicationSystem.Application.Contracts;
using LoanApplicationSystem.Infrastructure.Persistence;
using LoanApplicationSystem.Infrastructure.Repositories;
using LoanApplicationSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LoanApplicationSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services
                .AddAuth(configuration)
                .AddPersistence();

            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<LoanApplicationSystemDbContext>(
                options => options.UseSqlServer("Server=.;Database=LoanApplicationSystemDb;Integrated Security=true;TrustServerCertificate=True;"));
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddAuth(
             this IServiceCollection services,
             ConfigurationManager configuration)
        {
            services.AddSingleton<IJwtTokenService, JwtTokenService>();
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Password settings - industry best practices
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 12;
                options.Password.RequiredUniqueChars = 4;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false; // Set to true in production
            })
            .AddEntityFrameworkStores<LoanApplicationSystemDbContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }


}

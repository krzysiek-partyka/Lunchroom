using Lunchroom.Domain.Interfaces;
using Lunchroom.Infrastructure.Persistence;
using Lunchroom.Infrastructure.Repositories;
using Lunchroom.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Lunchroom.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<LunchroomDbContext>(options =>
                options.UseSqlServer(configuration
                    .GetConnectionString("LunchroomDb")));
            service.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<LunchroomDbContext>();
            service.AddScoped<LunchroomSeeder>();
            service.AddScoped<ILunchroomRepository, LunchroomRepository>();
            service.AddScoped<IStudentRepository, StudentRepository>();
        }
    }
}
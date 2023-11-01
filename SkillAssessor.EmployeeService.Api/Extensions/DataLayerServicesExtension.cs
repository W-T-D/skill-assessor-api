using Microsoft.EntityFrameworkCore;
using SkillAssessor.EmployeeService.Data;

namespace SkillAssessor.EmployeeService.Api.Extensions;

public static class DataLayerServicesExtension
{
    public static IServiceCollection AddDataLayerServices(this IServiceCollection services)
    {
        services.AddDbContext<EmployeeDbContext>(options =>
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            
            options.UseNpgsql(connectionString);
        });
        
        return services;
    }
}
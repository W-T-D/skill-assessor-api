using Microsoft.EntityFrameworkCore;
using SkillAssessor.EmployeeService.Data;
using SkillAssessor.EmployeeService.Data.Interfaces;
using SkillAssessor.EmployeeService.Data.Repositories;
using SkillAssessor.EmployeeService.Data.Repositories.Interfaces;

namespace SkillAssessor.EmployeeService.Api.Extensions;

public static class DataLayerServicesExtension
{
    public static IServiceCollection AddDataLayerServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EmployeeDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("EmployeeDb");
            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IInterviewRequestRepository, InterviewRequestRepository>();
        services.AddScoped<ISkillLevelRepository, SkillLevelRepository>();
        services.AddScoped<IEmployeeUnitOfWork, EmployeeUnitOfWork>();
        
        return services;
    }
}
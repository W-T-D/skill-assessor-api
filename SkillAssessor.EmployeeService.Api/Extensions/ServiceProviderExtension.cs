using SkillAssessor.EmployeeService.Data;

namespace SkillAssessor.EmployeeService.Api.Extensions;

public static class ServiceProviderExtension
{
    public static async Task CreateDbIfNotExists(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<EmployeeDbContext>();

        await DbInitializer.Initialize(context);
    }
}
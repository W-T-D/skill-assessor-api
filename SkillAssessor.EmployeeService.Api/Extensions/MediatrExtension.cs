using SkillAssessor.EmployeeService.Domain.Queries.Employees.Get;

namespace SkillAssessor.EmployeeService.Api.Extensions;

public static class MediatrExtension
{
    public static void AddMediatr(this IServiceCollection services)
    {
        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssembly(typeof(GetEmployeeQuery).Assembly);
        });
    }
}
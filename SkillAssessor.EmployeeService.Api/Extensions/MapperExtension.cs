using SkillAssessor.EmployeeService.Domain.Queries.Employees.Get;

namespace SkillAssessor.EmployeeService.Api.Extensions;

public static class MapperExtension
{
    public static void AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(c =>
        {
            c.AddMaps(typeof(GetEmployeeQuery).Assembly);
        });
    }
}
using MediatR;
using SkillAssessor.EmployeeService.Domain.Queries.Employees.Get;
using SkillAssessor.EmployeeService.DomainModels.Employee;

namespace SkillAssessor.EmployeeService.Api.Queries;

[ExtendObjectType(Name = "Query")]
public sealed class EmployeeQueries
{
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public async Task<IQueryable<EmployeeDto>> GetEmployees([Service] IMediator mediator, GetEmployeeQuery request)
    {
        var employees = await mediator.Send(request);

        return employees;
    }
}
using MediatR;
using SkillAssessor.EmployeeService.DomainModels.Employee;

namespace SkillAssessor.EmployeeService.Domain.Queries.Employees.Get;

public record GetEmployeeQuery() : IRequest<IQueryable<EmployeeDto>>;
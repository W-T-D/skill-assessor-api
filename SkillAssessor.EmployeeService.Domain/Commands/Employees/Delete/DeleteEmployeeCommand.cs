using MediatR;
using SkillAssessor.EmployeeService.DomainModels.Employee;

namespace SkillAssessor.EmployeeService.Domain.Commands.Employees.Delete;

public record DeleteEmployeeCommand(Guid Id) : IRequest<EmployeeDto>;
using MediatR;
using SkillAssessor.EmployeeService.DomainModels.Employee;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;

namespace SkillAssessor.EmployeeService.Domain.Commands.Employees.Edit;

public record EditEmployeeCommand(Guid Id, DateOnly DateOfBirth, DateOnly EmploymentDate,
    string Country, ICollection<SkillLevelDto> Skills) : IRequest<EmployeeDto>;
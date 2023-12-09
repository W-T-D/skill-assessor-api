using MediatR;
using SkillAssessor.EmployeeService.DomainModels.Employee;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;

namespace SkillAssessor.EmployeeService.Domain.Commands.Employees.Add;

public record AddEmployeeCommand(DateOnly DateOfBirth, DateOnly EmploymentDate,
    string Country, ICollection<SkillLevelDto> Skills) : IRequest<EmployeeDto>;
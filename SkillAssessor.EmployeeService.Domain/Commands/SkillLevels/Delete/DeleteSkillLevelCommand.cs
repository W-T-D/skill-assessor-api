using MediatR;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;

namespace SkillAssessor.EmployeeService.Domain.Commands.SkillLevels.Delete;

public record DeleteSkillLevelCommand(Guid Id) : IRequest<SkillLevelDto>;
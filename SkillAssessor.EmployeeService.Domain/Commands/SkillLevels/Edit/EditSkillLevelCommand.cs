using MediatR;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;

namespace SkillAssessor.EmployeeService.Domain.Commands.SkillLevels.Edit;

public record EditSkillLevelCommand(Guid Id, string SkillTitle, int LevelNumber) : IRequest<SkillLevelDto>;
using MediatR;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;

namespace SkillAssessor.EmployeeService.Domain.Commands.SkillLevels.Add;

public record AddSkillLevelCommand(string SkillTitle, int LevelNumber) : IRequest<SkillLevelDto>;
using MediatR;
using SkillAssessor.AssessmentService.DomainModels.SkillLevels;

namespace SkillAssessor.AssessmentService.Domain.Commands.SkillLevels.AddOrEdit;

public record AddOrEditSkillLevelCommand(string? Id, string Name, string Description, int LevelNumber, string SkillId)
    : IRequest<SkillLevelDto>;
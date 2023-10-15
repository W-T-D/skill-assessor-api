using MediatR;
using SkillAssessor.AssessmentService.DomainModels.SkillLevels;

namespace SkillAssessor.AssessmentService.Domain.Commands.SkillLevels.Delete;

public record DeleteSkillLevelCommand(string Id) : IRequest<SkillLevelDto>;
using MediatR;
using SkillAssessor.AssessmentService.DomainModels.SkillLevels;

namespace SkillAssessor.AssessmentService.Domain.Queries.SkillLevels.Get;

public record GetSkillLevelQuery(string Id) : IRequest<SkillLevelDto>;
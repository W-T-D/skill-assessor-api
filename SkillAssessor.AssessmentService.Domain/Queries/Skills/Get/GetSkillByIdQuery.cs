using MediatR;
using SkillAssessor.AssessmentService.DomainModels.Skills;

namespace SkillAssessor.AssessmentService.Domain.Queries.Skills.Get;

public record GetSkillByIdQuery(string Id) : IRequest<SkillDto>;
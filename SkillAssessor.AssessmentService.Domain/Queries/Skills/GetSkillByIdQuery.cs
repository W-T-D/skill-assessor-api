using MediatR;
using SkillAssessor.AssessmentService.DomainModels.Skill;

namespace SkillAssessor.AssessmentService.Domain.Queries.Skills;

public record GetSkillByIdQuery(string Id) : IRequest<SkillModel>;
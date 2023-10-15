using MediatR;
using SkillAssessor.AssessmentService.Domain.Queries.Skills.Get;
using SkillAssessor.AssessmentService.DomainModels.Skills;

namespace SkillAssessor.AssessmentService.Api.Queries;

[ExtendObjectType(Name = "Query")]
public sealed class SkillQueries
{
    public async Task<SkillDto> GetSkillById([Service] IMediator mediator, GetSkillByIdQuery request)
    {
        var skill = await mediator.Send(request);

        return skill;
    }
}
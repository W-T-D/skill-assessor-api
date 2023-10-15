using MediatR;
using SkillAssessor.AssessmentService.Domain.Queries.SkillLevels.Get;
using SkillAssessor.AssessmentService.DomainModels.SkillLevels;

namespace SkillAssessor.AssessmentService.Api.Queries;

[ExtendObjectType(Name = "Query")]
public sealed class SkillLevelQueries
{
    public async Task<SkillLevelDto> GetSkillLevelById([Service] IMediator mediator, GetSkillLevelQuery request)
    {
        var skillLevel = await mediator.Send(request);
        
        return skillLevel;
    }
}
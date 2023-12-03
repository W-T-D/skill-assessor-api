using MediatR;
using SkillAssessor.EmployeeService.Domain.Queries.SkillLevels.Get;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;

namespace SkillAssessor.EmployeeService.Api.Queries;

[ExtendObjectType(Name = "Query")]
public sealed class SkillLevelQueries
{
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public async Task<IQueryable<SkillLevelDto>> GetSkillLevels([Service] IMediator mediator,
        GetSkillLevelQuery request)
    {
        var skillLevels = await mediator.Send(request);

        return skillLevels;
    }
}
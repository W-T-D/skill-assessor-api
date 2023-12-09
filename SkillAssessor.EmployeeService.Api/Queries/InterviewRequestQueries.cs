using MediatR;
using SkillAssessor.EmployeeService.Domain.Queries.InterviewRequests.Get;
using SkillAssessor.EmployeeService.DomainModels.InterviewRequest;

namespace SkillAssessor.EmployeeService.Api.Queries;

[ExtendObjectType(Name = "Query")]
public sealed class InterviewRequestQueries
{
    [UseOffsetPaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public async Task<IQueryable<InterviewRequestDto>> GetInterviewRequests([Service] IMediator mediator,
        GetInterviewRequestQuery request)
    {
        var interviewRequests = await mediator.Send(request);

        return interviewRequests;
    }
}
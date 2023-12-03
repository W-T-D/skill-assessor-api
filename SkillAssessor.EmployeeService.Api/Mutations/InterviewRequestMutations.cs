using MediatR;
using SkillAssessor.EmployeeService.Domain.Commands.InterviewRequests.Add;
using SkillAssessor.EmployeeService.Domain.Commands.InterviewRequests.Delete;
using SkillAssessor.EmployeeService.Domain.Commands.InterviewRequests.Edit;
using SkillAssessor.EmployeeService.DomainModels.InterviewRequest;

namespace SkillAssessor.EmployeeService.Api.Mutations;

[ExtendObjectType(Name = "Mutation")]
public sealed class InterviewRequestMutations
{
    public async Task<InterviewRequestDto> AddInterviewRequest([Service] IMediator mediator,
        AddInterviewRequestCommand command)
    {
        var interviewRequest = await mediator.Send(command);

        return interviewRequest;
    }
    
    public async Task<InterviewRequestDto> EditInterviewRequest([Service] IMediator mediator,
        EditInterviewRequestCommand command)
    {
        var interviewRequest = await mediator.Send(command);

        return interviewRequest;
    }
    
    public async Task<InterviewRequestDto> DeleteInterviewRequest([Service] IMediator mediator,
        DeleteInterviewRequestCommand command)
    {
        var interviewRequest = await mediator.Send(command);

        return interviewRequest;
    }
}
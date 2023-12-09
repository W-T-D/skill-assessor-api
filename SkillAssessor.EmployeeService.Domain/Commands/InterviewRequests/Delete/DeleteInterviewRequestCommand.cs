using MediatR;
using SkillAssessor.EmployeeService.DomainModels.InterviewRequest;

namespace SkillAssessor.EmployeeService.Domain.Commands.InterviewRequests.Delete;

public record DeleteInterviewRequestCommand(Guid Id) : IRequest<InterviewRequestDto>;
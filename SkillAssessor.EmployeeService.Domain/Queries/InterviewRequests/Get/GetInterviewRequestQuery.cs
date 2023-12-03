using MediatR;
using SkillAssessor.EmployeeService.DomainModels.InterviewRequest;

namespace SkillAssessor.EmployeeService.Domain.Queries.InterviewRequests.Get;

public record GetInterviewRequestQuery() : IRequest<IQueryable<InterviewRequestDto>>;
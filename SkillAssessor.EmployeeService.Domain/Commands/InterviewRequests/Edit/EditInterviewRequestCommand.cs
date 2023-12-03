using MediatR;
using SkillAssessor.EmployeeService.DomainModels.Employee;
using SkillAssessor.EmployeeService.DomainModels.InterviewRequest;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;

namespace SkillAssessor.EmployeeService.Domain.Commands.InterviewRequests.Edit;

public record EditInterviewRequestCommand(Guid Id, DateTime InterviewDate, SkillLevelDto SkillLevel,
    EmployeeDto Employee) : IRequest<InterviewRequestDto>;
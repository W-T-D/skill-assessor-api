using MediatR;
using SkillAssessor.EmployeeService.DomainModels.Employee;
using SkillAssessor.EmployeeService.DomainModels.InterviewRequest;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;

namespace SkillAssessor.EmployeeService.Domain.Commands.InterviewRequests.Add;

public record AddInterviewRequestCommand(DateTime InterviewDate, SkillLevelDto SkillLevel, EmployeeDto Employee) 
    : IRequest<InterviewRequestDto>;
using AutoMapper;
using SkillAssessor.EmployeeService.Domain.Commands.InterviewRequests.Add;
using SkillAssessor.EmployeeService.DomainModels.InterviewRequest;
using SkillAssessor.EmployeeService.Entity.InterviewRequests;

namespace SkillAssessor.EmployeeService.Domain.Mapper;

public sealed class InterviewRequestProfile : Profile
{
    public InterviewRequestProfile()
    {
        CreateMap<InterviewRequest, InterviewRequestDto>().ReverseMap();
        CreateMap<AddInterviewRequestCommand, InterviewRequest>();
        CreateProjection<InterviewRequest, InterviewRequestDto>();
    }
}
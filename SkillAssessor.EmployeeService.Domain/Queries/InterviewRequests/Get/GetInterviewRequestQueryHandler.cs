using AutoMapper;
using MediatR;
using SkillAssessor.EmployeeService.Data.Interfaces;
using SkillAssessor.EmployeeService.DomainModels.InterviewRequest;

namespace SkillAssessor.EmployeeService.Domain.Queries.InterviewRequests.Get;

public class GetInterviewRequestQueryHandler : IRequestHandler<GetInterviewRequestQuery, IQueryable<InterviewRequestDto>>
{
    private readonly IEmployeeUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    
    public GetInterviewRequestQueryHandler(IEmployeeUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    
    public Task<IQueryable<InterviewRequestDto>> Handle(GetInterviewRequestQuery request, CancellationToken cancellationToken)
    {
        var interviewRequests = _unitOfWork.InterviewRequests.GetAll();
        var interviewRequestsDto = _mapper.ProjectTo<InterviewRequestDto>(interviewRequests);

        return Task.FromResult(interviewRequestsDto);
    }
}
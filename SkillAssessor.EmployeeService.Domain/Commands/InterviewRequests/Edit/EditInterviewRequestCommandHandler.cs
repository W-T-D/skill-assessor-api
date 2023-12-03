using AutoMapper;
using MediatR;
using SkillAssessor.EmployeeService.Data.Interfaces;
using SkillAssessor.EmployeeService.DomainModels.InterviewRequest;
using SkillAssessor.EmployeeService.Entity.InterviewRequests;

namespace SkillAssessor.EmployeeService.Domain.Commands.InterviewRequests.Edit;

public class EditInterviewRequestCommandHandler : IRequestHandler<EditInterviewRequestCommand, InterviewRequestDto>
{
    private readonly IEmployeeUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;


    public EditInterviewRequestCommandHandler(IMapper mapper, IEmployeeUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task<InterviewRequestDto> Handle(EditInterviewRequestCommand request, CancellationToken cancellationToken)
    {
        var interviewRequest = _mapper.Map<InterviewRequest>(request);
        await _unitOfWork.InterviewRequests.UpdateAsync(interviewRequest, cancellationToken);
        var interviewRequestDto = _mapper.Map<InterviewRequestDto>(interviewRequest);

        return interviewRequestDto;
    }
}
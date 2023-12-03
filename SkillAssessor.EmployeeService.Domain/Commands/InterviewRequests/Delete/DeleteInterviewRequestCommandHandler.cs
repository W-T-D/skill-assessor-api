using AutoMapper;
using MediatR;
using SkillAssessor.Common.Exceptions.Data;
using SkillAssessor.EmployeeService.Data.Interfaces;
using SkillAssessor.EmployeeService.DomainModels.InterviewRequest;

namespace SkillAssessor.EmployeeService.Domain.Commands.InterviewRequests.Delete;

public class DeleteInterviewRequestCommandHandler : IRequestHandler<DeleteInterviewRequestCommand, InterviewRequestDto>
{
    private readonly IEmployeeUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;


    public DeleteInterviewRequestCommandHandler(IMapper mapper, IEmployeeUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task<InterviewRequestDto> Handle(DeleteInterviewRequestCommand request, CancellationToken cancellationToken)
    {
        var interviewRequest = await _unitOfWork.InterviewRequests.GetByIdAsync(request.Id, cancellationToken);

        if (interviewRequest is null)
        {
            throw new ItemDoNotFoundException();
        }

        await _unitOfWork.InterviewRequests.DeleteAsync(interviewRequest, cancellationToken);
        var interviewRequestDto = _mapper.Map<InterviewRequestDto>(interviewRequest);

        return interviewRequestDto;
    }
}
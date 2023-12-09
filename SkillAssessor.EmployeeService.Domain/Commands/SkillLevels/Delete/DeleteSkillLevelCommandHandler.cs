using AutoMapper;
using MediatR;
using SkillAssessor.Common.Exceptions.Data;
using SkillAssessor.EmployeeService.Data.Interfaces;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;

namespace SkillAssessor.EmployeeService.Domain.Commands.SkillLevels.Delete;

public class DeleteSkillLevelCommandHandler : IRequestHandler<DeleteSkillLevelCommand, SkillLevelDto>
{
    private readonly IEmployeeUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;


    public DeleteSkillLevelCommandHandler(IMapper mapper, IEmployeeUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task<SkillLevelDto> Handle(DeleteSkillLevelCommand request, CancellationToken cancellationToken)
    {
        var skillLevel = await _unitOfWork.SkillLevels.GetByIdAsync(request.Id, cancellationToken);

        if (skillLevel is null)
        {
            throw new ItemDoNotFoundException();
        }

        await _unitOfWork.SkillLevels.DeleteAsync(skillLevel, cancellationToken);
        var skillLevelDto = _mapper.Map<SkillLevelDto>(skillLevel);

        return skillLevelDto;
    }
}
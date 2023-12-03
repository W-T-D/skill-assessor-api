using AutoMapper;
using MediatR;
using SkillAssessor.EmployeeService.Data.Interfaces;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;
using SkillAssessor.EmployeeService.Entity.SkillLevels;

namespace SkillAssessor.EmployeeService.Domain.Commands.SkillLevels.Edit;

public class EditSkillLevelCommandHandler : IRequestHandler<EditSkillLevelCommand, SkillLevelDto>
{
    private readonly IEmployeeUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;


    public EditSkillLevelCommandHandler(IMapper mapper, IEmployeeUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task<SkillLevelDto> Handle(EditSkillLevelCommand request, CancellationToken cancellationToken)
    {
        var skillLevel = _mapper.Map<SkillLevel>(request);
        await _unitOfWork.SkillLevels.UpdateAsync(skillLevel, cancellationToken);
        var skillLevelDto = _mapper.Map<SkillLevelDto>(skillLevel);

        return skillLevelDto;
    }
}
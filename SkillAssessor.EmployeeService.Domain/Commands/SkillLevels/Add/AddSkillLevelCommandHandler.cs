using AutoMapper;
using MediatR;
using SkillAssessor.EmployeeService.Data.Interfaces;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;
using SkillAssessor.EmployeeService.Entity.SkillLevels;

namespace SkillAssessor.EmployeeService.Domain.Commands.SkillLevels.Add;

public class AddSkillLevelCommandHandler : IRequestHandler<AddSkillLevelCommand, SkillLevelDto>
{
    private readonly IEmployeeUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;


    public AddSkillLevelCommandHandler(IMapper mapper, IEmployeeUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task<SkillLevelDto> Handle(AddSkillLevelCommand request, CancellationToken cancellationToken)
    {
        var skillLevel = _mapper.Map<SkillLevel>(request);
        await _unitOfWork.SkillLevels.CreateAsync(skillLevel, cancellationToken);
        var skillLevelDto = _mapper.Map<SkillLevelDto>(skillLevel);

        return skillLevelDto;
    }
}
using AutoMapper;
using MediatR;
using SkillAssessor.AssessmentService.Data.Interfaces;
using SkillAssessor.AssessmentService.DomainModels.SkillLevels;
using SkillAssessor.AssessmentService.Entity.Common;
using SkillAssessor.AssessmentService.Entity.SkillLevels;

namespace SkillAssessor.AssessmentService.Domain.Commands.SkillLevels.AddOrEdit;

public class AddOrEditSkillLevelCommandHandler : IRequestHandler<AddOrEditSkillLevelCommand, SkillLevelDto>
{
    private readonly IMapper _mapper;

    private readonly ISkillLevelRepository _skillLevelRepository;


    public AddOrEditSkillLevelCommandHandler(IMapper mapper, ISkillLevelRepository skillLevelRepository)
    {
        _mapper = mapper;
        _skillLevelRepository = skillLevelRepository;
    }

    
    public async Task<SkillLevelDto> Handle(AddOrEditSkillLevelCommand request, CancellationToken cancellationToken)
    {
        var skillLevelEntity = _mapper.Map<SkillLevel>(request);
        
        skillLevelEntity.InitializeEntity();
        
        var savedSkillLevel = await _skillLevelRepository.SaveAsync(skillLevelEntity, cancellationToken);
        var skillLevelDto = _mapper.Map<SkillLevelDto>(savedSkillLevel);

        return skillLevelDto;
    }
}
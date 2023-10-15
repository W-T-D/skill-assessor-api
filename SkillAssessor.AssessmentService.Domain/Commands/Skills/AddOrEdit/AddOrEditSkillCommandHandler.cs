using AutoMapper;
using MediatR;
using SkillAssessor.AssessmentService.Data.Interfaces;
using SkillAssessor.AssessmentService.DomainModels.Skills;
using SkillAssessor.AssessmentService.Entity.Common;
using SkillAssessor.AssessmentService.Entity.Skills;

namespace SkillAssessor.AssessmentService.Domain.Commands.Skills.AddOrEdit;

public class AddOrEditSkillCommandHandler : IRequestHandler<AddOrEditSkillCommand, SkillDto>
{
    private readonly ISkillRepository _skillRepository;

    private readonly IMapper _mapper;
    
    
    public AddOrEditSkillCommandHandler(ISkillRepository skillRepository, IMapper mapper)
    {
        _skillRepository = skillRepository;
        _mapper = mapper;
    }

    public async Task<SkillDto> Handle(AddOrEditSkillCommand request, CancellationToken cancellationToken)
    {
        var skillEntity = _mapper.Map<Skill>(request);
        
        skillEntity.InitializeEntity();
        
        var savedSkill = await _skillRepository.SaveAsync(skillEntity, cancellationToken);
        var skillDto = _mapper.Map<SkillDto>(savedSkill);

        return skillDto;
    }
}
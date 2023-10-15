using AutoMapper;
using MediatR;
using SkillAssessor.AssessmentService.Data.Interfaces;
using SkillAssessor.AssessmentService.DomainModels.SkillLevels;
using SkillAssessor.AssessmentService.DomainModels.Skills;
using SkillAssessor.Common.Exceptions.Request;

namespace SkillAssessor.AssessmentService.Domain.Queries.Skills.Get;

public sealed class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, SkillDto>
{
    private readonly ISkillRepository _skillRepository;
    
    private readonly ISkillLevelRepository _skillLevelRepository;

    private readonly IMapper _mapper;


    public GetSkillByIdQueryHandler(IMapper mapper, ISkillLevelRepository skillLevelRepository,
        ISkillRepository skillRepository)
    {
        _mapper = mapper;
        _skillLevelRepository = skillLevelRepository;
        _skillRepository = skillRepository;
    }
    
    
    public async Task<SkillDto> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Id))
        {
            throw new BadRequestException();
        }
        
        var skill = await _skillRepository.GetByIdAsync(request.Id, cancellationToken);
        var skillDto = _mapper.Map<SkillDto>(skill);
        
        var skillLevels = await _skillLevelRepository
            .GetLevelsBySkillIdAsync(skillDto.Id, cancellationToken);
        var skillLevelsDtos = _mapper.Map<IReadOnlyCollection<SkillLevelDto>>(skillLevels);

        skillDto.SkillLevels = skillLevelsDtos;

        return skillDto;
    }
}
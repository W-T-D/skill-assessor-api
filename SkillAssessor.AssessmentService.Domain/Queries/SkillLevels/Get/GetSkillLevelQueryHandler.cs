using AutoMapper;
using MediatR;
using SkillAssessor.AssessmentService.Data.Interfaces;
using SkillAssessor.AssessmentService.DomainModels.SkillLevels;
using SkillAssessor.Common.Exceptions.Request;

namespace SkillAssessor.AssessmentService.Domain.Queries.SkillLevels.Get;

public sealed class GetSkillLevelQueryHandler : IRequestHandler<GetSkillLevelQuery, SkillLevelDto>
{
    private readonly IMapper _mapper;

    private readonly ISkillLevelRepository _skillLevelRepository;
    
    
    public GetSkillLevelQueryHandler(IMapper mapper, ISkillLevelRepository skillLevelRepository)
    {
        _mapper = mapper;
        _skillLevelRepository = skillLevelRepository;
    }
    
    
    public async Task<SkillLevelDto> Handle(GetSkillLevelQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Id))
        {
            throw new BadRequestException();
        }

        var skillLevel = await _skillLevelRepository.GetByIdAsync(request.Id, cancellationToken);
        var skillLevelDto = _mapper.Map<SkillLevelDto>(skillLevel);

        return skillLevelDto;
    }
}
using AutoMapper;
using MediatR;
using SkillAssessor.AssessmentService.Data.Interfaces;
using SkillAssessor.AssessmentService.DomainModels.Skill;
using SkillAssessor.AssessmentService.Entity.Skill;
using SkillAssessor.Common.Exceptions.Request;

namespace SkillAssessor.AssessmentService.Domain.Queries.Skills;

public sealed class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, SkillModel>
{
    private readonly IRepository<Skill> _repository;
    
    private readonly ISkillLevelRepository _skillLevelRepository;

    private readonly IMapper _mapper;


    public GetSkillByIdQueryHandler(IRepository<Skill> repository, IMapper mapper,
        ISkillLevelRepository skillLevelRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _skillLevelRepository = skillLevelRepository;
    }
    
    
    public async Task<SkillModel> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Id))
        {
            throw new BadRequestException();
        }
        
        var skill = await _repository.GetByIdAsync(request.Id);
        var skillModel = _mapper.Map<SkillModel>(skill);

        var skillLevels = await _skillLevelRepository.GetLevelsBySkillIdAsync(skillModel.Id);
        var skillLevelsModels = _mapper.Map<IReadOnlyCollection<SkillLevelModel>>(skillLevels);

        skillModel.SkillLevels = skillLevelsModels;

        return skillModel;
    }
}
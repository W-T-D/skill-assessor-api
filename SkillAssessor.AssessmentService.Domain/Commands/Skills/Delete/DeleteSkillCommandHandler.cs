using AutoMapper;
using MediatR;
using SkillAssessor.AssessmentService.Data.Interfaces;
using SkillAssessor.AssessmentService.DomainModels.Skills;

namespace SkillAssessor.AssessmentService.Domain.Commands.Skills.Delete;

public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand, SkillDto>
{
    private readonly ISkillRepository _skillRepository;

    private readonly IMapper _mapper;
    
    
    public DeleteSkillCommandHandler(IMapper mapper, ISkillRepository skillRepository)
    {
        _mapper = mapper;
        _skillRepository = skillRepository;
    }
    
    
    public async Task<SkillDto> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
    {
        var skillEntity = await _skillRepository.DeleteAsync(request.Id, cancellationToken);
        var skillDto = _mapper.Map<SkillDto>(skillEntity);

        return skillDto;
    }
}
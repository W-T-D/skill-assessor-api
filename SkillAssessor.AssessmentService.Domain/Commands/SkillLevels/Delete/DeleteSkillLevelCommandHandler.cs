using AutoMapper;
using MediatR;
using SkillAssessor.AssessmentService.Data.Interfaces;
using SkillAssessor.AssessmentService.DomainModels.SkillLevels;
using SkillAssessor.Common.Exceptions.Request;

namespace SkillAssessor.AssessmentService.Domain.Commands.SkillLevels.Delete;

public class DeleteSkillLevelCommandHandler : IRequestHandler<DeleteSkillLevelCommand, SkillLevelDto>
{
    private readonly IMapper _mapper;

    private readonly ISkillLevelRepository _skillLevelRepository;


    public DeleteSkillLevelCommandHandler(IMapper mapper, ISkillLevelRepository skillLevelRepository)
    {
        _mapper = mapper;
        _skillLevelRepository = skillLevelRepository;
    }

    
    public async Task<SkillLevelDto> Handle(DeleteSkillLevelCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Id))
        {
            throw new BadRequestException();
        }

        var skillLevelEntity = await _skillLevelRepository.DeleteAsync(request.Id, cancellationToken);
        var skillLevelDto = _mapper.Map<SkillLevelDto>(skillLevelEntity);

        return skillLevelDto;
    }
}
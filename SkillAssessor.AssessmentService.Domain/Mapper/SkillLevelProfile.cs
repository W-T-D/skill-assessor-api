using AutoMapper;
using SkillAssessor.AssessmentService.Domain.Commands.SkillLevels.AddOrEdit;
using SkillAssessor.AssessmentService.DomainModels.SkillLevels;
using SkillAssessor.AssessmentService.Entity.SkillLevels;

namespace SkillAssessor.AssessmentService.Domain.Mapper;

public sealed class SkillLevelProfile : Profile
{
    public SkillLevelProfile()
    {
        CreateMap<AddOrEditSkillLevelCommand, SkillLevel>();
        
        CreateMap<SkillLevel, SkillLevelDto>()
            .ReverseMap();
    }
}
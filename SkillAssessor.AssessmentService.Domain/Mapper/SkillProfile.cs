using AutoMapper;
using SkillAssessor.AssessmentService.Domain.Commands.Skills.AddOrEdit;
using SkillAssessor.AssessmentService.DomainModels.Skills;
using SkillAssessor.AssessmentService.Entity.Skills;

namespace SkillAssessor.AssessmentService.Domain.Mapper;

public sealed class SkillProfile : Profile
{
    public SkillProfile()
    {
        CreateMap<AddOrEditSkillCommand, Skill>();
        
        CreateMap<Skill, SkillDto>()
            .ReverseMap();
    }
}
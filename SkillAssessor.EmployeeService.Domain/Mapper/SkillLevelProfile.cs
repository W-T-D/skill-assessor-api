using AutoMapper;
using SkillAssessor.EmployeeService.Domain.Commands.SkillLevels.Add;
using SkillAssessor.EmployeeService.Domain.Commands.SkillLevels.Edit;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;
using SkillAssessor.EmployeeService.Entity.SkillLevels;

namespace SkillAssessor.EmployeeService.Domain.Mapper;

public sealed class SkillLevelProfile : Profile
{
    public SkillLevelProfile()
    {
        CreateMap<SkillLevel, SkillLevelDto>().ReverseMap();
        CreateMap<AddSkillLevelCommand, SkillLevel>();
        CreateMap<EditSkillLevelCommand, SkillLevel>();
        CreateProjection<SkillLevel, SkillLevelDto>();
    }
}
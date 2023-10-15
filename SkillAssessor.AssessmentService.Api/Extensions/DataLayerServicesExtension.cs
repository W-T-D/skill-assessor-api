using SkillAssessor.AssessmentService.Data;
using SkillAssessor.AssessmentService.Data.Interfaces;

namespace SkillAssessor.AssessmentService.Api.Extensions;

public static class DataLayerServicesExtension
{
    public static void AddDataLayerServices(this IServiceCollection services)
    {
        services.AddScoped<ISkillLevelRepository, SkillLevelRepository>();
        services.AddScoped<ISkillRepository, SkillRepository>();
    }
}
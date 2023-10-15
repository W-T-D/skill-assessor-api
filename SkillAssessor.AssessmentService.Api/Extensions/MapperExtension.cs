using SkillAssessor.AssessmentService.Domain.Queries.Skills.Get;

namespace SkillAssessor.AssessmentService.Api.Extensions;

public static class MapperExtension
{
    public static void AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(c =>
        {
            c.AddMaps(typeof(GetSkillByIdQuery).Assembly);
        });
    }
}
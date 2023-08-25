using SkillAssessor.AssessmentService.Api.Mutations;
using SkillAssessor.AssessmentService.Api.Queries;

namespace SkillAssessor.AssessmentService.Api.Extensions;

public static class GraphQlExtension
{
    public static void AddGraphQl(this IServiceCollection services)
    {
        services.AddGraphQLServer()
            .AddQueryType<SkillQueries>()
            .AddMutationType<SkillMutations>();
    }
}
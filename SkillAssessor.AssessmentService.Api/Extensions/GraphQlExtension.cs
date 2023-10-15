using SkillAssessor.AssessmentService.Api.Mutations;
using SkillAssessor.AssessmentService.Api.Queries;

namespace SkillAssessor.AssessmentService.Api.Extensions;

public static class GraphQlExtension
{
    public static void AddGraphQl(this IServiceCollection services)
    {
        services.AddGraphQLServer()
            .AddQueryType(d => d.Name("Query"))
            .AddTypeExtension<SkillQueries>()
            .AddTypeExtension<SkillLevelQueries>()
            .AddMutationType(d => d.Name("Mutation"))
            .AddTypeExtension<SkillMutations>()
            .AddTypeExtension<SkillLevelMutations>();
    }
}
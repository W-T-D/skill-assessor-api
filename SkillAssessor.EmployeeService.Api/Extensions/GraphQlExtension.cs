using SkillAssessor.EmployeeService.Api.Mutations;
using SkillAssessor.EmployeeService.Api.Queries;

namespace SkillAssessor.EmployeeService.Api.Extensions;

public static class GraphQlExtension
{
    public static void AddGraphQl(this IServiceCollection services)
    {
        services.AddGraphQLServer()
            .AddQueryType(d => d.Name("Query"))
            .AddTypeExtension<EmployeeQueries>()
            .AddTypeExtension<InterviewRequestQueries>()
            .AddTypeExtension<SkillLevelQueries>()
            .AddMutationType(d => d.Name("Mutation"))
            .AddTypeExtension<EmployeeMutations>()
            .AddTypeExtension<InterviewRequestMutations>();
    }
}
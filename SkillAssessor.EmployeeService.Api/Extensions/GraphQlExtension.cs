namespace SkillAssessor.EmployeeService.Api.Extensions;

public static class GraphQlExtension
{
    public static void AddGraphQl(this IServiceCollection services)
    {
        services.AddGraphQLServer();
    }
}
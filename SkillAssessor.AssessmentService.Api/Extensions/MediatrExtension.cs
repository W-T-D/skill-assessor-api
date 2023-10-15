using MediatR;
using SkillAssessor.AssessmentService.Domain.Pipelines;
using SkillAssessor.AssessmentService.Domain.Queries.Skills.Get;

namespace SkillAssessor.AssessmentService.Api.Extensions;

public static class MediatrExtension
{
    public static void AddMediatr(this IServiceCollection services)
    {
        services.AddMediatR(c =>
        {
            c.RegisterServicesFromAssembly(typeof(GetSkillByIdQuery).Assembly);
        });

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
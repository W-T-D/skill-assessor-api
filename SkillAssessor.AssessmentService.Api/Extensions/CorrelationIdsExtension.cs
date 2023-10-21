using SkillAssessor.AssessmentService.Api.Middlewares;

namespace SkillAssessor.AssessmentService.Api.Extensions;

public static class CorrelationIdsExtension
{
    public static void UseCorrelationIds(this WebApplication app)
    {
        app.UseMiddleware<CorrelationIdMiddleware>();
    }
}
using Amazon.Lambda.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace SkillAssessor.Clouds.CognitoSyncLambda;

[LambdaStartup]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
    }
}
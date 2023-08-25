using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace SkillAssessor.AssessmentService.Api.Extensions;

public static class AWSExtension
{
    public static void AddAWSServices(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        var awsOptions = configurationManager.GetAWSOptions();
        
        services.AddDefaultAWSOptions(awsOptions);
        services.AddAWSService<IAmazonDynamoDB>();
        services.AddScoped<IDynamoDBContext, DynamoDBContext>();
    }
}
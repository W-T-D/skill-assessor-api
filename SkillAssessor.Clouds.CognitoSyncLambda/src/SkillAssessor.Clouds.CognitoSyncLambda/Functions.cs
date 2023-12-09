using Amazon.Lambda.Core;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace SkillAssessor.Clouds.CognitoSyncLambda;

public class PreSignUp_AdminCreateUser
{
    public string userPoolId { get; set; }
    
    public Dictionary<string, string> userAttributes { get; set; }
    
}

public class Functions
{
    public Functions(PreSignUp_AdminCreateUser user)
    {
    }
}
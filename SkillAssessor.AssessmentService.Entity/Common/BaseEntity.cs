using Amazon.DynamoDBv2.DataModel;

namespace SkillAssessor.AssessmentService.Entity.Common;

public abstract class BaseEntity
{
    [DynamoDBHashKey("id")]
    public string Id { get; set; }
}
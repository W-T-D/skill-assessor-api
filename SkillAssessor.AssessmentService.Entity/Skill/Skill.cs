using Amazon.DynamoDBv2.DataModel;

namespace SkillAssessor.AssessmentService.Entity.Skill;

[DynamoDBTable("skills")]
public sealed class Skill
{
    [DynamoDBHashKey("id")]
    public string Id { get; set; }

    [DynamoDBProperty("url")]
    public string ImageUrl { get; set; }

    [DynamoDBProperty("title")]
    public string Title { get; set; }

    [DynamoDBProperty("description")]
    public string Description { get; set; }
}
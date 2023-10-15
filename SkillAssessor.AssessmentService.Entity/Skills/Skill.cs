using Amazon.DynamoDBv2.DataModel;
using SkillAssessor.AssessmentService.Entity.Common;

namespace SkillAssessor.AssessmentService.Entity.Skills;

[DynamoDBTable("skills")]
public sealed class Skill : BaseEntity
{
    [DynamoDBProperty("url")]
    public string ImageUrl { get; set; }

    [DynamoDBProperty("title")]
    public string Title { get; set; }

    [DynamoDBProperty("description")]
    public string Description { get; set; }
}
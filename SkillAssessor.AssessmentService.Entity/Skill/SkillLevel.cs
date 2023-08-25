using Amazon.DynamoDBv2.DataModel;

namespace SkillAssessor.AssessmentService.Entity.Skill;

[DynamoDBTable("skillLevels")]
public sealed class SkillLevel
{
    [DynamoDBHashKey("id")]
    public string Id { get; set; }

    [DynamoDBProperty("name")]
    public string Name { get; set; }

    [DynamoDBProperty("description")]
    public string Description { get; set; }

    [DynamoDBProperty("levelNumber")]
    public int LevelNumber { get; set; }

    [DynamoDBRangeKey("skillId")]
    public string SkillId { get; set; }
}
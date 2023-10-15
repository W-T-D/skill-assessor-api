using Amazon.DynamoDBv2.DataModel;
using SkillAssessor.AssessmentService.Entity.Common;

namespace SkillAssessor.AssessmentService.Entity.SkillLevels;

[DynamoDBTable("skillLevels")]
public sealed class SkillLevel : BaseEntity
{
    [DynamoDBProperty("name")]
    public string Name { get; set; }

    [DynamoDBProperty("description")]
    public string Description { get; set; }

    [DynamoDBProperty("levelNumber")]
    public int LevelNumber { get; set; }

    [DynamoDBRangeKey("skillId")]
    [DynamoDBProperty("skillId")]
    public string SkillId { get; set; }
}
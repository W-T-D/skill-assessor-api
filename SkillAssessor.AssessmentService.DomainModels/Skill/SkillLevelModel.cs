namespace SkillAssessor.AssessmentService.DomainModels.Skill;

public sealed class SkillLevelModel
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int LevelNumber { get; set; }

    public string SkillId { get; set; }
}
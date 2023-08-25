namespace SkillAssessor.AssessmentService.DomainModels.Skill;

public sealed class SkillModel
{
    public string Id { get; set; }

    public string ImageUrl { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public IReadOnlyCollection<SkillLevelModel> SkillLevels { get; set; }
}
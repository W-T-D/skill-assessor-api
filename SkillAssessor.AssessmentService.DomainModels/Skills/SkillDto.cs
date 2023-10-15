using SkillAssessor.AssessmentService.DomainModels.SkillLevels;

namespace SkillAssessor.AssessmentService.DomainModels.Skills;

public sealed class SkillDto
{
    public string Id { get; set; }

    public string ImageUrl { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public IReadOnlyCollection<SkillLevelDto> SkillLevels { get; set; }
}
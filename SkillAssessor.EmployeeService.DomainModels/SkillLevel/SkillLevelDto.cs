namespace SkillAssessor.EmployeeService.DomainModels.SkillLevel;

public sealed class SkillLevelDto
{
    public Guid Id { get; set; }

    public string SkillTitle { get; set; }

    public int LevelNumber { get; set; }
}
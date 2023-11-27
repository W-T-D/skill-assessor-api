using SkillAssessor.EmployeeService.Entity.Employees;

namespace SkillAssessor.EmployeeService.Entity.SkillLevels;

public sealed class SkillLevel
{
    public Guid Id { get; set; }

    public string SkillTitle { get; set; }

    public int LevelNumber { get; set; }
}
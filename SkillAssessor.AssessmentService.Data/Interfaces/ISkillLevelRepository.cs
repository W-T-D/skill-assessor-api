using SkillAssessor.AssessmentService.Entity.Skill;

namespace SkillAssessor.AssessmentService.Data.Interfaces;

public interface ISkillLevelRepository : IRepository<SkillLevel>
{
    Task<IReadOnlyCollection<SkillLevel>> GetLevelsBySkillIdAsync(string id);
}
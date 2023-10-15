using SkillAssessor.AssessmentService.Entity.SkillLevels;

namespace SkillAssessor.AssessmentService.Data.Interfaces;

public interface ISkillLevelRepository : IRepository<SkillLevel>
{
    Task<IReadOnlyCollection<SkillLevel>> GetLevelsBySkillIdAsync(string id, CancellationToken cancellationToken = default);
}
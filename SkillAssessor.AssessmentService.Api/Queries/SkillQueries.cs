using SkillAssessor.AssessmentService.Data.Interfaces;
using SkillAssessor.AssessmentService.Entity.Skill;

namespace SkillAssessor.AssessmentService.Api.Queries;

public sealed class SkillQueries
{
    public async Task<Skill> GetSkillById([Service] IRepository<Skill> repository, string id)
    {
        var skill = await repository.GetByIdAsync(id);

        return skill;
    }
}
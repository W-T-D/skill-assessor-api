using SkillAssessor.AssessmentService.Data.Interfaces;
using SkillAssessor.AssessmentService.Entity.Skill;

namespace SkillAssessor.AssessmentService.Api.Mutations;

public sealed class SkillMutations
{
    public async Task<Skill> AddSkill([Service] IRepository<Skill> repository, Skill skill)
    {
        var savedSkill = await repository.SaveAsync(skill);

        return savedSkill;
    }
}
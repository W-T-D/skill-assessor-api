using MediatR;
using SkillAssessor.AssessmentService.Domain.Commands.Skills.AddOrEdit;
using SkillAssessor.AssessmentService.Domain.Commands.Skills.Delete;
using SkillAssessor.AssessmentService.DomainModels.Skills;

namespace SkillAssessor.AssessmentService.Api.Mutations;

[ExtendObjectType(Name = "Mutation")]
public sealed class SkillMutations
{
    public async Task<SkillDto> AddOrEditSkill([Service] IMediator mediator, AddOrEditSkillCommand command)
    {
        var skill = await mediator.Send(command);

        return skill;
    }

    public async Task<SkillDto> DeleteSkill([Service] IMediator mediator, DeleteSkillCommand command)
    {
        var skill = await mediator.Send(command);

        return skill;
    }
}
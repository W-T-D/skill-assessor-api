using MediatR;
using SkillAssessor.AssessmentService.Domain.Commands.SkillLevels.AddOrEdit;
using SkillAssessor.AssessmentService.Domain.Commands.SkillLevels.Delete;
using SkillAssessor.AssessmentService.DomainModels.SkillLevels;

namespace SkillAssessor.AssessmentService.Api.Mutations;

[ExtendObjectType(Name = "Mutation")]
public sealed class SkillLevelMutations
{
    public async Task<SkillLevelDto> AddOrEditSkillLevel([Service] IMediator mediator, AddOrEditSkillLevelCommand command)
    {
        var skillLevel = await mediator.Send(command);

        return skillLevel;
    }

    public async Task<SkillLevelDto> DeleteSkillLevel([Service] IMediator mediator, DeleteSkillLevelCommand command)
    {
        var skillLevel = await mediator.Send(command);

        return skillLevel;
    }
}
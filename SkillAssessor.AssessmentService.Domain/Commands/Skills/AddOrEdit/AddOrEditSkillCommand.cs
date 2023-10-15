using MediatR;
using SkillAssessor.AssessmentService.DomainModels.Skills;

namespace SkillAssessor.AssessmentService.Domain.Commands.Skills.AddOrEdit;

public record AddOrEditSkillCommand (string? Id, string ImageUrl, string Title, string Description) 
    : IRequest<SkillDto>;
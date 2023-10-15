using MediatR;
using SkillAssessor.AssessmentService.DomainModels.Skills;

namespace SkillAssessor.AssessmentService.Domain.Commands.Skills.Delete;

public record DeleteSkillCommand(string Id) : IRequest<SkillDto>;
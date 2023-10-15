using FluentValidation;

namespace SkillAssessor.AssessmentService.Domain.Commands.Skills.Delete;

public class DeleteSkillCommandValidator : AbstractValidator<DeleteSkillCommand>
{
    private const string _guidRegex = "^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$";
    
    public DeleteSkillCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .Matches(_guidRegex)
            .WithMessage("Id is invalid");
    }
}
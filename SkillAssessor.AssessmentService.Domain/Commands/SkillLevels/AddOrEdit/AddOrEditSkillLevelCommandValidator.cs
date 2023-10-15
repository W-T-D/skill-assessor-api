using FluentValidation;

namespace SkillAssessor.AssessmentService.Domain.Commands.SkillLevels.AddOrEdit;

public class AddOrEditSkillLevelCommandValidator : AbstractValidator<AddOrEditSkillLevelCommand>
{
    private const string _guidRegex = "^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$";
    
    public AddOrEditSkillLevelCommandValidator()
    {
        When(p => !string.IsNullOrEmpty(p.Id), () =>
        {
            RuleFor(p => p.Id).Matches(_guidRegex);
        });
        
        RuleFor(p => p.Description)
            .NotEmpty()
            .WithMessage("Description can not be empty");
        
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Name can not be empty");

        RuleFor(p => p.SkillId)
            .NotEmpty()
            .Matches(_guidRegex)
            .WithMessage("SkillId is invalid");
    }
}
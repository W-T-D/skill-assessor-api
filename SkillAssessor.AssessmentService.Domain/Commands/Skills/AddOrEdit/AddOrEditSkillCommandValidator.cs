using FluentValidation;

namespace SkillAssessor.AssessmentService.Domain.Commands.Skills.AddOrEdit;

public class AddOrEditSkillCommandValidator : AbstractValidator<AddOrEditSkillCommand>
{
    private const string _guidRegex = "^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$";
    
    private const string _urlRegex =
        @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)";
    
    public AddOrEditSkillCommandValidator()
    {
        When(p => !string.IsNullOrEmpty(p.Id), () =>
        {
            RuleFor(p => p.Id).Matches(_guidRegex);
        });
        
        RuleFor(p => p.Description)
            .NotEmpty()
            .WithMessage("Description can not be empty");

        RuleFor(p => p.ImageUrl)
            .NotEmpty()
            .Matches(_urlRegex)
            .WithMessage("Url is invalid");
        
        
    }
}
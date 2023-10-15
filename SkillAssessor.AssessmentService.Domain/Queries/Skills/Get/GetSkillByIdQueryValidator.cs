using FluentValidation;

namespace SkillAssessor.AssessmentService.Domain.Queries.Skills.Get;

public class GetSkillByIdQueryValidator : AbstractValidator<GetSkillByIdQuery>
{
    private const string _guidRegex = "^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$";
    
    public GetSkillByIdQueryValidator()
    {
        RuleFor(p => p.Id)
            .Matches(_guidRegex);
    }
}
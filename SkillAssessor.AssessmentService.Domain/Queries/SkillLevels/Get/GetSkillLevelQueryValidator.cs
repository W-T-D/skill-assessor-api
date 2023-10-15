using FluentValidation;

namespace SkillAssessor.AssessmentService.Domain.Queries.SkillLevels.Get;

public class GetSkillLevelQueryValidator : AbstractValidator<GetSkillLevelQuery>
{
    private const string _guidRegex = "^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?$";
    
    public GetSkillLevelQueryValidator()
    {
        RuleFor(p => p.Id)
            .Matches(_guidRegex);
    }
}
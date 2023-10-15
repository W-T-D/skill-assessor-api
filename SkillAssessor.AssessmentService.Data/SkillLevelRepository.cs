using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using SkillAssessor.AssessmentService.Data.Interfaces;
using SkillAssessor.AssessmentService.Entity.SkillLevels;
using SkillAssessor.AssessmentService.Entity.Skills;
using SkillAssessor.Common.Exceptions.Data;

namespace SkillAssessor.AssessmentService.Data;

public class SkillLevelRepository : Repository<SkillLevel>, ISkillLevelRepository
{
    public SkillLevelRepository(IDynamoDBContext dynamoDbContext) : base(dynamoDbContext) { }


    public async Task<IReadOnlyCollection<SkillLevel>> GetLevelsBySkillIdAsync(string id, CancellationToken cancellationToken)
    {
        var scanConditions = new List<ScanCondition>
        {
            new(nameof(SkillLevel.SkillId), ScanOperator.Equal, id)
        };

        var skillLevelsScanSearch = DynamoDbContext.ScanAsync<SkillLevel>(scanConditions);
        var skillLevels = await skillLevelsScanSearch.GetRemainingAsync(cancellationToken);

        if (skillLevels is null || !skillLevels.Any())
        {
            throw new ItemDoNotFoundException();
        }
        
        return skillLevels;
    }

    public override async Task<SkillLevel> SaveAsync(SkillLevel item, CancellationToken cancellationToken)
    {
        var skill = await DynamoDbContext.LoadAsync<Skill>(item.SkillId, cancellationToken);

        if (skill is null)
        {
            throw new ItemDoNotFoundException();
        }

        var skillLevel = await base.SaveAsync(item, cancellationToken);

        return skillLevel;
    }
}
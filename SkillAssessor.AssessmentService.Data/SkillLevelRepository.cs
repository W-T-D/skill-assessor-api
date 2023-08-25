using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using SkillAssessor.AssessmentService.Data.Interfaces;
using SkillAssessor.AssessmentService.Entity.Skill;
using SkillAssessor.Common.Exceptions.Data;

namespace SkillAssessor.AssessmentService.Data;

public class SkillLevelRepository : Repository<SkillLevel>, ISkillLevelRepository
{
    public SkillLevelRepository(IDynamoDBContext dynamoDbContext) : base(dynamoDbContext) { }


    public async Task<IReadOnlyCollection<SkillLevel>> GetLevelsBySkillIdAsync(string id)
    {
        var scanConditions = new List<ScanCondition>
        {
            new("skillId", ScanOperator.Equal, id)
        };

        var skillLevelsScanSearch = DynamoDbContext.ScanAsync<SkillLevel>(scanConditions);
        var skillLevels = await skillLevelsScanSearch.GetRemainingAsync();

        if (skillLevels is null || !skillLevels.Any())
        {
            throw new ItemDoNotFoundException();
        }
        
        return skillLevels;
    }
}
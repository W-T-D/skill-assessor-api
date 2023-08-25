using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using SkillAssessor.AssessmentService.Data.Interfaces;
using SkillAssessor.AssessmentService.Entity.Skill;
using SkillAssessor.Common.Models.Pagination;

namespace SkillAssessor.AssessmentService.Data;

public sealed class SkillRepository : Repository<Skill>, ISkillRepository
{
    public SkillRepository(IDynamoDBContext dynamoDbContext) : base(dynamoDbContext) { }


    public override async Task DeleteAsync(object id)
    {
        var skillBatch = DynamoDbContext.CreateBatchWrite<Skill>();

        var skill = await GetByIdAsync(id);
        skillBatch.AddDeleteItem(skill);
        
        var skillLevelsBatch = DynamoDbContext.CreateBatchWrite<SkillLevel>();
        
        var scanConditions = new List<ScanCondition>
        {
            new("skillId", ScanOperator.Equal, id)
        };

        var skillLevelsScanSearch = DynamoDbContext.ScanAsync<SkillLevel>(scanConditions);
        var skillLevels = await skillLevelsScanSearch.GetRemainingAsync();
        
        skillLevelsBatch.AddDeleteItems(skillLevels);
        
        var multiTableBatch = DynamoDbContext.CreateMultiTableBatchWrite(skillBatch, skillLevelsBatch);

        await multiTableBatch.ExecuteAsync();
    }
}
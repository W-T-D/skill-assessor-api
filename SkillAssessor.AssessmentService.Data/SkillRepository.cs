using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using SkillAssessor.AssessmentService.Data.Interfaces;
using SkillAssessor.AssessmentService.Entity.SkillLevels;
using SkillAssessor.AssessmentService.Entity.Skills;

namespace SkillAssessor.AssessmentService.Data;

public sealed class SkillRepository : Repository<Skill>, ISkillRepository
{
    public SkillRepository(IDynamoDBContext dynamoDbContext) : base(dynamoDbContext) { }


    public override async Task<Skill> DeleteAsync(object id, CancellationToken cancellationToken)
    {
        var skillBatch = DynamoDbContext.CreateBatchWrite<Skill>();

        var skill = await GetByIdAsync(id, cancellationToken);
        skillBatch.AddDeleteItem(skill);
        
        var skillLevelsBatch = DynamoDbContext.CreateBatchWrite<SkillLevel>();
        
        var scanConditions = new List<ScanCondition>
        {
            new(nameof(SkillLevel.SkillId), ScanOperator.Equal, id)
        };

        var skillLevelsScanSearch = DynamoDbContext.ScanAsync<SkillLevel>(scanConditions);
        var skillLevels = await skillLevelsScanSearch.GetRemainingAsync(cancellationToken);
        
        skillLevelsBatch.AddDeleteItems(skillLevels);
        
        var multiTableBatch = DynamoDbContext.CreateMultiTableBatchWrite(skillBatch, skillLevelsBatch);

        await multiTableBatch.ExecuteAsync(cancellationToken);

        return skill;
    }
}
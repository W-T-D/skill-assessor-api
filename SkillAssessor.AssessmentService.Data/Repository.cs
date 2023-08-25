using Amazon.DynamoDBv2.DataModel;
using SkillAssessor.AssessmentService.Data.Interfaces;
using SkillAssessor.Common.Exceptions.Data;

namespace SkillAssessor.AssessmentService.Data;

public class Repository<T> : IRepository<T>
{
    protected readonly IDynamoDBContext DynamoDbContext;

    
    public Repository(IDynamoDBContext dynamoDbContext)
    {
        DynamoDbContext = dynamoDbContext;
    }


    public async Task<T> GetByIdAsync(object partitionKey, object? sortKey = null)
    {
        var item = await DynamoDbContext.LoadAsync<T>(partitionKey, sortKey);
        
        if (item is null)
        {
            throw new ItemDoNotFoundException();
        }
        
        return item;
    }

    public async Task<T> SaveAsync(T item)
    {
        await DynamoDbContext.SaveAsync(item);

        return item;
    }

    public virtual async Task DeleteAsync(object id)
    {
        await DynamoDbContext.DeleteAsync(id);
    }
}
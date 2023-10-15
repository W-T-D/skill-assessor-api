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


    public async Task<T> GetByIdAsync(object partitionKey, CancellationToken cancellationToken, object? sortKey = null)
    {
        var item = await DynamoDbContext.LoadAsync<T>(partitionKey, sortKey, cancellationToken);
        
        if (item is null)
        {
            throw new ItemDoNotFoundException();
        }
        
        return item;
    }

    public virtual async Task<T> SaveAsync(T item, CancellationToken cancellationToken)
    {
        await DynamoDbContext.SaveAsync(item, cancellationToken);

        return item;
    }

    public virtual async Task<T> DeleteAsync(object id, CancellationToken cancellationToken)
    {
        var item = await DynamoDbContext.LoadAsync<T>(id, cancellationToken);
        
        if (item is null)
        {
            throw new ItemDoNotFoundException();
        }
        
        await DynamoDbContext.DeleteAsync(id, cancellationToken);

        return item;
    }
}
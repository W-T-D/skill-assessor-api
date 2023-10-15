namespace SkillAssessor.AssessmentService.Data.Interfaces;

public interface IRepository<T>
{
    Task<T> GetByIdAsync(object partitionKey, CancellationToken cancellationToken = default, object? sortKey = default);

    Task<T> SaveAsync(T item, CancellationToken cancellationToken = default);

    Task<T> DeleteAsync(object id, CancellationToken cancellationToken = default);
}
namespace SkillAssessor.AssessmentService.Data.Interfaces;

public interface IRepository<T>
{
    Task<T> GetByIdAsync(object partitionKey, object? sortKey = null);

    Task<T> SaveAsync(T item);

    Task DeleteAsync(object id);
}
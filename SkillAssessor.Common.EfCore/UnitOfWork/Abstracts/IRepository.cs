namespace SkillAssessor.Common.EfCore.UnitOfWork.Abstracts;

public interface IRepository<T>
{
    IQueryable<T> GetAll();
    
    Task CreateAsync(T data, CancellationToken cancellationToken = default);

    Task UpdateAsync(T data, CancellationToken cancellationToken = default);

    Task DeleteAsync(T data, CancellationToken cancellationToken = default);
}
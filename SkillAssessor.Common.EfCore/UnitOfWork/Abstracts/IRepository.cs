namespace SkillAssessor.Common.EfCore.UnitOfWork.Abstracts;

public interface IRepository<T>
{
    Task CreateAsync(T data);

    Task UpdateAsync(T data);

    Task DeleteAsync(T data);
}
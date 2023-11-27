namespace SkillAssessor.Common.EfCore.UnitOfWork.Abstracts;

public interface IUnitOfWork
{
    IRepository<T> GetRepository<T>() where T : class;
}
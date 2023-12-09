using Microsoft.EntityFrameworkCore;
using SkillAssessor.Common.EfCore.UnitOfWork.Abstracts;

namespace SkillAssessor.Common.EfCore.UnitOfWork;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbContext _dbContext;
    
    protected readonly DbSet<T> Data;


    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
        Data = _dbContext.Set<T>();
    }


    public IQueryable<T> GetAll()
    {
        return Data.AsQueryable();
    }
    
    public async Task CreateAsync(T data, CancellationToken cancellationToken = default)
    {
        Data.Add(data);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T data, CancellationToken cancellationToken = default)
    {
        Data.Update(data);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T data, CancellationToken cancellationToken = default)
    {
        Data.Remove(data);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
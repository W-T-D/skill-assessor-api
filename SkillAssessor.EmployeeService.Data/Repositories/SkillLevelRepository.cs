using Microsoft.EntityFrameworkCore;
using SkillAssessor.Common.EfCore.UnitOfWork;
using SkillAssessor.Common.Exceptions.Data;
using SkillAssessor.EmployeeService.Data.Repositories.Interfaces;
using SkillAssessor.EmployeeService.Entity.SkillLevels;

namespace SkillAssessor.EmployeeService.Data.Repositories;

public class SkillLevelRepository : Repository<SkillLevel>, ISkillLevelRepository
{
    public SkillLevelRepository(EmployeeDbContext dbContext) : base(dbContext) { }

    
    public async Task<SkillLevel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var skillLevel = await Data
            .AsNoTracking()
            .FirstOrDefaultAsync(sl => sl.Id == id, cancellationToken);

        if (skillLevel is null)
        {
            throw new ItemDoNotFoundException();
        }

        return skillLevel;
    }
}
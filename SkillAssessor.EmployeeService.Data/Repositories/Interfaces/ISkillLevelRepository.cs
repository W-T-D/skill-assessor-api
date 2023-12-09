using SkillAssessor.Common.EfCore.UnitOfWork.Abstracts;
using SkillAssessor.EmployeeService.Entity.SkillLevels;

namespace SkillAssessor.EmployeeService.Data.Repositories.Interfaces;

public interface ISkillLevelRepository : IRepository<SkillLevel>
{
    Task<SkillLevel> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
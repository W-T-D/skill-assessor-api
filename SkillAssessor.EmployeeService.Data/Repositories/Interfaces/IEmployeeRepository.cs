using SkillAssessor.Common.EfCore.UnitOfWork.Abstracts;
using SkillAssessor.EmployeeService.Entity.Employees;

namespace SkillAssessor.EmployeeService.Data.Repositories.Interfaces;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee> GetByIdAsync(Guid id);
}
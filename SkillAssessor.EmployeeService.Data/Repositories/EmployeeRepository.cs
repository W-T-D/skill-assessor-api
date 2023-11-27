using Microsoft.EntityFrameworkCore;
using SkillAssessor.Common.EfCore.UnitOfWork;
using SkillAssessor.Common.Exceptions.Data;
using SkillAssessor.EmployeeService.Data.Repositories.Interfaces;
using SkillAssessor.EmployeeService.Entity.Employees;

namespace SkillAssessor.EmployeeService.Data.Repositories;

public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(EmployeeDbContext dbContext) : base(dbContext) { }

    
    public async Task<Employee> GetByIdAsync(Guid id)
    {
        var employee = await Data
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);

        if (employee is null)
        {
            throw new ItemDoNotFoundException();
        }

        return employee;
    }
}
using SkillAssessor.Common.EfCore.UnitOfWork;
using SkillAssessor.EmployeeService.Data.Interfaces;
using SkillAssessor.EmployeeService.Data.Repositories;
using SkillAssessor.EmployeeService.Data.Repositories.Interfaces;
using SkillAssessor.EmployeeService.Entity.Employees;
using SkillAssessor.EmployeeService.Entity.InterviewRequests;
using SkillAssessor.EmployeeService.Entity.SkillLevels;

namespace SkillAssessor.EmployeeService.Data;

public class EmployeeUnitOfWork : UnitOfWork, IEmployeeUnitOfWork
{
    public IEmployeeRepository Employees 
        => (IEmployeeRepository)GetRepository<Employee>();

    public IInterviewRequestRepository InterviewRequests
        => (IInterviewRequestRepository)GetRepository<InterviewRequest>();

    public ISkillLevelRepository SkillLevels
        => (ISkillLevelRepository)GetRepository<SkillLevel>();
    
    public EmployeeUnitOfWork(EmployeeDbContext dbContext) : base(dbContext)
    {
        AddSpecificRepository<Employee, EmployeeRepository>();
        AddSpecificRepository<InterviewRequest, InterviewRequestRepository>();
        AddSpecificRepository<SkillLevel, SkillLevelRepository>();
    }
}
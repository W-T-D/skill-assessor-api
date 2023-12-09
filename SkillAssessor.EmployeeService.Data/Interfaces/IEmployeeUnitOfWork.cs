using SkillAssessor.Common.EfCore.UnitOfWork.Abstracts;
using SkillAssessor.EmployeeService.Data.Repositories.Interfaces;

namespace SkillAssessor.EmployeeService.Data.Interfaces;

public interface IEmployeeUnitOfWork : IUnitOfWork
{
    IEmployeeRepository Employees { get; }
    
    IInterviewRequestRepository InterviewRequests { get; }
    
    ISkillLevelRepository SkillLevels { get; }
}
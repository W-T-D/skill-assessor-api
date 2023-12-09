using SkillAssessor.EmployeeService.Entity.Employees;
using SkillAssessor.EmployeeService.Entity.SkillLevels;

namespace SkillAssessor.EmployeeService.Entity.InterviewRequests;

public sealed class InterviewRequest
{
    public Guid Id { get; set; }

    public DateTime InterviewDate { get; set; }
    
    public SkillLevel SkillLevel { get; set; }
    
    public Employee Employee { get; set; }
    
    public ICollection<Employee> Interviewers { get; set; }
}
using SkillAssessor.EmployeeService.Entity.InterviewRequests;
using SkillAssessor.EmployeeService.Entity.SkillLevels;

namespace SkillAssessor.EmployeeService.Entity.Employees;

public sealed class Employee
{
    public Guid Id { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public DateOnly EmploymentDate { get; set; }

    public string Country { get; set; }

    public ICollection<SkillLevel> Skills { get; set; }

    public ICollection<InterviewRequest> InterviewRequests { get; set; }
}
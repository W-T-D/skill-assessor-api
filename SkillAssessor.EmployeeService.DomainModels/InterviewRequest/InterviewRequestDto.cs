using SkillAssessor.EmployeeService.DomainModels.Employee;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;

namespace SkillAssessor.EmployeeService.DomainModels.InterviewRequest;

public class InterviewRequestDto
{
    public Guid Id { get; set; }

    public DateTime InterviewDate { get; set; }
    
    public SkillLevelDto SkillLevel { get; set; }
    
    public EmployeeDto Employee { get; set; }
    
    public ICollection<EmployeeDto> Interviewers { get; set; }
}
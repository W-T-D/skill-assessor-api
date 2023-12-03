using SkillAssessor.EmployeeService.DomainModels.InterviewRequest;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;

namespace SkillAssessor.EmployeeService.DomainModels.Employee;

public class EmployeeDto
{
    public Guid Id { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public DateOnly EmploymentDate { get; set; }

    public string Country { get; set; }
    
    public ICollection<SkillLevelDto> Skills { get; set; }

    public ICollection<InterviewRequestDto> InterviewRequests { get; set; }
}
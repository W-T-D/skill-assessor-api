using SkillAssessor.Common.EfCore.UnitOfWork.Abstracts;
using SkillAssessor.EmployeeService.Entity.InterviewRequests;

namespace SkillAssessor.EmployeeService.Data.Repositories.Interfaces;

public interface IInterviewRequestRepository : IRepository<InterviewRequest>
{
    Task<InterviewRequest> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
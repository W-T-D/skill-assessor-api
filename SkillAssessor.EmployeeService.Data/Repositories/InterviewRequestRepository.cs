using Microsoft.EntityFrameworkCore;
using SkillAssessor.Common.EfCore.UnitOfWork;
using SkillAssessor.Common.Exceptions.Data;
using SkillAssessor.EmployeeService.Data.Repositories.Interfaces;
using SkillAssessor.EmployeeService.Entity.InterviewRequests;

namespace SkillAssessor.EmployeeService.Data.Repositories;

public class InterviewRequestRepository : Repository<InterviewRequest>, IInterviewRequestRepository
{
    public InterviewRequestRepository(EmployeeDbContext dbContext) : base(dbContext) { }

    
    public async Task<InterviewRequest> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var interviewRequest = await Data
            .AsNoTracking()
            .FirstOrDefaultAsync(ir => ir.Id == id, cancellationToken: cancellationToken);

        if (interviewRequest is null)
        {
            throw new ItemDoNotFoundException();
        }

        return interviewRequest;
    }
}
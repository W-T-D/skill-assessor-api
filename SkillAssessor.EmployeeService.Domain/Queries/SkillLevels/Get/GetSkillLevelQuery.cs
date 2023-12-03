using MediatR;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;

namespace SkillAssessor.EmployeeService.Domain.Queries.SkillLevels.Get;

public record GetSkillLevelQuery() : IRequest<IQueryable<SkillLevelDto>>;
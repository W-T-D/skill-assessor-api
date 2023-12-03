using AutoMapper;
using MediatR;
using SkillAssessor.EmployeeService.Data.Interfaces;
using SkillAssessor.EmployeeService.DomainModels.SkillLevel;

namespace SkillAssessor.EmployeeService.Domain.Queries.SkillLevels.Get;

public class GetSkillLevelQueryHandler : IRequestHandler<GetSkillLevelQuery, IQueryable<SkillLevelDto>>
{
    private readonly IEmployeeUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    
    public GetSkillLevelQueryHandler(IEmployeeUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    
    public Task<IQueryable<SkillLevelDto>> Handle(GetSkillLevelQuery request, CancellationToken cancellationToken)
    {
        var skillLevels = _unitOfWork.SkillLevels.GetAll();
        var skillLevelsDto = _mapper.ProjectTo<SkillLevelDto>(skillLevels);

        return Task.FromResult(skillLevelsDto);
    }
}
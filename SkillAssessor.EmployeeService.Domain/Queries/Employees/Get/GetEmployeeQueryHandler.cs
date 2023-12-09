using AutoMapper;
using MediatR;
using SkillAssessor.EmployeeService.Data.Interfaces;
using SkillAssessor.EmployeeService.DomainModels.Employee;

namespace SkillAssessor.EmployeeService.Domain.Queries.Employees.Get;

public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, IQueryable<EmployeeDto>>
{
    private readonly IEmployeeUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    
    public GetEmployeeQueryHandler(IEmployeeUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public Task<IQueryable<EmployeeDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employees = _unitOfWork.Employees.GetAll();
        var employeesDto = _mapper.ProjectTo<EmployeeDto>(employees);

        return Task.FromResult(employeesDto);
    }
}
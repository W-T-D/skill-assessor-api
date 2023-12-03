using AutoMapper;
using MediatR;
using SkillAssessor.EmployeeService.Data.Interfaces;
using SkillAssessor.EmployeeService.DomainModels.Employee;
using SkillAssessor.EmployeeService.Entity.Employees;

namespace SkillAssessor.EmployeeService.Domain.Commands.Employees.Add;

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, EmployeeDto>
{
    private readonly IEmployeeUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;

    
    public AddEmployeeCommandHandler(IEmployeeUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<EmployeeDto> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<Employee>(request);
        await _unitOfWork.Employees.CreateAsync(employee, cancellationToken);
        var employeeDto = _mapper.Map<EmployeeDto>(employee);

        return employeeDto;
    }
}
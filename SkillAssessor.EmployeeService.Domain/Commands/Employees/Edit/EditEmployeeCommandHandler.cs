using AutoMapper;
using MediatR;
using SkillAssessor.EmployeeService.Data.Interfaces;
using SkillAssessor.EmployeeService.DomainModels.Employee;
using SkillAssessor.EmployeeService.Entity.Employees;

namespace SkillAssessor.EmployeeService.Domain.Commands.Employees.Edit;

public class EditEmployeeCommandHandler : IRequestHandler<EditEmployeeCommand, EmployeeDto>
{
    private readonly IEmployeeUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;


    public EditEmployeeCommandHandler(IMapper mapper, IEmployeeUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task<EmployeeDto> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<Employee>(request);
        await _unitOfWork.Employees.UpdateAsync(employee, cancellationToken);
        var employeeDto = _mapper.Map<EmployeeDto>(employee);

        return employeeDto;
    }
}
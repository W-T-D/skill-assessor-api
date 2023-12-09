using AutoMapper;
using MediatR;
using SkillAssessor.Common.Exceptions.Data;
using SkillAssessor.EmployeeService.Data.Interfaces;
using SkillAssessor.EmployeeService.DomainModels.Employee;

namespace SkillAssessor.EmployeeService.Domain.Commands.Employees.Delete;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, EmployeeDto>
{
    private readonly IEmployeeUnitOfWork _unitOfWork;

    private readonly IMapper _mapper;


    public DeleteEmployeeCommandHandler(IMapper mapper, IEmployeeUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task<EmployeeDto> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _unitOfWork.Employees.GetByIdAsync(request.Id, cancellationToken);

        if (employee is null)
        {
            throw new ItemDoNotFoundException();
        }

        await _unitOfWork.Employees.DeleteAsync(employee, cancellationToken);
        var employeeDto = _mapper.Map<EmployeeDto>(employee);

        return employeeDto;
    }
}
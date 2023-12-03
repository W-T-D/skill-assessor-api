using MediatR;
using SkillAssessor.EmployeeService.Domain.Commands.Employees.Add;
using SkillAssessor.EmployeeService.Domain.Commands.Employees.Delete;
using SkillAssessor.EmployeeService.Domain.Commands.Employees.Edit;
using SkillAssessor.EmployeeService.DomainModels.Employee;

namespace SkillAssessor.EmployeeService.Api.Mutations;

[ExtendObjectType(Name = "Mutation")]
public sealed class EmployeeMutations
{
    public async Task<EmployeeDto> AddEmployee([Service] IMediator mediator, AddEmployeeCommand command)
    {
        var employee = await mediator.Send(command);

        return employee;
    }
    
    public async Task<EmployeeDto> EditEmployee([Service] IMediator mediator, EditEmployeeCommand command)
    {
        var employee = await mediator.Send(command);

        return employee;
    }
    
    public async Task<EmployeeDto> DeleteEmployee([Service] IMediator mediator, DeleteEmployeeCommand command)
    {
        var employee = await mediator.Send(command);

        return employee;
    }
}
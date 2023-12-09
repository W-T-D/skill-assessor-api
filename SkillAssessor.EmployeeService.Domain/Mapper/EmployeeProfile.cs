using AutoMapper;
using SkillAssessor.EmployeeService.Domain.Commands.Employees.Add;
using SkillAssessor.EmployeeService.DomainModels.Employee;
using SkillAssessor.EmployeeService.Entity.Employees;

namespace SkillAssessor.EmployeeService.Domain.Mapper;

public sealed class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<AddEmployeeCommand, Employee>();
        CreateProjection<Employee, EmployeeDto>();
    }
}
using SkillAssessor.EmployeeService.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDataLayerServices(configuration);
builder.Services.AddGraphQl();

var app = builder.Build();

app.MapGraphQL();

app.Run();
using SkillAssessor.EmployeeService.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDataLayerServices(configuration);
builder.Services.AddGraphQl();
builder.Services.AddMediatr();

var app = builder.Build();

await app.Services.CreateDbIfNotExists();

app.MapGraphQL();

app.Run();
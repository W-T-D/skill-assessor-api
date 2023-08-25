using SkillAssessor.AssessmentService.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAWSServices(builder.Configuration);
builder.Services.AddGraphQl();
builder.Services.AddDataLayerServices();

var app = builder.Build();

app.MapGraphQL();

app.Run();
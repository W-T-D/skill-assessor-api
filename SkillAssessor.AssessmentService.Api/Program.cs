using SkillAssessor.AssessmentService.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAWSServices(builder.Configuration);
builder.Services.AddGraphQl();
builder.Services.AddDataLayerServices();
builder.Services.AddMapper();
builder.Services.AddMediatr();

var app = builder.Build();

app.MapGraphQL();

app.Run();
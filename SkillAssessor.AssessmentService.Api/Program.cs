using SkillAssessor.AssessmentService.Api.Extensions;
using SkillAssessor.Common.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddAWSServices(builder.Configuration);
builder.Services.AddGraphQl();
builder.Services.AddDataLayerServices();
builder.Services.AddMapper();
builder.Services.AddMediatr();
builder.Services.AddKafka();
builder.Services.AddSerilog();

var app = builder.Build();

app.MapGraphQL();

app.Run();
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SkillAssessor.AssessmentService.Api/SkillAssessor.AssessmentService.Api.csproj", "SkillAssessor.AssessmentService.Api/"]
COPY ["SkillAssessor.AssessmentService.Data/SkillAssessor.AssessmentService.Data.csproj", "SkillAssessor.AssessmentService.Data/"]
COPY ["SkillAssessor.AssessmentService.Entity/SkillAssessor.AssessmentService.Entity.csproj", "SkillAssessor.AssessmentService.Entity/"]
COPY ["SkillAssessor.Common.Exceptions/SkillAssessor.Common.Exceptions.csproj", "SkillAssessor.Common.Exceptions/"]
COPY ["SkillAssessor.Common.Models/SkillAssessor.Common.Models.csproj", "SkillAssessor.Common.Models/"]
COPY ["SkillAssessor.AssessmentService.Domain/SkillAssessor.AssessmentService.Domain.csproj", "SkillAssessor.AssessmentService.Domain/"]
COPY ["SkillAssessor.AssessmentService.DomainModels/SkillAssessor.AssessmentService.DomainModels.csproj", "SkillAssessor.AssessmentService.DomainModels/"]
COPY ["SkillAssessor.Common.Logging/SkillAssessor.Common.Logging.csproj", "SkillAssessor.Common.Logging/"]
RUN dotnet restore "SkillAssessor.AssessmentService.Api/SkillAssessor.AssessmentService.Api.csproj"
COPY . .
WORKDIR "/src/SkillAssessor.AssessmentService.Api"
RUN dotnet build "SkillAssessor.AssessmentService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkillAssessor.AssessmentService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkillAssessor.AssessmentService.Api.dll"]

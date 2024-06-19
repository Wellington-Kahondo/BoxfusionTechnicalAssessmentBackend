FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/Boxfusion.TechnicalAssessment.Web.Host/Boxfusion.TechnicalAssessment.Web.Host.csproj", "src/Boxfusion.TechnicalAssessment.Web.Host/"]
COPY ["src/Boxfusion.TechnicalAssessment.Web.Core/Boxfusion.TechnicalAssessment.Web.Core.csproj", "src/Boxfusion.TechnicalAssessment.Web.Core/"]
COPY ["src/Boxfusion.TechnicalAssessment.Application/Boxfusion.TechnicalAssessment.Application.csproj", "src/Boxfusion.TechnicalAssessment.Application/"]
COPY ["src/Boxfusion.TechnicalAssessment.Core/Boxfusion.TechnicalAssessment.Core.csproj", "src/Boxfusion.TechnicalAssessment.Core/"]
COPY ["src/Boxfusion.TechnicalAssessment.EntityFrameworkCore/Boxfusion.TechnicalAssessment.EntityFrameworkCore.csproj", "src/Boxfusion.TechnicalAssessment.EntityFrameworkCore/"]
WORKDIR "/src/src/Boxfusion.TechnicalAssessment.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/Boxfusion.TechnicalAssessment.Web.Host", "src/Boxfusion.TechnicalAssessment.Web.Host"]
COPY ["src/Boxfusion.TechnicalAssessment.Web.Core", "src/Boxfusion.TechnicalAssessment.Web.Core"]
COPY ["src/Boxfusion.TechnicalAssessment.Application", "src/Boxfusion.TechnicalAssessment.Application"]
COPY ["src/Boxfusion.TechnicalAssessment.Core", "src/Boxfusion.TechnicalAssessment.Core"]
COPY ["src/Boxfusion.TechnicalAssessment.EntityFrameworkCore", "src/Boxfusion.TechnicalAssessment.EntityFrameworkCore"]
WORKDIR "/src/src/Boxfusion.TechnicalAssessment.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Boxfusion.TechnicalAssessment.Web.Host.dll"]

using System.Threading.Tasks;
using Boxfusion.TechnicalAssessment.Configuration.Dto;

namespace Boxfusion.TechnicalAssessment.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

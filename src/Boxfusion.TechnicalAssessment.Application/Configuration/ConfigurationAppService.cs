using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Boxfusion.TechnicalAssessment.Configuration.Dto;

namespace Boxfusion.TechnicalAssessment.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : TechnicalAssessmentAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

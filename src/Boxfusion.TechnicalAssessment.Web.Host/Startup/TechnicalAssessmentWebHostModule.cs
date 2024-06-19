using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Boxfusion.TechnicalAssessment.Configuration;

namespace Boxfusion.TechnicalAssessment.Web.Host.Startup
{
    [DependsOn(
       typeof(TechnicalAssessmentWebCoreModule))]
    public class TechnicalAssessmentWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public TechnicalAssessmentWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TechnicalAssessmentWebHostModule).GetAssembly());
        }
    }
}

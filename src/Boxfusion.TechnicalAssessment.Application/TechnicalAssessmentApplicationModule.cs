using Abp.AutoMapper;
using Abp.FluentValidation;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Boxfusion.TechnicalAssessment.Authorization;

namespace Boxfusion.TechnicalAssessment
{
    [DependsOn(
        typeof(TechnicalAssessmentCoreModule), 
        typeof(AbpAutoMapperModule),
        typeof(AbpFluentValidationModule))]
    public class TechnicalAssessmentApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TechnicalAssessmentAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TechnicalAssessmentApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}

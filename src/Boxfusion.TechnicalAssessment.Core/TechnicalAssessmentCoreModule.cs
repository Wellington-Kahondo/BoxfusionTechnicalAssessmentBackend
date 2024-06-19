using Abp.FluentValidation;
using Abp.Localization;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Security;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using Boxfusion.TechnicalAssessment.Authorization.Roles;
using Boxfusion.TechnicalAssessment.Authorization.Users;
using Boxfusion.TechnicalAssessment.Configuration;
using Boxfusion.TechnicalAssessment.Localization;
using Boxfusion.TechnicalAssessment.MultiTenancy;
using Boxfusion.TechnicalAssessment.Timing;

namespace Boxfusion.TechnicalAssessment
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    [DependsOn(typeof(AbpFluentValidationModule))]
    public class TechnicalAssessmentCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            TechnicalAssessmentLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = TechnicalAssessmentConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            
            Configuration.Localization.Languages.Add(new LanguageInfo("fa", "فارسی", "famfamfam-flags ir"));
            
            Configuration.Settings.SettingEncryptionConfiguration.DefaultPassPhrase = TechnicalAssessmentConsts.DefaultPassPhrase;
            SimpleStringCipher.DefaultPassPhrase = TechnicalAssessmentConsts.DefaultPassPhrase;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TechnicalAssessmentCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}

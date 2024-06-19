using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Boxfusion.TechnicalAssessment.Configuration;
using Boxfusion.TechnicalAssessment.EntityFrameworkCore;
using Boxfusion.TechnicalAssessment.Migrator.DependencyInjection;

namespace Boxfusion.TechnicalAssessment.Migrator
{
    [DependsOn(typeof(TechnicalAssessmentEntityFrameworkModule))]
    public class TechnicalAssessmentMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public TechnicalAssessmentMigratorModule(TechnicalAssessmentEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(TechnicalAssessmentMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                TechnicalAssessmentConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TechnicalAssessmentMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}

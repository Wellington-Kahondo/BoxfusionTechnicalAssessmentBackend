using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Boxfusion.TechnicalAssessment.EntityFrameworkCore.Seed;

namespace Boxfusion.TechnicalAssessment.EntityFrameworkCore
{
    [DependsOn(
        typeof(TechnicalAssessmentCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class TechnicalAssessmentEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<TechnicalAssessmentDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        TechnicalAssessmentDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        TechnicalAssessmentDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TechnicalAssessmentEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}

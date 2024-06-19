using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Boxfusion.TechnicalAssessment.EntityFrameworkCore;
using Boxfusion.TechnicalAssessment.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Boxfusion.TechnicalAssessment.Web.Tests
{
    [DependsOn(
        typeof(TechnicalAssessmentWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class TechnicalAssessmentWebTestModule : AbpModule
    {
        public TechnicalAssessmentWebTestModule(TechnicalAssessmentEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TechnicalAssessmentWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(TechnicalAssessmentWebMvcModule).Assembly);
        }
    }
}
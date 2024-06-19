using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Boxfusion.TechnicalAssessment.Authorization;
using Boxfusion.TechnicalAssessment.Authorization.Roles;
using Boxfusion.TechnicalAssessment.Authorization.Users;
using Boxfusion.TechnicalAssessment.Editions;
using Boxfusion.TechnicalAssessment.MultiTenancy;

namespace Boxfusion.TechnicalAssessment.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>()
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpLogInManager<LogInManager>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}

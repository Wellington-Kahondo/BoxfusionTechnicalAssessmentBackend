using Abp.MultiTenancy;
using Boxfusion.TechnicalAssessment.Authorization.Users;

namespace Boxfusion.TechnicalAssessment.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}

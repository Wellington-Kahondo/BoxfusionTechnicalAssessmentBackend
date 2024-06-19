using Abp.Authorization;
using Boxfusion.TechnicalAssessment.Authorization.Roles;
using Boxfusion.TechnicalAssessment.Authorization.Users;

namespace Boxfusion.TechnicalAssessment.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

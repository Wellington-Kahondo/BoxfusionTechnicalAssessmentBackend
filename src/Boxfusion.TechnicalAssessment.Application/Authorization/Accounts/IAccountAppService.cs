using System.Threading.Tasks;
using Abp.Application.Services;
using Boxfusion.TechnicalAssessment.Authorization.Accounts.Dto;

namespace Boxfusion.TechnicalAssessment.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

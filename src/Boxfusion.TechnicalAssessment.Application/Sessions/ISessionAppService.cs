using System.Threading.Tasks;
using Abp.Application.Services;
using Boxfusion.TechnicalAssessment.Sessions.Dto;

namespace Boxfusion.TechnicalAssessment.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

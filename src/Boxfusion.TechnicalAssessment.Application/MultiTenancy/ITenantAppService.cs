using Abp.Application.Services;
using Boxfusion.TechnicalAssessment.MultiTenancy.Dto;

namespace Boxfusion.TechnicalAssessment.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


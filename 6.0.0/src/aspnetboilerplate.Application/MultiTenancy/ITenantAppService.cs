using Abp.Application.Services;
using Abp.Application.Services.Dto;
using aspnetboilerplate.MultiTenancy.Dto;

namespace aspnetboilerplate.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

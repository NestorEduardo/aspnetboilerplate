using System.Threading.Tasks;
using Abp.Application.Services;
using aspnetboilerplate.Authorization.Accounts.Dto;

namespace aspnetboilerplate.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

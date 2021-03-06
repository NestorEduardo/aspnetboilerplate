using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using aspnetboilerplate.Roles.Dto;

namespace aspnetboilerplate.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}

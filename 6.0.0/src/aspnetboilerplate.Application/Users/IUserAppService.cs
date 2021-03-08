using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using aspnetboilerplate.Roles.Dto;
using aspnetboilerplate.Users.Dto;

namespace aspnetboilerplate.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}
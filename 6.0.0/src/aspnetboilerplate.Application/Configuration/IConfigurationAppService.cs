using System.Threading.Tasks;
using Abp.Application.Services;
using aspnetboilerplate.Configuration.Dto;

namespace aspnetboilerplate.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using aspnetboilerplate.Configuration.Dto;

namespace aspnetboilerplate.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : aspnetboilerplateAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

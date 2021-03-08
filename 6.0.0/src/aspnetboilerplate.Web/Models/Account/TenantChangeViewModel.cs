using Abp.AutoMapper;
using aspnetboilerplate.Sessions.Dto;

namespace aspnetboilerplate.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
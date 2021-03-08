using Abp.Web.Mvc.Views;

namespace aspnetboilerplate.Web.Views
{
    public abstract class aspnetboilerplateWebViewPageBase : aspnetboilerplateWebViewPageBase<dynamic>
    {

    }

    public abstract class aspnetboilerplateWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected aspnetboilerplateWebViewPageBase()
        {
            LocalizationSourceName = aspnetboilerplateConsts.LocalizationSourceName;
        }
    }
}
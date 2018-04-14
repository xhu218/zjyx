using Abp.AspNetCore.Mvc.ViewComponents;

namespace MyCreek.Web.Views
{
    public abstract class MyCreekViewComponent : AbpViewComponent
    {
        protected MyCreekViewComponent()
        {
            LocalizationSourceName = MyCreekConsts.LocalizationSourceName;
        }
    }
}

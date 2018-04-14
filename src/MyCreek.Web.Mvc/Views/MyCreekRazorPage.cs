using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace MyCreek.Web.Views
{
    public abstract class MyCreekRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MyCreekRazorPage()
        {
            LocalizationSourceName = MyCreekConsts.LocalizationSourceName;
        }
    }
}

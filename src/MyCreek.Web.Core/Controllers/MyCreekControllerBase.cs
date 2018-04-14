using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyCreek.Controllers
{
    public abstract class MyCreekControllerBase: AbpController
    {
        protected MyCreekControllerBase()
        {
            LocalizationSourceName = MyCreekConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

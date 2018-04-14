using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyCreek.Controllers;

namespace MyCreek.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MyCreekControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}

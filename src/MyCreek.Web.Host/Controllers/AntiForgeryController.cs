using Microsoft.AspNetCore.Antiforgery;
using MyCreek.Controllers;

namespace MyCreek.Web.Host.Controllers
{
    public class AntiForgeryController : MyCreekControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}

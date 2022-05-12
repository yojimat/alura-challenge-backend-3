using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alura_Challenge_Backend_3.Controllers
{
    [Route("error")]
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        [Route("404")]
        public IActionResult PageNotFound()
        {
            if (!HttpContext.Items.ContainsKey("originalPath")) return RedirectToAction("Index", "Home");
            return View();
        }
    }
}

using Alura_Challenge_Backend_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.WebUtilities;
using Alura_Challenge_Backend_3.Helpers;

namespace Alura_Challenge_Backend_3.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route(nameof(UploadFile))]
        public IActionResult UploadFile(FileUpload fileUpload)
        {
            if (ModelState.IsValid)
            {
                fileUpload.ReadFileNameAndLength();
                fileUpload.ReadCSVFile();
            }

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
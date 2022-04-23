using Alura_Challenge_Backend_3.Contexts;
using Alura_Challenge_Backend_3.Data;
using Alura_Challenge_Backend_3.Data.Interfaces;
using Alura_Challenge_Backend_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Alura_Challenge_Backend_3.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransactionService _transactionService;

        public HomeController(ILogger<HomeController> logger, TransactionContext context)
        {
            _logger = logger;
            _transactionService = new TransactionService(context, logger);
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
                var transactionsList = fileUpload.ReadCSVFile();
                // transactionsList = TransactionsValidation.Validate(transactionsList, fileUpload);
                int savedItems = _transactionService.SaveTransactions(transactionsList);
                fileUpload.SetResultMessage(savedItems, transactionsList.Count());
            }

            return View(nameof(Index), fileUpload);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
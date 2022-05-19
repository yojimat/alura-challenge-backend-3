using Alura_Challenge_Backend_3.Contexts;
using Alura_Challenge_Backend_3.CustomExceptions;
using Alura_Challenge_Backend_3.Data;
using Alura_Challenge_Backend_3.Data.Interfaces;
using Alura_Challenge_Backend_3.Helpers;
using Alura_Challenge_Backend_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Alura_Challenge_Backend_3.Controllers;

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
        FileUploadViewModel fileUpload = new();
        var listOfTransactions = _transactionService.GetTransactions();
        fileUpload.SetListForImportedTransactionTables(listOfTransactions);
        return View(nameof(Index), fileUpload);
    }

    [HttpPost, Route(nameof(UploadFile))]
    public IActionResult UploadFile(FileUploadViewModel fileUpload)
    {
        if (ModelState.IsValid)
        {
            fileUpload.ReadFileNameAndLength();
            var transactionsList = fileUpload.ReadCSVFile();
            int originalListLength = transactionsList.Count();

            try
            {
                var transactionsValidation = new TransactionsValidation(_transactionService);
                var validatedTransactions = transactionsValidation.Validate(transactionsList);

                int savedItems = _transactionService.SaveTransactions(validatedTransactions);
                fileUpload.SetResultMessage(savedItems, originalListLength);
            }
            catch (TransactionsListAlreadyExistsException)
            {
                fileUpload.SetResultMessage("As transações desse dia já foram inseridas.");
            }
        }

        var listOfTransactions = _transactionService.GetTransactions();
        fileUpload.SetListForImportedTransactionTables(listOfTransactions);

        return View(nameof(Index), fileUpload);
    }

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

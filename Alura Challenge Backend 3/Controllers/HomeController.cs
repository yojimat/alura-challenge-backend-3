using Alura_Challenge_Backend_3.Contexts;
using Alura_Challenge_Backend_3.CustomExceptions;
using Alura_Challenge_Backend_3.Data;
using Alura_Challenge_Backend_3.Data.Interfaces;
using Alura_Challenge_Backend_3.Helpers;
using Alura_Challenge_Backend_3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Alura_Challenge_Backend_3.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ITransactionService _transactionService;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(ILogger<HomeController> logger, TransactionContext context, UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _transactionService = new TransactionService(context, logger);
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        FileUploadViewModel fileUpload = new();
        SetFileUploadForTransactionTable(fileUpload);
        return View(nameof(Index), fileUpload);
    }

    [HttpPost, Route(nameof(UploadFile))]
    public async Task<IActionResult> UploadFile(FileUploadViewModel fileUpload)
    {
        if (ModelState.IsValid)
        {
            fileUpload.ReadFileNameAndLength();
            var transactionsList = fileUpload.ReadCSVFile();
            int originalListLength = transactionsList.Count();
            ApplicationUser loggedUser = await _userManager.GetUserAsync(User);

            try
            {
                var transactionsValidation = new TransactionsValidation(_transactionService);
                var validatedTransactions = transactionsValidation.Validate(transactionsList);

                Transaction.InsertUserId(validatedTransactions, loggedUser.RegisterId);

                int savedItems = _transactionService.SaveTransactions(validatedTransactions);
                fileUpload.SetResultMessage(savedItems, originalListLength);
            }
            catch (TransactionsListAlreadyExistsException)
            {
                fileUpload.SetResultMessage("As transações desse dia já foram inseridas.");
            }
        }

        SetFileUploadForTransactionTable(fileUpload);
        return View(nameof(Index), fileUpload);
    }

    private void SetFileUploadForTransactionTable(FileUploadViewModel fileUpload)
    {
        var listOfTransactions = _transactionService.GetTransactions();
        var listOfUsers = _userManager.Users.ToArray();
        fileUpload.SetListForImportedTransactionTables(listOfTransactions);
        fileUpload.SetListOfUsersNames(listOfUsers);
    }

    [AllowAnonymous]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

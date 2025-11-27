using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;
using myFirstMVC.Models;
using Services;
namespace myFirstMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly LatinService _latinService;
    private readonly QuoteService _quoteService;

    public HomeController(ILogger<HomeController> logger, LatinService latinService, QuoteService quoteService)
    {
        _logger = logger;
        _latinService = latinService;
        _quoteService = quoteService;
    }

    [HttpGet]
    public IActionResult Index()
    {   
        var vm = new IndexViewModel();
        vm.Sentences = _latinService.ReadSentences(0, 10, null);
        return View(vm);
    }
    [HttpGet]
    public IActionResult Page1()
    {
        var qvm = new QuoteViewModel();
        qvm.Quotes = _quoteService.ReadQuotes(0,10,null);
        return View(qvm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace myFirstRazorPage.Pages;

public class QuotesModel : PageModel
{
    private readonly ILogger<QuotesModel> _logger;
    private readonly QuoteService _quoteservice;
    public List<FamousQuote>? famousQuotes {get;set;}

    public QuotesModel(ILogger<QuotesModel> logger, QuoteService quoteService)
    {
        _logger = logger;
        _quoteservice = quoteService;
    }

    public void OnGet()
    {
        famousQuotes = _quoteservice.ReadQuotes(0, 100, "Michael");
    }
}


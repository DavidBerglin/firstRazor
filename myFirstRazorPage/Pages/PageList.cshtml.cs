using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace myFirstRazorPage.Pages;

public class QuotesList : PageModel
{
    private readonly ILogger<QuotesList> _logger;
    private readonly IQuoteService _quoteservice;
    public List<FamousQuote>? famousQuotes {get;set;}
    public string? SearchFilter {get;set;}

    public QuotesList(ILogger<QuotesList> logger, IQuoteService quoteService)
    {
        _logger = logger;
        _quoteservice = quoteService;
    }

    public void OnGet(string? searchFilter = null)
    {
        SearchFilter = searchFilter;
        famousQuotes = _quoteservice.ReadQuotes(0, 100, searchFilter);
    } 
 
}


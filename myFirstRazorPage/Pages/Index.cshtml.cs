using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace myFirstRazorPage.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly LatinService _latinService;

    public List<LatinSentence> Latintext {get;set;}

    public IndexModel(ILogger<IndexModel> logger, LatinService latinService)
    {
        _logger = logger;
        _latinService = latinService;
    }

    public void OnGet()
    {
        Latintext = _latinService.ReadSentences(0, 10, null);
    }
}

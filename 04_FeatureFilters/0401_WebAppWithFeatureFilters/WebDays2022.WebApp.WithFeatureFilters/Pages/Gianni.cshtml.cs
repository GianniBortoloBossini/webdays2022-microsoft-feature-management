using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebDays2022.WebApp.WithFeatureFilters.Pages;

public class GianniModel : PageModel
{
    private readonly ILogger<GianniModel> _logger;

    public GianniModel(ILogger<GianniModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}


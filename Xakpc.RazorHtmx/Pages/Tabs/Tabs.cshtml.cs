using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Xakpc.RazorHtmx.Pages.Tabs;

public class TabsModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnGetTab1()
    {
        return Partial("_Tab1Partial");
    }

    public IActionResult OnGetTab2()
    {
        return Partial("_Tab2Partial");
    }

    public IActionResult OnGetTab3()
    {
        return Partial("_Tab3Partial");
    }
}
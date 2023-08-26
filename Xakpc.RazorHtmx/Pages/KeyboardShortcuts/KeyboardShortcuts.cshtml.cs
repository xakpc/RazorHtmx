using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Xakpc.RazorHtmx.Pages.KeyboardShortcuts;

public class KeyboardShortcutsModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnGetDoIt1()
    {
        return Content("Did it");
    }

    public IActionResult OnGetDoIt2()
    {
        return Content("Did it");
    }
}
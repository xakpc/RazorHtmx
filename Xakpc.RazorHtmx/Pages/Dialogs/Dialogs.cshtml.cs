using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Xakpc.RazorHtmx.Pages.Dialogs;

public class DialogsModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnPost(string response)
    {
        return Content($"<p>User entered <i>{response}</i></p>", "text/html");
    }
}
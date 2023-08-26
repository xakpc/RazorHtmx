using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Xakpc.RazorHtmx.Pages.DialogsHtml;

public class DialogsHtmlModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnGetModal()
    {
        return Partial("_ModalPartial", ("Model Content Header", """
                Nunc nec ligula a tortor sollicitudin dictum in vel enim.
                Quisque facilisis turpis vel eros dictum aliquam et nec turpis.
                Sed eleifend a dui nec ullamcorper.
                Praesent vehicula lacus ac justo accumsan ullamcorper.
                """));
    }
}
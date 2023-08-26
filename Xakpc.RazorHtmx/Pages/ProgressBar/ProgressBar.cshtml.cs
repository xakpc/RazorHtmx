using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Xakpc.RazorHtmx.Pages.ProgressBar;

public class ProgressBarModel : PageModel
{
    private static int _progress;

    public void OnGet()
    {
    }

    public IActionResult OnPostStart()
    {
        _progress = 0;
        return Partial("_ProgressPartial", new Progress(0, false));
    }

    public IActionResult OnGetProgress()
    {
        _progress += 20;

        if (_progress > 100)
        {
            _progress = 100;
            Response.Headers.Add("HX-Trigger", "done");
            return Partial("_ProgressPartial", new Progress(_progress, true));
        }

        return Partial("_ProgressBarPartial", _progress);
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Xakpc.RazorHtmx.Pages.LazyLoad;

public class LazyLoadModel : PageModel
{
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnGetGraphAsync()
    {
        await Task.Delay(1000);

        return Partial("_Image");
    }
}
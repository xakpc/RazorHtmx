using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xakpc.RazorHtmx.Data;

namespace Xakpc.RazorHtmx.Pages.ClickToLoad;

public class ClickToLoadModel : PageModel
{
    private const int PageSize = 5;
    public PagedTableViewModel UsersTable { get; set; }

    public void OnGet()
    {
        UsersTable = new PagedTableViewModel(TestData.Users.Take(PageSize).ToList(), 0);
    }

    public async Task<IActionResult> OnGetPageAsync(int page)
    {
        await Task.Delay(1000);

        var data = TestData.Users.GetRange(page * PageSize, PageSize);
        UsersTable = new PagedTableViewModel(data, page);

        return Partial("_TableBody", UsersTable);
    }
}
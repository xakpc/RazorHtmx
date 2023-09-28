using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xakpc.RazorHtmx.Data;
using Xakpc.RazorHtmx.Pages.ClickToLoad;

namespace Xakpc.RazorHtmx.Pages.InfiniteScroll;

public class InfiniteScrollModel : PageModel
{
    private const int PageSize = 10;
    public PagedTableViewModel UsersTable { get; set; }

    public void OnGet()
    {
        UsersTable = new PagedTableViewModel(TestData.Users.Take(PageSize).ToList(), 0);
    }

    public async Task<IActionResult> OnGetPageAsync(int pageNumber)
    {
        await Task.Delay(1000);

        int index = pageNumber * PageSize;
        if (index >= TestData.Users.Count)
        {
            return new NoContentResult();
        }

        var data = TestData.Users.GetRange(index, PageSize);
        UsersTable = new PagedTableViewModel(data, pageNumber);

        return Partial("_TableBody", UsersTable);
    }
}
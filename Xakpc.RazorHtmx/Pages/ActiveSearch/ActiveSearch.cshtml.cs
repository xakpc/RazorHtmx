using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xakpc.RazorHtmx.Data;

namespace Xakpc.RazorHtmx.Pages.ActiveSearch;

public class ActiveSearchModel : PageModel
{
    public void OnGet()
    {
    }

    public IActionResult OnPostSearch(string search)
    {
        if (search == null || string.IsNullOrEmpty(search))
        {
            return Partial("_TableBody", new List<UserInfoViewModel>());
        }

        var users = TestData.Users.Where(u => u.Email.Contains(search.ToLowerInvariant())).ToList();

        if (users.Any())
        {
            return Partial("_TableBody", users);
        }

        return Partial("_TableBody", TestData.Users.Take(7).ToList());
    }

    public record SearchRequest(string Search);
}
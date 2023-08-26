using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xakpc.RazorHtmx.Data;

namespace Xakpc.RazorHtmx.Pages.EditRow;

public class EditRowModel : PageModel
{
    public List<UserInfoViewModel> Users { get; set; }

    public void OnGet()
    {
        Users = TestData.Users;
    }

    public IActionResult OnGetItem(int id)
    {
        var item = TestData.Users.First(x => x.Id == id);

        return Partial("_TableRow", item);
    }

    public IActionResult OnGetEditItem(int id)
    {
        var item = TestData.Users.First(x => x.Id == id);

        return Partial("_TableRowForm", item);
    }

    public IActionResult OnPutItem(UserInfoViewModel user)
    {
        var item = TestData.Users.First(x => x.Id == user.Id);
        item.FirstName = user.FirstName;
        item.Email = user.Email;

        return Partial("_TableRow", item);
    }
}
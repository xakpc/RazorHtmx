using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xakpc.RazorHtmx.Data;

namespace Xakpc.RazorHtmx.Pages.DeleteRow;

public class DeleteRowModel : PageModel
{
    public List<UserInfoViewModel> Users { get; set; }

    public void OnGet()
    {
        Users = TestData.Users;
    }

    public IActionResult OnDeleteItem(int id)
    {
        TestData.Users.RemoveAll(x => x.Id == id);

        return new OkResult();
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xakpc.RazorHtmx.Data;

namespace Xakpc.RazorHtmx.Pages.BulkUpdate;

public class BulkUpdateModel : PageModel
{
    public UsersTableViewModel TableUsers { get; set; }

    /// <summary>
    /// Initial Get
    /// </summary>
    public void OnGet()
    {
        TableUsers = new UsersTableViewModel(TestData.Users);
    }

    /// <summary>
    /// Deactivate ids
    /// </summary>
    public IActionResult OnPutDeactivate(IEnumerable<int> ids)
    {
        TableUsers = new UsersTableViewModel(TestData.Users);
        foreach (var id in ids)
        {
            TableUsers.Users.First(u => u.Id == id).Status = "Inactive";
            TableUsers.UsersWasActivated[id] = false;
        }

        return Partial("_TableBody", TableUsers);
    }

    /// <summary>
    /// Activate ids
    /// </summary>
    public IActionResult OnPutActivate(IEnumerable<int> ids)
    {
        TableUsers = new UsersTableViewModel(TestData.Users);
        foreach (var id in ids)
        {
            TableUsers.Users.First(u => u.Id == id).Status = "Active";
            TableUsers.UsersWasActivated[id] = true;
        }

        return Partial("_TableBody", TableUsers);
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xakpc.RazorHtmx.Data;

namespace Xakpc.RazorHtmx.Pages.InlineValidation;

public class InlineValidationModel : PageModel
{
    [BindProperty] public UserInfoViewModel UserInfo { get; set; } = new();

    public void OnGet()
    {
    }

    public IActionResult OnPost(UserInfoViewModel user)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> OnPostEmail(UserInfoViewModel user)
    {
        await Task.Delay(1000);

        if (user.Email != "test@test.com")
        {
            ModelState.AddModelError(nameof(UserInfoViewModel.Email),
                "That email is already taken.  Please enter another email.");
        }

        return Partial("_EmailPartial", user);
    }
}
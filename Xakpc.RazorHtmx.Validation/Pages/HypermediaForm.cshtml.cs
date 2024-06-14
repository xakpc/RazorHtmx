using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Xakpc.RazorHtmx.Validation.Pages;

public class HypermediaFormModel : PageModel
{

    [BindProperty]
    public UserRegistrationForm UserRegistration { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (UserRegistration.PhoneNumber.Length < 4)
        {
            ModelState.AddModelError("PhoneNumber", "Phone format is wrong");
        }

        if (!ModelState.IsValid)
        {
            Response.StatusCode = 422;
            return Partial("_FormContent", UserRegistration);
        }

        // no need to use temp data to pass user object to another page
        return Partial("_SuccessUser", UserRegistration);
    }
}

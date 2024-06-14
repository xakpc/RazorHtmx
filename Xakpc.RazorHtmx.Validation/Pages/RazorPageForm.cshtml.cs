using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Xakpc.RazorHtmx.Validation.Pages
{
    public class RazorPageFormModel : PageModel
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
                return Page();
            }

            // Store the user data in TempData
            TempData["UserRegistration"] = JsonSerializer.Serialize(UserRegistration);
            return RedirectToPage("Success");
        }
    }
}

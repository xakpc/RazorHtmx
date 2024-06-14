using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Xakpc.RazorHtmx.Validation.Pages
{
    public class SuccessModel : PageModel
    {
        public UserRegistrationForm UserRegistration { get; set; }

        public void OnGet()
        {
            var userJson = TempData["UserRegistration"] as string;
            if (!string.IsNullOrEmpty(userJson))
            {
                UserRegistration = JsonSerializer.Deserialize<UserRegistrationForm>(userJson);
            }
        }
    }
}

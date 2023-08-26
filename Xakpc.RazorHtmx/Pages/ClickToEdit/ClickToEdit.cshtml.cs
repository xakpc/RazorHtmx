using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Xakpc.RazorHtmx.Data;

namespace Xakpc.RazorHtmx.Pages.ClickToEdit;

//[IgnoreAntiforgeryToken(Order = 1001)]
public class ClickToEditModel : PageModel
{
    private readonly IAntiforgery _antiforgery;

    public ClickToEditModel(IAntiforgery antiforgery)
    {
        _antiforgery = antiforgery;
    }

    public string? Token { get; set; }

    public UserInfoViewModel UserInfoViewModel { get; set; }

    public void OnGet()
    {
        UserInfoViewModel = GetUserInfo(1);
    }

    public IActionResult OnGetPartial(int id)
    {
        UserInfoViewModel = GetUserInfo(id);
        return Partial("_Partial", UserInfoViewModel);
    }

    public IActionResult OnGetEdit(int id)
    {
        UserInfoViewModel = GetUserInfo(id);
        UserInfoViewModel.AntiforgeryToken = _antiforgery.GetAndStoreTokens(HttpContext).RequestToken;
        return Partial("_Edit", UserInfoViewModel);
    }

    public IActionResult OnPutEdit(UserInfoViewModel userInfoViewModel)
    {
        UserInfoViewModel = userInfoViewModel;
        return Partial("_Partial", UserInfoViewModel);
    }

    private UserInfoViewModel GetUserInfo(int id)
    {
        return TestData.Users[0];
    }
}
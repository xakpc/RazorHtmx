using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Xakpc.RazorHtmx.Pages.Animations;

[IgnoreAntiforgeryToken(Order = 1001)]
public class AnimationsModel : PageModel
{
    private List<ValueTuple<string, string>> _pairs = new()
    {
        new ValueTuple<string, string>("Initial Content", "Swap It"),
        new ValueTuple<string, string>("First Data", "Change This"),
        new ValueTuple<string, string>("Original Entry", "Modify Here"),
        new ValueTuple<string, string>("Basic Text", "Switch Out"),
        new ValueTuple<string, string>("Primary Info", "Replace Now"),
        new ValueTuple<string, string>("Start Value", "Update That")
    };

    public void OnGet()
    {
    }

    public IActionResult OnGetColors()
    {
        // create list of colors and get a random color from it
        var colors = new[] { "red", "green", "blue", "yellow", "orange", "purple" };
        var random = new Random();
        var color = colors[random.Next(colors.Length)];

        return Partial("_ColorSwapPartial", color);
    }

    public IActionResult OnDeleteFadeOut()
    {
        return Content("<p></p>", "text/html");
    }

    public IActionResult OnPostFadeIn()
    {
        return Partial("_FadeInPartial");
    }

    public async Task<IActionResult> OnPostName(string name)
    {
        await Task.Delay(1000);
        return Content("<p>Submitted!</p>", "text/html");
    }

    public IActionResult OnGetNewContent()
    {
        var rnd = new Random();
        var randomPair = _pairs[rnd.Next(_pairs.Count)];
        return Partial("_SwapContentPartial", randomPair);
    }
}
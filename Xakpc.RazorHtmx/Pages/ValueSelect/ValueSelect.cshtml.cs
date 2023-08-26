using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Xakpc.RazorHtmx.Pages.ValueSelect;

public class ValueSelectModel : PageModel
{
    public Dictionary<string, List<string>> Dict { get; } = new()
    {
        { "Audi", new List<string> { "A1", "A3", "A4", "A5", "Q7" } },
        { "Toyota", new List<string> { "Camry", "Corolla", "Highlander", "Prius", "Supra" } },
        { "BMW", new List<string> { "X1", "X3", "X5", "3 Series", "5 Series" } }
    };

    public SelectList Makes { get; set; }

    public void OnGet()
    {
        Makes = new SelectList(Dict.Keys.Select(key => new SelectListItem
        {
            Value = key,
            Text = key
        }), "Value", "Text");
    }

    public IActionResult OnGetModels(string make)
    {
        return Partial("_SelectPartial", Dict[make]);
    }
}
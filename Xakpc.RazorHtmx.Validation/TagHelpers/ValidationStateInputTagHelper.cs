using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Xakpc.RazorHtmx.Validation.TagHelpers;

[HtmlTargetElement("input", Attributes = "asp-for")]
[HtmlTargetElement("select", Attributes = "asp-for")]
public class ValidationStateInputTagHelper : TagHelper
{
    [HtmlAttributeNotBound]
    [ViewContext]
    public ViewContext ViewContext { get; set; }

    [HtmlAttributeName("asp-for")]
    public ModelExpression For { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var model = For.Model;

        // Check if the field has a value
        bool hasValue = model != null && !string.IsNullOrEmpty(model.ToString());

        // Check if there are any validation errors for this field
        var modelState = ViewContext;
        bool hasError = modelState != null &&
                        modelState.ViewData.ModelState.TryGetValue(For.Name, out var entry) &&
                        entry.Errors.Count > 0;

        // Set the aria-invalid attribute based on the value and error
        if (hasValue)
        {
            output.Attributes.SetAttribute("aria-invalid", hasError ? "true" : "false");
        }
    }
}

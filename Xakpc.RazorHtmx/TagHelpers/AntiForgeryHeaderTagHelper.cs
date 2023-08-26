using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Xakpc.RazorHtmx.TagHelpers;

[HtmlTargetElement("input", Attributes = AntiForgeryAttributeName)]
[HtmlTargetElement("button", Attributes = AntiForgeryAttributeName)]
public class AntiForgeryHeaderTagHelper : TagHelper
{
    [HtmlAttributeNotBound]
    [ViewContext]
    public ViewContext ViewContext { get; set; }

    [HtmlAttributeName(AntiForgeryAttributeName)]
    public bool AntiForgery { get; set; }

    private const string AntiForgeryAttributeName = "antiforgery";
    private readonly IAntiforgery _antiforgery;

    public AntiForgeryHeaderTagHelper(IAntiforgery antiforgery)
    {
        _antiforgery = antiforgery;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        if (AntiForgery)
        {
            var token = _antiforgery.GetAndStoreTokens(ViewContext.HttpContext).RequestToken;
            var currentHeaderValue = output.Attributes["hx-headers"]?.Value.ToString();
            var newHeaderValue = $"\"RequestVerificationToken\": \"{token}\"";

            if (string.IsNullOrEmpty(currentHeaderValue))
            {
                output.Attributes.SetAttribute("hx-headers", newHeaderValue);
            }
            else
            {
                // Append the anti-forgery token to existing hx-headers
                newHeaderValue = $"{currentHeaderValue}, {newHeaderValue}";
                output.Attributes.SetAttribute("hx-headers", newHeaderValue);
            }
        }
    }
}
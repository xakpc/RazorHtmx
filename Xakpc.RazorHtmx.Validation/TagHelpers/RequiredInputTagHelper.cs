using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace Xakpc.RazorHtmx.Validation.TagHelpers;

[HtmlTargetElement("input", Attributes = "asp-for")]
[HtmlTargetElement("textarea", Attributes = "asp-for")]
public class RequiredInputTagHelper : TagHelper
{
    [HtmlAttributeName("asp-for")]
    public ModelExpression For { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var attribute = For.ModelExplorer.Metadata.ValidatorMetadata.FirstOrDefault(
            attr => attr is RequiredAttribute) as RequiredAttribute;

        if (attribute != null)
        {
            output.Attributes.SetAttribute("required", null);

            if (!string.IsNullOrEmpty(attribute.ErrorMessage))
            {
                output.Attributes.SetAttribute("data-err-required", attribute.ErrorMessage);    
            }
        }
    }
}

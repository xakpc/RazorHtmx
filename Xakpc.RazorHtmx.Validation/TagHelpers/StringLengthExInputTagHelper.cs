using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace Xakpc.RazorHtmx.Validation.TagHelpers;

[HtmlTargetElement("input", Attributes = "asp-for")]
public class StringLengthExInputTagHelper : TagHelper
{
    [HtmlAttributeName("asp-for")]
    public ModelExpression For { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var attribute = For.ModelExplorer.Metadata.ValidatorMetadata.FirstOrDefault(
            attr => attr is StringLengthAttribute) as StringLengthAttribute;

        if (attribute != null)
        {
            if (attribute.MinimumLength > 0)
            {
                output.Attributes.SetAttribute("minlength", attribute.MinimumLength);
            }     
            
            if (!string.IsNullOrEmpty(attribute.ErrorMessage))
            {
                output.Attributes.SetAttribute("data-err-length", attribute.ErrorMessage);
            }
        }
    }
}
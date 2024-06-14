using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace Xakpc.RazorHtmx.Validation.TagHelpers;

[HtmlTargetElement("input", Attributes = "asp-for")]
public class RangeInputTagHelper : TagHelper
{
    [HtmlAttributeName("asp-for")]
    public ModelExpression For { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var attribute = For.ModelExplorer.Metadata.ValidatorMetadata.FirstOrDefault(
            attr => attr is RangeAttribute) as RangeAttribute;

        if (attribute != null)
        {
            output.Attributes.SetAttribute("min", attribute.Minimum);
            output.Attributes.SetAttribute("max", attribute.Maximum);

            if (!string.IsNullOrEmpty(attribute.ErrorMessage))
            {
                output.Attributes.SetAttribute("data-err-minmax", attribute.ErrorMessage);
            }
        }
    }
}

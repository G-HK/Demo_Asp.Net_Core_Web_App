using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsPXL.TagHelpers
{
    [HtmlTargetElement("currency-helper")]
    public class PriceTagHelper : TagHelper
    {

        public decimal Currency { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagMode = TagMode.StartTagAndEndTag;

            var sb = new StringBuilder();

            sb.AppendFormat("<span><em>€{0}</em></span>", Currency);

            output.PreContent.SetHtmlContent(sb.ToString());
        }

    }
}

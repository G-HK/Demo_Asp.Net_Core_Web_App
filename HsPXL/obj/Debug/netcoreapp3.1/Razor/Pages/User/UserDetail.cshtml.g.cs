#pragma checksum "C:\Users\h_kad\Documenten\C# Web\HsPXL\HsPXL\Pages\User\UserDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "843c00a87ae64ed03ec126e4254d1098f21f263f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(HsPXL.Pages.User.Pages_User_UserDetail), @"mvc.1.0.razor-page", @"/Pages/User/UserDetail.cshtml")]
namespace HsPXL.Pages.User
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\h_kad\Documenten\C# Web\HsPXL\HsPXL\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.RazorPages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\h_kad\Documenten\C# Web\HsPXL\HsPXL\Pages\_ViewImports.cshtml"
using HsPXL.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\h_kad\Documenten\C# Web\HsPXL\HsPXL\Pages\_ViewImports.cshtml"
using System.ComponentModel.DataAnnotations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\h_kad\Documenten\C# Web\HsPXL\HsPXL\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{id?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"843c00a87ae64ed03ec126e4254d1098f21f263f", @"/Pages/User/UserDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad11b222dcc24c19c32528e0431ade9248f81fb3", @"/Pages/_ViewImports.cshtml")]
    public class Pages_User_UserDetail : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div>\r\n    <h4>User Detail</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 9 "C:\Users\h_kad\Documenten\C# Web\HsPXL\HsPXL\Pages\User\UserDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 12 "C:\Users\h_kad\Documenten\C# Web\HsPXL\HsPXL\Pages\User\UserDetail.cshtml"
       Write(Html.DisplayFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "C:\Users\h_kad\Documenten\C# Web\HsPXL\HsPXL\Pages\User\UserDetail.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "C:\Users\h_kad\Documenten\C# Web\HsPXL\HsPXL\Pages\User\UserDetail.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HsPXL.Pages.User.UserDetailModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<HsPXL.Pages.User.UserDetailModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<HsPXL.Pages.User.UserDetailModel>)PageContext?.ViewData;
        public HsPXL.Pages.User.UserDetailModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

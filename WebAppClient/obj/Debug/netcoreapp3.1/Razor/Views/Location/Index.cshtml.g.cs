#pragma checksum "C:\Users\v\source\repos\API\WebAppClient\Views\Location\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5f7bcdde72a5486147156b6608139b6d9755648"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Location_Index), @"mvc.1.0.view", @"/Views/Location/Index.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\v\source\repos\API\WebAppClient\Views\_ViewImports.cshtml"
using WebAppClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\v\source\repos\API\WebAppClient\Views\_ViewImports.cshtml"
using WebAppClient.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\v\source\repos\API\WebAppClient\Views\Location\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5f7bcdde72a5486147156b6608139b6d9755648", @"/Views/Location/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2bc154d613148df74ca95c32c1c6a64b3e868a5d", @"/Views/_ViewImports.cshtml")]
    public class Views_Location_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebAppClient.Models.Location>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\v\source\repos\API\WebAppClient\Views\Location\Index.cshtml"
  
    var test = HttpContextAccessor.HttpContext.User;
    string claimedRole = "";
    string tableId = "dataTablesLocation";
    if (test?.Claims != null)
    {
        claimedRole += test?.Claims?.SingleOrDefault(p => p.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
        if (claimedRole != "admin")
        {
            tableId = "dataTablesLocationUser";
        }

    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\v\source\repos\API\WebAppClient\Views\Location\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n");
#nullable restore
#line 24 "C:\Users\v\source\repos\API\WebAppClient\Views\Location\Index.cshtml"
 if (claimedRole == "admin")
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <button class=\"btn btn-primary\" onclick=\"addModalLocation()\" data-toggle=\"modal\" data-target=\"#modalLocation\">Create New</button>\r\n");
#nullable restore
#line 27 "C:\Users\v\source\repos\API\WebAppClient\Views\Location\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table table-striped table-dark\"");
            BeginWriteAttribute("id", " id=\"", 842, "\"", 855, 1);
#nullable restore
#line 28 "C:\Users\v\source\repos\API\WebAppClient\Views\Location\Index.cshtml"
WriteAttributeValue("", 847, tableId, 847, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "C:\Users\v\source\repos\API\WebAppClient\Views\Location\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 35 "C:\Users\v\source\repos\API\WebAppClient\Views\Location\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.StreetAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 38 "C:\Users\v\source\repos\API\WebAppClient\Views\Location\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PostalCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 41 "C:\Users\v\source\repos\API\WebAppClient\Views\Location\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 44 "C:\Users\v\source\repos\API\WebAppClient\Views\Location\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n");
#nullable restore
#line 46 "C:\Users\v\source\repos\API\WebAppClient\Views\Location\Index.cshtml"
             if (claimedRole == "admin")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <th></th>\r\n");
#nullable restore
#line 49 "C:\Users\v\source\repos\API\WebAppClient\Views\Location\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tr>
    </thead>
    <tbody>
    </tbody>
</table>

<div class=""modal fade"" id=""modalLocation"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">Modal</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div id=""modalContentLocation"">
            </div>
        </div>
    </div>
</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebAppClient.Models.Location>> Html { get; private set; }
    }
}
#pragma warning restore 1591

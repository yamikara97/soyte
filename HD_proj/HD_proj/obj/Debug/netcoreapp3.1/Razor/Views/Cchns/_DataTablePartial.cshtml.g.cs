#pragma checksum "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Cchns\_DataTablePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "97194895efa06120a017528cd8e6264f7e0c3049"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cchns__DataTablePartial), @"mvc.1.0.view", @"/Views/Cchns/_DataTablePartial.cshtml")]
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
#line 1 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\_ViewImports.cshtml"
using HD_proj;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\_ViewImports.cshtml"
using HD_proj.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"97194895efa06120a017528cd8e6264f7e0c3049", @"/Views/Cchns/_DataTablePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81b285939f39b3669a5ec575cb5b77a5fc1798ec", @"/Views/_ViewImports.cshtml")]
    public class Views_Cchns__DataTablePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HD_proj.Models.ModelViewmodel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<table id=""cchn"" class=""table nowrap table-bordered table-striped mt-5 table-data"">
    <thead>
        <tr>
            <th>STT</th>
            <th>Id</th>
            <th>Ngày cấp</th>
            <th>Ngày hiệu lực</th>
            <th>Quyết định</th>
            <th>Người đại diện</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 17 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Cchns\_DataTablePartial.cshtml"
         foreach (var item in Model)
        {
            if (item != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td></td>\r\n                    <td>");
#nullable restore
#line 23 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Cchns\_DataTablePartial.cshtml"
                   Write(item.Cchn.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 24 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Cchns\_DataTablePartial.cshtml"
                   Write(item.Cchn.Ngaycap);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 25 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Cchns\_DataTablePartial.cshtml"
                   Write(item.Cchn.Ngayhieuluc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 26 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Cchns\_DataTablePartial.cshtml"
                    Write(item.Quyetdinh == null ? "" : item.Quyetdinh.Sohieu);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Cchns\_DataTablePartial.cshtml"
                    Write(item.Giaytotuythan == null? "" :  item.Giaytotuythan.Hoten);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"text-center\">\r\n                        <button class=\"btn btn-primary action-btn border-0\" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 29 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Cchns\_DataTablePartial.cshtml"
                                                                                                                                      Write(Url.Action("Create") + "/" + item.Cchn.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            <span><i class=\"fas fa-pen\"></i></span>\r\n                        </button>\r\n                        <button class=\"btn btn-primary action-btn border-0\" data-toggle=\"ajax-modal\" data-target=\"#order-model\" data-url=\"");
#nullable restore
#line 32 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Cchns\_DataTablePartial.cshtml"
                                                                                                                                      Write(Url.Action("Mail") + "/" + item.Cchn.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                            <span><i class=\"fas fa-arrow-alt-circle-up\"></i></span>\r\n                        </button>\r\n\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 38 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Cchns\_DataTablePartial.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HD_proj.Models.ModelViewmodel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
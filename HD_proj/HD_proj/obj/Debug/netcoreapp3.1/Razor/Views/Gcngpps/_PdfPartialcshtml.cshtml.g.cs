#pragma checksum "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Gcngpps\_PdfPartialcshtml.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "407a001db26535fc74d1491b0932b1287274f826"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Gcngpps__PdfPartialcshtml), @"mvc.1.0.view", @"/Views/Gcngpps/_PdfPartialcshtml.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"407a001db26535fc74d1491b0932b1287274f826", @"/Views/Gcngpps/_PdfPartialcshtml.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81b285939f39b3669a5ec575cb5b77a5fc1798ec", @"/Views/_ViewImports.cshtml")]
    public class Views_Gcngpps__PdfPartialcshtml : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Gcndkkd>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal fade p-0"" id=""order-modal "">
    <div class=""modal-xl modal-dialog w-100"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""text-danger font-weight-bold text-uppercase"">Thông tin chứng chỉ hành nghề Dược</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""container-fluid text-dark border-dark"" id=""print-PDF"" style=""font-family: Arial !important;"">
                <div class=""row pt-3"">
                    <div class=""col-6"">
                        <label class=""text-center font-weight-bold w-100 "">UBND THÀNH PHỐ HẢI PHÒNG</label>
                        <label class=""text-center font-weight-bold w-100"" style=""text-decoration: underline"">SỞ Y TẾ</label>
                        <label class=""text-center font-weight-bold w-100"">
                            Số: <span class=""text-danger"">");
#nullable restore
#line 15 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Gcngpps\_PdfPartialcshtml.cshtml"
                                                     Write(Model.So);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </label>
                    </div>
                    <div class=""col-6"">
                        <label class=""text-center font-weight-bold w-100"">CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</label>
                        <label class=""text-center font-weight-bold w-100"" style=""text-decoration: underline"">Độc lập - Tự do - Hạnh Phúc</label>
                    </div>

                </div>
");
#nullable restore
#line 24 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Gcngpps\_PdfPartialcshtml.cshtml"
                  
                    var giayToTuyThan = ViewData["Giaytotuythan"] as Giaytotuythan;
                

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""row pt-2"">
                    <div class=""col-12"">
                        <h4 class=""text-center text-danger font-weight-bold w-100"">THÔNG TIN CHỨNG NHẬN <br />GPP</h4>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""col-4"">
                        <label class=""text-left font-weight-bold"">I. Thông tin chi tiết</label>
                        <br />
                        <label>Họ và tên: ");
#nullable restore
#line 36 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Gcngpps\_PdfPartialcshtml.cshtml"
                                      Write(giayToTuyThan == null ? "" : giayToTuyThan.Hoten);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                        <br />\r\n                        <label>Ngày sinh: ");
#nullable restore
#line 38 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Gcngpps\_PdfPartialcshtml.cshtml"
                                      Write(giayToTuyThan == null ? DateTime.MinValue.ToString("yyyy-MM-dd")  : giayToTuyThan.Ngaysinh.ToString("yyyy-MM-dd") );

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                        <br />\r\n                        <label>CMND/CCCD: ");
#nullable restore
#line 40 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Gcngpps\_PdfPartialcshtml.cshtml"
                                      Write(giayToTuyThan == null ? "" : giayToTuyThan.IdCmnd);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                        <br />\r\n                        <label>Ngày cấp: ");
#nullable restore
#line 42 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Gcngpps\_PdfPartialcshtml.cshtml"
                                     Write(giayToTuyThan == null ? DateTime.MinValue.ToString("yyyy-MM-dd")  : giayToTuyThan.Ngaycap.ToString("yyyy-MM-dd") );

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                        <label class=\"pl-5\">Nơi cấp: ");
#nullable restore
#line 43 "C:\Users\Cheem\Documents\GitHub\soyte\HD_proj\HD_proj\Views\Gcngpps\_PdfPartialcshtml.cshtml"
                                                 Write(giayToTuyThan == null ? "" : giayToTuyThan.Noicap);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
                   
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-danger"" data-dismiss=""modal"">Thoát</button>
                <button type=""button"" class=""btn btn-primary"" data-save=""modal"">In</button>
            </div>
        </div>
    </div>
</div>
<script>
    $(document).ready(function () {
        $('input').on('change', function () {
                $(this).css(""border"", ""1px solid #d1d3e2"");
        });
    });

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Gcndkkd> Html { get; private set; }
    }
}
#pragma warning restore 1591

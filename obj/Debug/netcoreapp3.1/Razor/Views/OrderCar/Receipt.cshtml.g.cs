#pragma checksum "D:\Users\bsi50128\source\repos\RentCar\RentCar\Views\OrderCar\Receipt.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d8dd3b6d8ff38eadfab1d8b2de088a969bb04f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OrderCar_Receipt), @"mvc.1.0.view", @"/Views/OrderCar/Receipt.cshtml")]
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
#line 1 "D:\Users\bsi50128\source\repos\RentCar\RentCar\Views\_ViewImports.cshtml"
using RentCar;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\bsi50128\source\repos\RentCar\RentCar\Views\_ViewImports.cshtml"
using RentCar.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d8dd3b6d8ff38eadfab1d8b2de088a969bb04f3", @"/Views/OrderCar/Receipt.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"612a37676d153cccf3f3542ae2284021dc345f54", @"/Views/_ViewImports.cshtml")]
    public class Views_OrderCar_Receipt : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"modal-body\">\r\n");
#nullable restore
#line 2 "D:\Users\bsi50128\source\repos\RentCar\RentCar\Views\OrderCar\Receipt.cshtml"
      
        var detail = ViewBag.Detail;
        var va_number = ViewBag.Va;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3>RECEIPT PEMBAYARAN</h3>\r\n        <label>Status</label>\r\n        <h5>");
#nullable restore
#line 7 "D:\Users\bsi50128\source\repos\RentCar\RentCar\Views\OrderCar\Receipt.cshtml"
       Write(detail.transaction_status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <label>Order Id</label>\r\n        <h5>");
#nullable restore
#line 9 "D:\Users\bsi50128\source\repos\RentCar\RentCar\Views\OrderCar\Receipt.cshtml"
       Write(detail.order_id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <label>Transaction Id</label>\r\n        <h5>");
#nullable restore
#line 11 "D:\Users\bsi50128\source\repos\RentCar\RentCar\Views\OrderCar\Receipt.cshtml"
       Write(detail.transaction_id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n        <label>Virtual Account Number</label>\r\n");
#nullable restore
#line 13 "D:\Users\bsi50128\source\repos\RentCar\RentCar\Views\OrderCar\Receipt.cshtml"
        foreach (var v in va_number)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h5>");
#nullable restore
#line 15 "D:\Users\bsi50128\source\repos\RentCar\RentCar\Views\OrderCar\Receipt.cshtml"
           Write(v.va_number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
#nullable restore
#line 16 "D:\Users\bsi50128\source\repos\RentCar\RentCar\Views\OrderCar\Receipt.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
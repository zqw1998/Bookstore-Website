#pragma checksum "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2c3c3cd3116d7947c368fd43e0f0ea6095e5224"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_CheckOut), @"mvc.1.0.view", @"/Views/Orders/CheckOut.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Orders/CheckOut.cshtml", typeof(AspNetCore.Views_Orders_CheckOut))]
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
#line 2 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
using Team12FinalProject.Controllers;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2c3c3cd3116d7947c368fd43e0f0ea6095e5224", @"/Views/Orders/CheckOut.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_CheckOut : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Team12FinalProject.Models.Order>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SearchCoupons", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("Asp-controller", "Orders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(79, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
  
    ViewBag.Title = "CheckOut";

#line default
#line hidden
            BeginContext(121, 20, true);
            WriteLiteral("<h2>Check Out</h2>\r\n");
            EndContext();
#line 8 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
            BeginContext(176, 23, false);
#line 10 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(201, 202, true);
            WriteLiteral("    <table class=\"table table-sm table-bordered\" style=\"width:30%\">\r\n        <tr>\r\n            <th colspan=\"2\" style=\"text-align:center\">Order Summary</th>\r\n        </tr>\r\n        <tr>\r\n            <td>");
            EndContext();
            BeginContext(404, 45, false);
#line 16 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
           Write(Html.DisplayNameFor(model => model.OrderDate));

#line default
#line hidden
            EndContext();
            BeginContext(449, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(473, 41, false);
#line 17 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
           Write(Html.DisplayFor(model => model.OrderDate));

#line default
#line hidden
            EndContext();
            BeginContext(514, 52, true);
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>");
            EndContext();
            BeginContext(567, 44, false);
#line 20 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
           Write(Html.DisplayNameFor(model => model.Subtotal));

#line default
#line hidden
            EndContext();
            BeginContext(611, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(635, 40, false);
#line 21 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
           Write(Html.DisplayFor(model => model.Subtotal));

#line default
#line hidden
            EndContext();
            BeginContext(675, 52, true);
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>");
            EndContext();
            BeginContext(728, 47, false);
#line 24 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
           Write(Html.DisplayNameFor(model => model.DiscountAmt));

#line default
#line hidden
            EndContext();
            BeginContext(775, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(799, 43, false);
#line 25 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
           Write(Html.DisplayFor(model => model.DiscountAmt));

#line default
#line hidden
            EndContext();
            BeginContext(842, 52, true);
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>");
            EndContext();
            BeginContext(895, 47, false);
#line 28 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
           Write(Html.DisplayNameFor(model => model.ShippingAmt));

#line default
#line hidden
            EndContext();
            BeginContext(942, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(966, 43, false);
#line 29 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
           Write(Html.DisplayFor(model => model.ShippingAmt));

#line default
#line hidden
            EndContext();
            BeginContext(1009, 52, true);
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>");
            EndContext();
            BeginContext(1062, 46, false);
#line 32 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
           Write(Html.DisplayNameFor(model => model.TotalPrice));

#line default
#line hidden
            EndContext();
            BeginContext(1108, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1132, 42, false);
#line 33 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
           Write(Html.DisplayFor(model => model.TotalPrice));

#line default
#line hidden
            EndContext();
            BeginContext(1174, 86, true);
            WriteLiteral("</td>\r\n        </tr>\r\n    </table>\r\n    <h4>Shipping Address</h4>\r\n    <p>\r\n\r\n        ");
            EndContext();
            BeginContext(1262, 107, false);
#line 39 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
    Write(Model.AppUser.Street + ", " + Model.AppUser.City + ", " + Model.AppUser.State + " " + Model.AppUser.ZipCode);

#line default
#line hidden
            EndContext();
            BeginContext(1370, 103, true);
            WriteLiteral("\r\n    </p>\r\n    <h4>Confirm the Order</h4>\r\n    <div class=\"form-group\">\r\n        <label class=\"radio\">");
            EndContext();
            BeginContext(1474, 46, false);
#line 43 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
                        Write(Html.RadioButton("Confirm", Confirm.Yes, true));

#line default
#line hidden
            EndContext();
            BeginContext(1520, 43, true);
            WriteLiteral(" Yes</label>\r\n        <label class=\"radio\">");
            EndContext();
            BeginContext(1564, 39, false);
#line 44 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
                        Write(Html.RadioButton("Confirm", Confirm.No));

#line default
#line hidden
            EndContext();
            BeginContext(1603, 108, true);
            WriteLiteral(" No</label>\r\n    </div>\r\n    <div class=\"form-horizontal\">\r\n        <h4>Order</h4>\r\n        <hr />\r\n        ");
            EndContext();
            BeginContext(1712, 64, false);
#line 49 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1776, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(1787, 38, false);
#line 50 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
   Write(Html.HiddenFor(model => model.OrderID));

#line default
#line hidden
            EndContext();
            BeginContext(1825, 175, true);
            WriteLiteral("\r\n        <div class=\"form-group\">\r\n            <label class=\"control-label col-md-2\">Using Existing Credit Card</label>\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(2001, 96, false);
#line 54 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
           Write(Html.DropDownList("SelectedCard", (SelectList)ViewBag.allCards, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(2097, 67, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n        <div>\r\n            ");
            EndContext();
            BeginContext(2165, 58, false);
#line 59 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
       Write(Html.ActionLink("Add Credit Card", "Index", "CreditCards"));

#line default
#line hidden
            EndContext();
            BeginContext(2223, 226, true);
            WriteLiteral("\r\n        </div>\r\n\r\n\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-offset-2 col-md-10\">\r\n            <input type=\"submit\" value=\"Place the Order\" class=\"btn btn-default\" />\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 69 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
}

#line default
#line hidden
            BeginContext(2452, 54, true);
            WriteLiteral("\r\n<h2>Enter the Promo Code(one promo per order)</h2>\r\n");
            EndContext();
            BeginContext(2506, 353, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5cf31ec0228c402cb7ad6c9e0ef6c897", async() => {
                BeginContext(2576, 276, true);
                WriteLiteral(@"
    <div class=""form-group"">
        <label class=""control-label col-md-2"">Enter the Promo Code(one promo per order)</label>
        <input name=""CouponC"" class=""from-control"" />
    </div>
    <button type=""Submit"" class=""btn btn-danger"">Apply the Promo Code</button>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2859, 15, true);
            WriteLiteral("\r\n\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2875, 40, false);
#line 81 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/CheckOut.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
            EndContext();
            BeginContext(2915, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Team12FinalProject.Models.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591

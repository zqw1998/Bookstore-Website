#pragma checksum "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Reports/AllBooksSold.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15f251864a944ed80b21f798cde758f5eadc2c4a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reports_AllBooksSold), @"mvc.1.0.view", @"/Views/Reports/AllBooksSold.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Reports/AllBooksSold.cshtml", typeof(AspNetCore.Views_Reports_AllBooksSold))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15f251864a944ed80b21f798cde758f5eadc2c4a", @"/Views/Reports/AllBooksSold.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Reports_AllBooksSold : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Team12FinalProject.Models.OrderDetail>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AllBooksSold", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Reports", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Reports/AllBooksSold.cshtml"
  
    ViewData["Title"] = "AllBooksSold";

#line default
#line hidden
            BeginContext(107, 32, true);
            WriteLiteral("<h2>All Books Sold Report</h2>\r\n");
            EndContext();
            BeginContext(139, 390, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "21e19838fe684852b2d7c46d93d1a990", async() => {
                BeginContext(209, 113, true);
                WriteLiteral("\r\n    <p class=\"form-group\">\r\n        <div class=\"form-group\">\r\n            <label>Sort By:</label>\r\n            ");
                EndContext();
                BeginContext(323, 98, false);
#line 10 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Reports/AllBooksSold.cshtml"
       Write(Html.DropDownList("SelectedSort", (SelectList)ViewBag.AllFilters, new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(421, 101, true);
                WriteLiteral("\r\n        </div>\r\n        <button type=\"submit\" class=\"btn btn-secondary\">Sort</button>\r\n    </p>\r\n\r\n");
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
            BeginContext(529, 90, true);
            WriteLiteral("\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(620, 46, false);
#line 22 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Reports/AllBooksSold.cshtml"
           Write(Html.DisplayNameFor(model => model.Book.Title));

#line default
#line hidden
            EndContext();
            BeginContext(666, 470, true);
            WriteLiteral(@"
            </th>
            <th>
                Quantity
            </th>
            <th>
                Order Number
            </th>
            <th>
                Customer Name
            </th>
            <th>
                Price
            </th>
            <th>
                Weighted Average Cost
            <th>
                Profit Margins
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 45 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Reports/AllBooksSold.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1185, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1234, 45, false);
#line 49 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Reports/AllBooksSold.cshtml"
           Write(Html.DisplayFor(modelItem => item.Book.Title));

#line default
#line hidden
            EndContext();
            BeginContext(1279, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1335, 43, false);
#line 52 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Reports/AllBooksSold.cshtml"
           Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
            EndContext();
            BeginContext(1378, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1434, 52, false);
#line 55 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Reports/AllBooksSold.cshtml"
           Write(Html.DisplayFor(modelItem => item.Order.OrderNumber));

#line default
#line hidden
            EndContext();
            BeginContext(1486, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1542, 58, false);
#line 58 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Reports/AllBooksSold.cshtml"
           Write(Html.DisplayFor(modelItem => item.Order.AppUser.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(1600, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1602, 57, false);
#line 58 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Reports/AllBooksSold.cshtml"
                                                                       Write(Html.DisplayFor(modelItem => item.Order.AppUser.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(1659, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1715, 44, false);
#line 61 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Reports/AllBooksSold.cshtml"
           Write(Html.DisplayFor(modelItem => item.BookPrice));

#line default
#line hidden
            EndContext();
            BeginContext(1759, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1815, 47, false);
#line 64 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Reports/AllBooksSold.cshtml"
           Write(Html.DisplayFor(modelItem => item.Book.AvgCost));

#line default
#line hidden
            EndContext();
            BeginContext(1862, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1918, 46, false);
#line 67 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Reports/AllBooksSold.cshtml"
           Write(Html.DisplayFor(modelItem => item.Book.Profit));

#line default
#line hidden
            EndContext();
            BeginContext(1964, 38, true);
            WriteLiteral("\r\n            </td>\r\n\r\n        </tr>\r\n");
            EndContext();
#line 71 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Reports/AllBooksSold.cshtml"
        }

#line default
#line hidden
            BeginContext(2013, 44, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n<p>\r\n    Displaying ");
            EndContext();
            BeginContext(2058, 14, false);
#line 75 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Reports/AllBooksSold.cshtml"
          Write(ViewBag.Record);

#line default
#line hidden
            EndContext();
            BeginContext(2072, 37, true);
            WriteLiteral(" number of records\r\n</p>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2109, 41, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6298fa37c45141128a3c85620a88eed3", async() => {
                BeginContext(2131, 15, true);
                WriteLiteral("Back to Reports");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2150, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(2156, 52, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "89d340cd4ade4c8d9efb67f2dba0a874", async() => {
                BeginContext(2200, 4, true);
                WriteLiteral("Home");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2208, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Team12FinalProject.Models.OrderDetail>> Html { get; private set; }
    }
}
#pragma warning restore 1591

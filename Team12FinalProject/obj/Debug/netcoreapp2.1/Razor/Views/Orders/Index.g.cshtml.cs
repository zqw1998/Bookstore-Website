#pragma checksum "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f835020641b80997cbd81e9aa0ab4dae1471cdc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_Index), @"mvc.1.0.view", @"/Views/Orders/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Orders/Index.cshtml", typeof(AspNetCore.Views_Orders_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f835020641b80997cbd81e9aa0ab4dae1471cdc", @"/Views/Orders/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Team12FinalProject.Models.Order>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
            BeginContext(92, 138, true);
            WriteLiteral("<h2>Order History</h2>\r\n<table class=\"table\">\r\n    <tr>\r\n        <th>\r\n            Order Number\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(231, 45, false);
#line 13 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/Index.cshtml"
       Write(Html.DisplayNameFor(model => model.OrderDate));

#line default
#line hidden
            EndContext();
            BeginContext(276, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(320, 40, false);
#line 16 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Note));

#line default
#line hidden
            EndContext();
            BeginContext(360, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(404, 46, false);
#line 19 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/Index.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalPrice));

#line default
#line hidden
            EndContext();
            BeginContext(450, 47, true);
            WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n");
            EndContext();
#line 23 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(538, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(587, 46, false);
#line 27 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.OrderNumber));

#line default
#line hidden
            EndContext();
            BeginContext(633, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(689, 44, false);
#line 30 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.OrderDate));

#line default
#line hidden
            EndContext();
            BeginContext(733, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(789, 39, false);
#line 33 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Note));

#line default
#line hidden
            EndContext();
            BeginContext(828, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(884, 45, false);
#line 36 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.TotalPrice));

#line default
#line hidden
            EndContext();
            BeginContext(929, 39, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
            EndContext();
#line 39 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/Index.cshtml"
                 if (item.CheckOutStatus == false)
                {

#line default
#line hidden
            BeginContext(1037, 58, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a58df34e69e4d2ea030a48410891ac9", async() => {
                BeginContext(1087, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 40 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/Index.cshtml"
                                        WriteLiteral(item.OrderID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1097, 28, true);
            WriteLiteral("&nbsp;\r\n                    ");
            EndContext();
            BeginContext(1127, 8, true);
            WriteLiteral("&nbsp;\r\n");
            EndContext();
#line 42 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/Index.cshtml"
                }

#line default
#line hidden
            BeginContext(1154, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1173, 64, false);
#line 44 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { id = item.OrderID }));

#line default
#line hidden
            EndContext();
            BeginContext(1237, 42, true);
            WriteLiteral("\r\n\r\n            </td>\r\n\r\n\r\n        </tr>\r\n");
            EndContext();
#line 50 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Orders/Index.cshtml"
    }

#line default
#line hidden
            BeginContext(1286, 10, true);
            WriteLiteral("</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Team12FinalProject.Models.Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Books/DetailedSearch.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b078cec703a3220a123341c6c99ca8432709efe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Books_DetailedSearch), @"mvc.1.0.view", @"/Views/Books/DetailedSearch.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Books/DetailedSearch.cshtml", typeof(AspNetCore.Views_Books_DetailedSearch))]
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
#line 1 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Books/DetailedSearch.cshtml"
using Team12FinalProject.Controllers;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b078cec703a3220a123341c6c99ca8432709efe", @"/Views/Books/DetailedSearch.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Books_DetailedSearch : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DisplaySearchResults", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Books", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(39, 26, true);
            WriteLiteral("<h2>Detailed Search</h2>\r\n");
            EndContext();
            BeginContext(65, 1241, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61eb3da9717f476c8da258da35ebf8a0", async() => {
                BeginContext(141, 346, true);
                WriteLiteral(@"
    <div class=""form-group"">
        <label>Title:</label>
        <input name=""SearchTitle"" class=""form-control"" />
    </div>
    <div class=""form-group"">
        <label>Author:</label>
        <input name=""SearchAuthor"" class=""form-control"" />
    </div>
    <div class=""form-group"">
        <label>Choose a Genre:</label>
        ");
                EndContext();
                BeginContext(488, 98, false);
#line 14 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Books/DetailedSearch.cshtml"
   Write(Html.DropDownList("SelectedGenre", (SelectList)ViewBag.AllGenres, new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(586, 67, true);
                WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        Unique Number: ");
                EndContext();
                BeginContext(654, 64, false);
#line 17 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Books/DetailedSearch.cshtml"
                  Write(Html.TextBox("UniqueNum", null, new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(718, 25, true);
                WriteLiteral("<div class=\"text-danger\">");
                EndContext();
                BeginContext(744, 15, false);
#line 17 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Books/DetailedSearch.cshtml"
                                                                                                            Write(ViewBag.Message);

#line default
#line hidden
                EndContext();
                BeginContext(759, 91, true);
                WriteLiteral("</div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label>Sort By:</label>\r\n        ");
                EndContext();
                BeginContext(851, 100, false);
#line 21 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Books/DetailedSearch.cshtml"
   Write(Html.DropDownList("SelectedFilter", (SelectList)ViewBag.AllFilters, new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(951, 73, true);
                WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label class=\"radio\">");
                EndContext();
                BeginContext(1025, 58, false);
#line 24 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Books/DetailedSearch.cshtml"
                        Write(Html.RadioButton("SelectedCondition", Condition.All, true));

#line default
#line hidden
                EndContext();
                BeginContext(1083, 48, true);
                WriteLiteral("All Books</label>\r\n        <label class=\"radio\">");
                EndContext();
                BeginContext(1132, 60, false);
#line 25 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Books/DetailedSearch.cshtml"
                        Write(Html.RadioButton("SelectedCondition", Condition.InStockOnly));

#line default
#line hidden
                EndContext();
                BeginContext(1192, 107, true);
                WriteLiteral("Only Books In Stock</label>\r\n    </div>\r\n    <button type=\"submit\" class=\"btn btn-danger\">Search</button>\r\n");
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

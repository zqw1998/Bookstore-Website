#pragma checksum "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "08de78fb30175edcb72a48f966336ed234509305"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RoleAdmin_Modify), @"mvc.1.0.view", @"/Views/RoleAdmin/Modify.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/RoleAdmin/Modify.cshtml", typeof(AspNetCore.Views_RoleAdmin_Modify))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08de78fb30175edcb72a48f966336ed234509305", @"/Views/RoleAdmin/Modify.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_RoleAdmin_Modify : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Team12FinalProject.Models.AppUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
  
    ViewData["Title"] = "Modify";

#line default
#line hidden
            BeginContext(84, 23, true);
            WriteLiteral("<h2>Edit Profile</h2>\r\n");
            EndContext();
#line 6 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
            BeginContext(142, 23, false);
#line 8 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(169, 59, true);
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <hr />\r\n        ");
            EndContext();
            BeginContext(229, 64, false);
#line 12 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(293, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(304, 33, false);
#line 13 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
   Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(337, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 14 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
         if (User.IsInRole("Manager"))
        {

#line default
#line hidden
            BeginContext(390, 82, true);
            WriteLiteral("            <p>manager</p>\r\n            <div class=\"form-group\">\r\n                ");
            EndContext();
            BeginContext(473, 98, false);
#line 18 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
           Write(Html.LabelFor(model => model.FirstName, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(571, 63, true);
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
            EndContext();
            BeginContext(635, 98, false);
#line 20 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
               Write(Html.EditorFor(model => model.FirstName, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(733, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(756, 87, false);
#line 21 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
               Write(Html.ValidationMessageFor(model => model.FirstName, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(843, 100, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
            EndContext();
            BeginContext(944, 97, false);
#line 25 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
           Write(Html.LabelFor(model => model.LastName, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(1041, 63, true);
            WriteLiteral("\r\n                <div class=\"col-md-10\">\r\n                    ");
            EndContext();
            BeginContext(1105, 97, false);
#line 27 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
               Write(Html.EditorFor(model => model.LastName, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1202, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(1225, 86, false);
#line 28 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
               Write(Html.ValidationMessageFor(model => model.LastName, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1311, 46, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 31 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
        }

#line default
#line hidden
            BeginContext(1368, 46, true);
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(1415, 94, false);
#line 33 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
       Write(Html.LabelFor(model => model.Email, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(1509, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(1565, 94, false);
#line 35 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
           Write(Html.EditorFor(model => model.Email, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(1659, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(1678, 83, false);
#line 36 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
           Write(Html.ValidationMessageFor(model => model.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1761, 84, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(1846, 95, false);
#line 40 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
       Write(Html.LabelFor(model => model.Street, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(1941, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(1997, 95, false);
#line 42 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
           Write(Html.EditorFor(model => model.Street, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(2092, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(2111, 84, false);
#line 43 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
           Write(Html.ValidationMessageFor(model => model.Street, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(2195, 84, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(2280, 93, false);
#line 47 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
       Write(Html.LabelFor(model => model.City, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(2373, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(2429, 93, false);
#line 49 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
           Write(Html.EditorFor(model => model.City, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(2522, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(2541, 82, false);
#line 50 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
           Write(Html.ValidationMessageFor(model => model.City, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(2623, 84, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(2708, 94, false);
#line 54 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
       Write(Html.LabelFor(model => model.State, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(2802, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(2858, 94, false);
#line 56 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
           Write(Html.EditorFor(model => model.State, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(2952, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(2971, 83, false);
#line 57 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
           Write(Html.ValidationMessageFor(model => model.State, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(3054, 84, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
            EndContext();
            BeginContext(3139, 96, false);
#line 61 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
       Write(Html.LabelFor(model => model.ZipCode, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
            EndContext();
            BeginContext(3235, 55, true);
            WriteLiteral("\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(3291, 96, false);
#line 63 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
           Write(Html.EditorFor(model => model.ZipCode, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(3387, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(3406, 85, false);
#line 64 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
           Write(Html.ValidationMessageFor(model => model.ZipCode, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(3491, 151, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            Phone Number\r\n            <div class=\"col-md-10\">\r\n                ");
            EndContext();
            BeginContext(3643, 100, false);
#line 70 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
           Write(Html.EditorFor(model => model.PhoneNumber, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
            EndContext();
            BeginContext(3743, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(3762, 89, false);
#line 71 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
           Write(Html.ValidationMessageFor(model => model.PhoneNumber, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(3851, 174, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"form-group\">\r\n            <input type=\"submit\" value=\"Save\" class=\"btn btn-primary\" />\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 78 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Modify.cshtml"
}

#line default
#line hidden
            BeginContext(4028, 11, true);
            WriteLiteral("<div>\r\n    ");
            EndContext();
            BeginContext(4039, 45, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6c1d1e31946417a95cd7175618d5a0c", async() => {
                BeginContext(4061, 19, true);
                WriteLiteral("Back to manage page");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4084, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Team12FinalProject.Models.AppUser> Html { get; private set; }
    }
}
#pragma warning restore 1591

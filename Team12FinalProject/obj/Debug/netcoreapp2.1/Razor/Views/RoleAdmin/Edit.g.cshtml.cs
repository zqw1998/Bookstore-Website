#pragma checksum "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "997463b0ee457b6966afab27115c436ee5a925e3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RoleAdmin_Edit), @"mvc.1.0.view", @"/Views/RoleAdmin/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/RoleAdmin/Edit.cshtml", typeof(AspNetCore.Views_RoleAdmin_Edit))]
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
#line 1 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
using Team12FinalProject.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"997463b0ee457b6966afab27115c436ee5a925e3", @"/Views/RoleAdmin/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_RoleAdmin_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleEditModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RegisterE", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ModifyE", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Fire", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RegisterC", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ModifyC", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
  
    ViewBag.Title = "Edit Role";

#line default
#line hidden
            BeginContext(97, 15, true);
            WriteLiteral("<h2>Edit Role: ");
            EndContext();
            BeginContext(113, 15, false);
#line 6 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
          Write(Model.Role.Name);

#line default
#line hidden
            EndContext();
            BeginContext(128, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
            BeginContext(136, 24, false);
#line 7 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
Write(Html.ValidationSummary());

#line default
#line hidden
            EndContext();
            BeginContext(160, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
            BeginContext(192, 40, true);
            WriteLiteral("    <input type=\"hidden\" name=\"roleName\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 232, "\"", 256, 1);
#line 10 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
WriteAttributeValue("", 240, Model.Role.Name, 240, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(257, 5, true);
            WriteLiteral(" />\r\n");
            EndContext();
#line 44 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
     if (Model.Role.Name == "Employee" && User.IsInRole("Manager"))
    {

#line default
#line hidden
            BeginContext(1441, 25, true);
            WriteLiteral("        <p>\r\n            ");
            EndContext();
            BeginContext(1466, 49, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33ffd09ce27a4460923c92a6a53b545e", async() => {
                BeginContext(1492, 19, true);
                WriteLiteral("Create New Employee");
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
            BeginContext(1515, 108, true);
            WriteLiteral("\r\n        </p>\r\n        <div class=\"panel panel-primary\">\r\n            <table class=\"table table-striped\">\r\n");
            EndContext();
#line 51 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                 if (Model.Members.Count() == 0)
                {

#line default
#line hidden
            BeginContext(1692, 79, true);
            WriteLiteral("                    <tr>\r\n                        <td colspan=\"3\">No Users Are ");
            EndContext();
            BeginContext(1772, 15, false);
#line 54 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                                                Write(Model.Role.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1787, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 56 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(1881, 275, true);
            WriteLiteral(@"                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>Email</th>
                        <th>Fired</th>
                        <th>Promote to Manager</th>
                    </tr>
");
            EndContext();
#line 66 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                    foreach (AppUser user in Model.Members)
                    {

#line default
#line hidden
            BeginContext(2240, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(2303, 14, false);
#line 69 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                           Write(user.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(2317, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(2357, 13, false);
#line 70 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                           Write(user.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(2370, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(2410, 13, false);
#line 71 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                           Write(user.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(2423, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(2463, 13, false);
#line 72 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                           Write(user.Disabled);

#line default
#line hidden
            EndContext();
            BeginContext(2476, 111, true);
            WriteLiteral("</td>\r\n                            <td>\r\n                                <input type=\"checkbox\" name=\"IdsToAdd\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2587, "\"", 2603, 1);
#line 74 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
WriteAttributeValue("", 2595, user.Id, 2595, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2604, 106, true);
            WriteLiteral(" />\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(2710, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "08bd613a8a9f47188a4e90ca5d2ca855", async() => {
                BeginContext(2758, 14, true);
                WriteLiteral("Modify Account");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 77 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                                                          WriteLiteral(user.Id);

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
            BeginContext(2776, 36, true);
            WriteLiteral(" |\r\n                                ");
            EndContext();
            BeginContext(2812, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "995134aa16a243d0b4375f0d2587b1b4", async() => {
                BeginContext(2857, 18, true);
                WriteLiteral("Fire this Employee");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 78 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                                                       WriteLiteral(user.Id);

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
            BeginContext(2879, 68, true);
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 81 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(2989, 38, true);
            WriteLiteral("            </table>\r\n        </div>\r\n");
            EndContext();
#line 85 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
    }

#line default
#line hidden
#line 87 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
     if (Model.Role.Name == "Customer")
    {

#line default
#line hidden
            BeginContext(3084, 25, true);
            WriteLiteral("        <p>\r\n            ");
            EndContext();
            BeginContext(3109, 49, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc7cdbee979742668ba2a506b750aed7", async() => {
                BeginContext(3135, 19, true);
                WriteLiteral("Create New Customer");
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
            BeginContext(3158, 108, true);
            WriteLiteral("\r\n        </p>\r\n        <div class=\"panel panel-primary\">\r\n            <table class=\"table table-striped\">\r\n");
            EndContext();
#line 94 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                 if (Model.Members.Count() == 0)
                {

#line default
#line hidden
            BeginContext(3335, 79, true);
            WriteLiteral("                    <tr>\r\n                        <td colspan=\"3\">No Users Are ");
            EndContext();
            BeginContext(3415, 15, false);
#line 97 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                                                Write(Model.Role.Name);

#line default
#line hidden
            EndContext();
            BeginContext(3430, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 99 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(3524, 225, true);
            WriteLiteral("                    <tr>\r\n                        <th>First Name</th>\r\n                        <th>Last Name</th>\r\n                        <th>Email</th>\r\n                        <th>Disabled</th>\r\n                    </tr>\r\n");
            EndContext();
#line 108 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                    foreach (AppUser user in Model.Members)
                    {

#line default
#line hidden
            BeginContext(3833, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(3896, 14, false);
#line 111 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                           Write(user.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(3910, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(3950, 13, false);
#line 112 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                           Write(user.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(3963, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(4003, 13, false);
#line 113 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                           Write(user.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(4016, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(4056, 13, false);
#line 114 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                           Write(user.Disabled);

#line default
#line hidden
            EndContext();
            BeginContext(4069, 73, true);
            WriteLiteral("</td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(4142, 66, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d356a0dff4e14faabb485263e5c0d245", async() => {
                BeginContext(4190, 14, true);
                WriteLiteral("Modify Account");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 116 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                                                          WriteLiteral(user.Id);

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
            BeginContext(4208, 36, true);
            WriteLiteral(" |\r\n                                ");
            EndContext();
            BeginContext(4244, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "63945556e8484cefb6423a4583e36c84", async() => {
                BeginContext(4289, 21, true);
                WriteLiteral("Disable this Customer");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 117 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                                                       WriteLiteral(user.Id);

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
            BeginContext(4314, 68, true);
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 120 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                    }
                }

#line default
#line hidden
            BeginContext(4424, 38, true);
            WriteLiteral("            </table>\r\n        </div>\r\n");
            EndContext();
#line 124 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
    }

#line default
#line hidden
            BeginContext(4471, 64, true);
            WriteLiteral("    <button type=\"submit\" class=\"btn btn-danger\">Save</button>\r\n");
            EndContext();
            BeginContext(4540, 76, false);
#line 127 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
Write(Html.ActionLink("Cancel", "Index", null, new { @class = "btn btn-success" }));

#line default
#line hidden
            EndContext();
#line 127 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/RoleAdmin/Edit.cshtml"
                                                                                 
}

#line default
#line hidden
            BeginContext(4621, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleEditModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

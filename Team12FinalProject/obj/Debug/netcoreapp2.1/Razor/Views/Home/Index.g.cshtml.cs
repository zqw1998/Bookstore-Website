#pragma checksum "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ca46eb3b9c4ac35dd25d650be88cdef3e8f19f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 2 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
using Team12FinalProject.Controllers;

#line default
#line hidden
#line 3 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
using Team12FinalProject.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ca46eb3b9c4ac35dd25d650be88cdef3e8f19f8", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Team12FinalProject.Models.Coupon>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
            BeginContext(164, 12, true);
            WriteLiteral("<h2>Welcome ");
            EndContext();
            BeginContext(177, 12, false);
#line 7 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
       Write(ViewBag.Name);

#line default
#line hidden
            EndContext();
            BeginContext(189, 10, true);
            WriteLiteral("!</h2>\r\n\r\n");
            EndContext();
            BeginContext(200, 84, false);
#line 9 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
Write(Html.ActionLink("Books", "Index", "Books", null, new { @class = "btn btn-primary" }));

#line default
#line hidden
            EndContext();
            BeginContext(284, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 10 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
 if (User.IsInRole("Customer"))
{
    

#line default
#line hidden
            BeginContext(327, 86, false);
#line 12 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
Write(Html.ActionLink("Orders", "Index", "Orders", null, new { @class = "btn btn-success" }));

#line default
#line hidden
            EndContext();
            BeginContext(420, 102, false);
#line 13 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
Write(Html.ActionLink("Shopping Cart", "ShoppingCart", "Orders", null, new { @class = "btn btn-secondary" }));

#line default
#line hidden
            EndContext();
#line 13 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
                                                                                                           
}

#line default
#line hidden
#line 15 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
 if (User.IsInRole("Manager") || User.IsInRole("Employee"))
{
    

#line default
#line hidden
            BeginContext(596, 97, false);
#line 17 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
Write(Html.ActionLink("Manage Users", "Index", "RoleAdmin", null, new { @class = "btn btn-secondary" }));

#line default
#line hidden
            EndContext();
            BeginContext(700, 100, false);
#line 18 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
Write(Html.ActionLink("Pending Reviews", "PendingIndex", "Reviews", null, new { @class = "btn btn-info" }));

#line default
#line hidden
            EndContext();
            BeginContext(807, 88, false);
#line 19 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
Write(Html.ActionLink("Shipping", "Index", "Shippings", null, new { @class = "btn btn-info" }));

#line default
#line hidden
            EndContext();
#line 19 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
                                                                                             
}

#line default
#line hidden
#line 21 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
 if (User.IsInRole("Manager"))
{
    

#line default
#line hidden
            BeginContext(940, 86, false);
#line 23 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
Write(Html.ActionLink("Orders", "Index", "Orders", null, new { @class = "btn btn-success" }));

#line default
#line hidden
            EndContext();
            BeginContext(1033, 97, false);
#line 24 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
Write(Html.ActionLink("Procurement", "Index", "Procurements", null, new { @class = "btn btn-warning" }));

#line default
#line hidden
            EndContext();
            BeginContext(1137, 87, false);
#line 25 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
Write(Html.ActionLink("Coupons", "Index", "Coupons", null, new { @class = "btn btn-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(1231, 105, false);
#line 26 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
Write(Html.ActionLink("Approved Reviews", "ApprovedIndex", "Reviews", null, new { @class = "btn btn-primary" }));

#line default
#line hidden
            EndContext();
            BeginContext(1343, 84, false);
#line 27 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
Write(Html.ActionLink("Report", "Index", "Reports", null, new { @class = "btn btn-dark" }));

#line default
#line hidden
            EndContext();
#line 27 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
                                                                                         
}

#line default
#line hidden
#line 29 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
 if (User.IsInRole("Customer"))
{



#line default
#line hidden
            BeginContext(1472, 137, true);
            WriteLiteral("    <h4>Current Promotions</h4>\r\n    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1610, 46, false);
#line 38 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
               Write(Html.DisplayNameFor(model => model.CouponCode));

#line default
#line hidden
            EndContext();
            BeginContext(1656, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1724, 42, false);
#line 41 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(1766, 183, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    CouponType\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 50 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
             foreach (Coupon item in Model)
            {

#line default
#line hidden
            BeginContext(2009, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2082, 45, false);
#line 54 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.CouponCode));

#line default
#line hidden
            EndContext();
            BeginContext(2127, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2207, 41, false);
#line 57 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
            EndContext();
            BeginContext(2248, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2328, 45, false);
#line 60 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.CouponType));

#line default
#line hidden
            EndContext();
            BeginContext(2373, 56, true);
            WriteLiteral("\r\n                    </td>\r\n\r\n\r\n                </tr>\r\n");
            EndContext();
#line 65 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"
            }

#line default
#line hidden
            BeginContext(2444, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 68 "/Users/z/Downloads/Team12FinalProject13 3/Team12FinalProject/Team12FinalProject/Views/Home/Index.cshtml"

}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Team12FinalProject.Models.Coupon>> Html { get; private set; }
    }
}
#pragma warning restore 1591
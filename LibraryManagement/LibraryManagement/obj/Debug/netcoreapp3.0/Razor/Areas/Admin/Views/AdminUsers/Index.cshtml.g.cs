#pragma checksum "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4abd0a220ce7b915344d64d1808488afb7524482"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminUsers_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminUsers/Index.cshtml")]
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
#line 1 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\_ViewImports.cshtml"
using LibraryManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\_ViewImports.cshtml"
using LibraryManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4abd0a220ce7b915344d64d1808488afb7524482", @"/Areas/Admin/Views/AdminUsers/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41be026932054997fef355abeae0af2af577cb29", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_AdminUsers_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LibraryManagement.Models.ApplicationUser>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Identity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Account/Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
#nullable restore
#line 2 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<br />\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-6\">\r\n        <h2 class=\"text-info\"> Admin Users List</h2>\r\n    </div>\r\n    <div class=\"col-6 text-right\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4abd0a220ce7b915344d64d1808488afb75244824688", async() => {
                WriteLiteral("<i class=\"fas fa-plus\"></i>&nbsp; New Admin User");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<br />\r\n<div>\r\n    <table class=\"table table-striped border\">\r\n        <tr class=\"table-info\">\r\n            <th>\r\n                ");
#nullable restore
#line 23 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 26 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.IsSuperAdmin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Disabled\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n\r\n");
#nullable restore
#line 40 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
      foreach (var item in Model)
      {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
           Write(Html.DisplayFor(m => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 47 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
           Write(Html.DisplayFor(m => item.IsSuperAdmin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 50 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
           Write(Html.DisplayFor(m => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 53 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
           Write(Html.DisplayFor(m => item.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 56 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
                 if (item.LockoutEnd != null && item.LockoutEnd > DateTime.Now)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <label>Disabled</label>\r\n");
#nullable restore
#line 59 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n            <td>\r\n");
#nullable restore
#line 62 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
                 if (item.LockoutEnd == null || item.LockoutEnd < DateTime.Now)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a type=\"button\" class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 1794, "\"", 1850, 1);
#nullable restore
#line 64 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
WriteAttributeValue("", 1801, Url.Action("Edit/" + item.Id).Replace("%2F","/"), 1801, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <i class=\"fas fa-edit\"></i>\r\n                    </a>\r\n                    <a type=\"button\" class=\"btn btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 1992, "\"", 2048, 1);
#nullable restore
#line 67 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
WriteAttributeValue("", 1999, Url.Action("Delete/"+item.Id).Replace("%2F","/"), 1999, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <i class=\"fas fa-trash-alt\"></i>\r\n                    </a>\r\n");
#nullable restore
#line 70 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 74 "F:\Lập trình web\github\WebProject\LibraryManagement\LibraryManagement\Areas\Admin\Views\AdminUsers\Index.cshtml"

      }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LibraryManagement.Models.ApplicationUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591

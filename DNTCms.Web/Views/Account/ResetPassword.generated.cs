﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Views\Account\ResetPassword.cshtml"
    using CaptchaMvc.HtmlHelpers;
    
    #line default
    #line hidden
    using DNTCms.Common.Constants;
    using DNTCms.Common.Constants.HomeController;
    using DNTCms.Common.Extentions;
    
    #line 2 "..\..\Views\Account\ResetPassword.cshtml"
    using DNTCms.Common.HtmlHelpers;
    
    #line default
    #line hidden
    using DNTCms.Common.OpenGraph;
    using DNTCms.Common.OpenGraph.ObjectTypes;
    using DNTCms.Common.Referrer;
    using DNTCms.Common.Twitter;
    using MvcSiteMapProvider.Web.Html;
    using MvcSiteMapProvider.Web.Html.Models;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Account/ResetPassword.cshtml")]
    public partial class _Views_Account_ResetPassword_cshtml : System.Web.Mvc.WebViewPage<DNTCms.ViewModel.Account.ResetPasswordViewModel>
    {
        public _Views_Account_ResetPassword_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Account\ResetPassword.cshtml"
  


            
            #line default
            #line hidden
WriteLiteral("\r\n<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n\r\n");

            
            #line 9 "..\..\Views\Account\ResetPassword.cshtml"
    
            
            #line default
            #line hidden
            
            #line 9 "..\..\Views\Account\ResetPassword.cshtml"
     using (Html.BeginForm(MVC.Account.ActionNames.ResetPassword, MVC.Account.Name, FormMethod.Post,
        new { @class = "form-horizontal", role = "form", autocomplate = "off", id = "resetPasswordForm" }))
    {
        
            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Account\ResetPassword.cshtml"
   Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 12 "..\..\Views\Account\ResetPassword.cshtml"
                                
        
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Account\ResetPassword.cshtml"
   Write(Html.HiddenFor(model => model.Code));

            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Account\ResetPassword.cshtml"
                                            

            
            #line default
            #line hidden
WriteLiteral("        <div");

WriteLiteral(" class=\"col-md-10 col-md-offset-1\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel  panel-default\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"panel-heading\"");

WriteLiteral(">\r\n                    <strong> ورود به حساب کاربری</strong>\r\n                </d" +
"iv>\r\n                <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 21 "..\..\Views\Account\ResetPassword.cshtml"
                   Write(Html.LabelFor(m => m.Email, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 23 "..\..\Views\Account\ResetPassword.cshtml"
                       Write(Html.NoAutoCompleteTextBoxForLtr(m => m.Email));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 24 "..\..\Views\Account\ResetPassword.cshtml"
                       Write(Html.ValidationMessageFor(m => m.Email, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 28 "..\..\Views\Account\ResetPassword.cshtml"
                   Write(Html.LabelFor(m => m.Password, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 30 "..\..\Views\Account\ResetPassword.cshtml"
                       Write(Html.FormControlPasswordFor(m => m.Password));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 31 "..\..\Views\Account\ResetPassword.cshtml"
                       Write(Html.ValidationMessageFor(m => m.Password, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 35 "..\..\Views\Account\ResetPassword.cshtml"
                   Write(Html.LabelFor(m => m.ConfirmPassword, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

            
            #line 37 "..\..\Views\Account\ResetPassword.cshtml"
                       Write(Html.FormControlPasswordFor(m => m.ConfirmPassword));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                            ");

            
            #line 38 "..\..\Views\Account\ResetPassword.cshtml"
                       Write(Html.ValidationMessageFor(m => m.ConfirmPassword, "", new { @class = "text-danger" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                   " +
" <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 42 "..\..\Views\Account\ResetPassword.cshtml"
                   Write(Html.MathCaptcha(MVC.Shared.Views._CaptchaPartial));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"panel-footer\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"col-md-12\"");

WriteLiteral(">\r\n                            <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" autocomplete=\"off\"");

WriteLiteral(" onclick=\" AjaxForm.CustomSubmit(this, \'resetPasswordForm\')\"");

WriteLiteral(" data-loading-text=\"در حال ارسال اطلاعات\"");

WriteLiteral(" class=\"btn btn-success btn-block\"");

WriteLiteral(">\r\n                                تغییر کلمه عبور\r\n                            <" +
"/button>\r\n                        </div>\r\n\r\n                    </div>\r\n        " +
"        </div>\r\n            </div>\r\n        </div>\r\n");

            
            #line 57 "..\..\Views\Account\ResetPassword.cshtml"
    }

            
            #line default
            #line hidden
WriteLiteral("\r\n</div>\r\n\r\n");

DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 62 "..\..\Views\Account\ResetPassword.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

WriteLiteral("\r\n\r\n");

        }
    }
}
#pragma warning restore 1591

﻿using System.Linq;
using System.Web.Mvc.Html;
using System.Web.WebPages;
using MvcSiteMapProvider.Web.Html.Models;

#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DNTCms.Web.Views.Shared.DisplayTemplates
{
    #line 2 "..\..\Views\Shared\DisplayTemplates\SiteMapPath.cshtml"
#line default
    #line hidden
#line 3 "..\..\Views\Shared\DisplayTemplates\SiteMapPath.cshtml"
#line default
    #line hidden

    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [PageVirtualPath("~/Views/Shared/DisplayTemplates/SiteMapPath.cshtml")]
    public partial class _Views_Shared_DisplayTemplates_SiteMapPath_cshtml_ : System.Web.Mvc.WebViewPage<SiteMapPathHelperModel>
    {
        public _Views_Shared_DisplayTemplates_SiteMapPath_cshtml_()
        {
        }
        public override void Execute()
        {
WriteLiteral("\n<ol");

WriteLiteral(" class=\"breadcrumb\"");

WriteLiteral(">\n");

            
            #line 6 "..\..\Views\Shared\DisplayTemplates\SiteMapPath.cshtml"
    
            
            #line default
            #line hidden
            
            #line 6 "..\..\Views\Shared\DisplayTemplates\SiteMapPath.cshtml"
     foreach (var node in Model)
    {
        if (node == Model.Last())
        {

            
            #line default
            #line hidden
WriteLiteral("            <li");

WriteLiteral(" class=\"active\"");

WriteLiteral(">");

            
            #line 10 "..\..\Views\Shared\DisplayTemplates\SiteMapPath.cshtml"
                          Write(Html.DisplayFor(m => node));

            
            #line default
            #line hidden
WriteLiteral("</li>\n");

            
            #line 11 "..\..\Views\Shared\DisplayTemplates\SiteMapPath.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral("            <li>\n");

WriteLiteral("                ");

            
            #line 15 "..\..\Views\Shared\DisplayTemplates\SiteMapPath.cshtml"
           Write(Html.DisplayFor(m => node));

            
            #line default
            #line hidden
WriteLiteral("\n            </li>\n");

            
            #line 17 "..\..\Views\Shared\DisplayTemplates\SiteMapPath.cshtml"
        }

    }

            
            #line default
            #line hidden
WriteLiteral("\n</ol>");

        }
    }
}
#pragma warning restore 1591
﻿using System.Web.WebPages;
using DNTCms.Common.Noty;
using DNTCms.Web.RazorHelpers;

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

namespace DNTCms.Web.Views.Shared
{
    #line 2 "..\..\Views\Shared\_Noty.cshtml"
#line default
    #line hidden
#line 3 "..\..\Views\Shared\_Noty.cshtml"
#line default
    #line hidden

    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [PageVirtualPath("~/Views/Shared/_Noty.cshtml")]
    public partial class _Views_Shared__Noty_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__Noty_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("\r\n");

            
            #line 5 "..\..\Views\Shared\_Noty.cshtml"
 if (TempData.ContainsKey(Noty.TempDataKey))
{
    var noty = TempData[Noty.TempDataKey] as Noty;
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\Shared\_Noty.cshtml"
Write(NotyBuilder.ShowNotyMessages(noty));

            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\Shared\_Noty.cshtml"
                                       ;
}

            
            #line default
            #line hidden
WriteLiteral("\r\n");

        }
    }
}
#pragma warning restore 1591

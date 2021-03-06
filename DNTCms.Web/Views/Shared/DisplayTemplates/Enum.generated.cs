﻿using System;
using System.Linq;
using System.Web.Mvc.Html;
using System.Web.WebPages;

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
    
    #line 1 "..\..\Views\Shared\DisplayTemplates\Enum.cshtml"

    #line default
    #line hidden
#line 2 "..\..\Views\Shared\DisplayTemplates\Enum.cshtml"
#line default
    #line hidden

    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [PageVirtualPath("~/Views/Shared/DisplayTemplates/Enum.cshtml")]
    public partial class _Views_Shared_DisplayTemplates_Enum_cshtml_ : System.Web.Mvc.WebViewPage<System.Enum>
    {
        public _Views_Shared_DisplayTemplates_Enum_cshtml_()
        {
        }
        public override void Execute()
        {
            
            #line 5 "..\..\Views\Shared\DisplayTemplates\Enum.cshtml"
 if (EnumHelper.IsValidForEnumHelper(ViewData.ModelMetadata))
{
    // Display Enum using same names (from [Display] attributes) as in editors
    string displayName = null;
    foreach (var item in EnumHelper.GetSelectList(ViewData.ModelMetadata, Model).Where(item => item.Selected))
    {
        displayName = item.Text ?? item.Value;
    }

    // Handle the unexpected case that nothing is selected
    if (String.IsNullOrEmpty(displayName))
    {
        displayName = Model == null ? String.Empty : Model.ToString();
    }

    
            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Shared\DisplayTemplates\Enum.cshtml"
Write(Html.DisplayTextFor(model => displayName));

            
            #line default
            #line hidden
            
            #line 20 "..\..\Views\Shared\DisplayTemplates\Enum.cshtml"
                                              
}
else
{
    // This Enum type is not supported.  Fall back to the text.
    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Shared\DisplayTemplates\Enum.cshtml"
Write(Html.DisplayTextFor(model => model));

            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Shared\DisplayTemplates\Enum.cshtml"
                                        
}
            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591

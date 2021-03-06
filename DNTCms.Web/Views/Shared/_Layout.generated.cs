﻿using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Optimization;
using System.Web.WebPages;
using DNTCms.Common.Constants;
using DNTCms.Common.Extentions;
using DNTCms.Common.OpenGraph;
using DNTCms.Common.OpenGraph.ObjectTypes;
using DNTCms.Common.Referrer;
using DNTCms.Common.Twitter;

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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [PageVirtualPath("~/Views/Shared/_Layout.cshtml")]
    public partial class _Views_Shared__Layout_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_Shared__Layout_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n<!DOCTYPE html>\r\n");

WriteLiteral("\r\n");

WriteLiteral("\r\n<html");

WriteLiteral(" class=\"no-js\"");

WriteLiteral(" lang=\"fa\"");

WriteLiteral(" >\r\n<head ");

            
            #line 6 "..\..\Views\Shared\_Layout.cshtml"
  Write(ViewBag.OpenGraph == null ? null : Html.OpenGraphNamespace((OpenGraphMetadata)ViewBag.OpenGraph));

            
            #line default
            #line hidden
WriteLiteral(">\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" http-equiv=\"content-language\"");

WriteLiteral(" content=\"fa\"");

WriteLiteral(" />\r\n    ");

WriteLiteral("\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1\"");

WriteLiteral(">\r\n    <meta");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(@">
    
    <!--[if lt IE 9]>
        <script src=""https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js""></script>
        <script src=""https://oss.maxcdn.com/respond/1.4.2/respond.min.js""></script>
    <![endif]-->
    <!--[if lte IE 6]>
        <script src=""/Scripts/warning.js""></script>
        <script>window.onload = function() { e(""js/ie6/""); }</script><![endif]-->
    <!--noscript-->
    <noscript>
        <meta");

WriteLiteral(" http-equiv=\"refresh\"");

WriteLiteral(" content=\"0;url=/NoScript.html\"");

WriteLiteral(">\r\n    </noscript>\r\n\r\n\r\n    ");

WriteLiteral("\r\n    <title>");

            
            #line 30 "..\..\Views\Shared\_Layout.cshtml"
      Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(" - ");

            
            #line 30 "..\..\Views\Shared\_Layout.cshtml"
                       Write(Application.Name);

            
            #line default
            #line hidden
WriteLiteral("</title>\r\n\r\n\r\n    ");

WriteLiteral("\r\n\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon\"");

WriteLiteral(" sizes=\"57x57\"");

WriteLiteral(" href=\"/content/icons/apple-touch-icon-57x57.png\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon\"");

WriteLiteral(" sizes=\"60x60\"");

WriteLiteral(" href=\"/content/icons/apple-touch-icon-60x60.png\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon\"");

WriteLiteral(" sizes=\"72x72\"");

WriteLiteral(" href=\"/content/icons/apple-touch-icon-72x72.png\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon\"");

WriteLiteral(" sizes=\"76x76\"");

WriteLiteral(" href=\"/content/icons/apple-touch-icon-76x76.png\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon\"");

WriteLiteral(" sizes=\"114x114\"");

WriteLiteral(" href=\"/content/icons/apple-touch-icon-114x114.png\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon\"");

WriteLiteral(" sizes=\"120x120\"");

WriteLiteral(" href=\"/content/icons/apple-touch-icon-120x120.png\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon\"");

WriteLiteral(" sizes=\"144x144\"");

WriteLiteral(" href=\"/content/icons/apple-touch-icon-144x144.png\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon\"");

WriteLiteral(" sizes=\"152x152\"");

WriteLiteral(" href=\"/content/icons/apple-touch-icon-152x152.png\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"apple-touch-icon\"");

WriteLiteral(" sizes=\"180x180\"");

WriteLiteral(" href=\"/content/icons/apple-touch-icon-180x180.png\"");

WriteLiteral(">\r\n\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n\r\n    ");

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"icon\"");

WriteLiteral(" type=\"image/png\"");

WriteLiteral(" href=\"/content/icons/favicon-32x32.png\"");

WriteLiteral(" sizes=\"32x32\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"icon\"");

WriteLiteral(" type=\"image/png\"");

WriteLiteral(" href=\"/content/icons/favicon-192x192.png\"");

WriteLiteral(" sizes=\"192x192\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"icon\"");

WriteLiteral(" type=\"image/png\"");

WriteLiteral(" href=\"/content/icons/favicon-96x96.png\"");

WriteLiteral(" sizes=\"96x96\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"icon\"");

WriteLiteral(" type=\"image/png\"");

WriteLiteral(" href=\"/content/icons/favicon-16x16.png\"");

WriteLiteral(" sizes=\"16x16\"");

WriteLiteral(">\r\n\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n\r\n    ");

WriteLiteral("\r\n\r\n    ");

WriteLiteral("\r\n    <meta");

WriteLiteral(" name=\"theme-color\"");

WriteLiteral(" content=\"#1E1E1E\"");

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n\r\n    ");

WriteLiteral("\r\n\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n    ");

WriteLiteral("\r\n\r\n\r\n    ");

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 124 "..\..\Views\Shared\_Layout.cshtml"
Write(Styles.Render("~/Content/css"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    <meta");

WriteLiteral(" name=\"x-font-awesome-stylesheet-fallback-test\"");

WriteLiteral(" class=\"fa\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 126 "..\..\Views\Shared\_Layout.cshtml"
Write(Styles.Render("~/Content/fa"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 127 "..\..\Views\Shared\_Layout.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/bundles/modernizr"));

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n    ");

WriteLiteral("\r\n    <meta");

WriteLiteral(" name=\"description\"");

WriteAttribute("content", Tuple.Create(" content=\"", 9793), Tuple.Create("\"", 9823)
            
            #line 131 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 9803), Tuple.Create<System.Object, System.Int32>(ViewBag.Description
            
            #line default
            #line hidden
, 9803), false)
);

WriteLiteral(">\r\n    ");

WriteLiteral("\r\n");

            
            #line 133 "..\..\Views\Shared\_Layout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 133 "..\..\Views\Shared\_Layout.cshtml"
     if (ViewBag.Author != null)
    {

            
            #line default
            #line hidden
WriteLiteral("        <meta");

WriteLiteral(" name=\"author\"");

WriteAttribute("content", Tuple.Create(" content=\"", 9974), Tuple.Create("\"", 9999)
            
            #line 135 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 9984), Tuple.Create<System.Object, System.Int32>(ViewBag.Author
            
            #line default
            #line hidden
, 9984), false)
);

WriteLiteral(">\r\n");

            
            #line 136 "..\..\Views\Shared\_Layout.cshtml"
    }
    
            
            #line default
            #line hidden
            
            #line 137 "..\..\Views\Shared\_Layout.cshtml"
                                        

            
            #line default
            #line hidden
WriteLiteral("    ");

            
            #line 138 "..\..\Views\Shared\_Layout.cshtml"
     if (ViewBag.TwitterCard != null)
    {
        
            
            #line default
            #line hidden
            
            #line 140 "..\..\Views\Shared\_Layout.cshtml"
   Write(Html.TwitterCard((TwitterCard)ViewBag.TwitterCard));

            
            #line default
            #line hidden
            
            #line 140 "..\..\Views\Shared\_Layout.cshtml"
                                                           ;
    }
    
            
            #line default
            #line hidden
            
            #line 142 "..\..\Views\Shared\_Layout.cshtml"
                                               

            
            #line default
            #line hidden
WriteLiteral("    ");

            
            #line 143 "..\..\Views\Shared\_Layout.cshtml"
     if (ViewBag.OpenGraph != null)
    {
        
            
            #line default
            #line hidden
            
            #line 145 "..\..\Views\Shared\_Layout.cshtml"
   Write(Html.OpenGraph((OpenGraphMetadata)ViewBag.OpenGraph));

            
            #line default
            #line hidden
            
            #line 145 "..\..\Views\Shared\_Layout.cshtml"
                                                             ;
    }
    
            
            #line default
            #line hidden
            
            #line 147 "..\..\Views\Shared\_Layout.cshtml"
                                                             

            
            #line default
            #line hidden
WriteLiteral("    ");

            
            #line 148 "..\..\Views\Shared\_Layout.cshtml"
     if (ViewBag.ReferrerMode != null)
    {
        
            
            #line default
            #line hidden
            
            #line 150 "..\..\Views\Shared\_Layout.cshtml"
   Write(Html.ReferrerMeta((ReferrerMode)ViewBag.ReferrerMode));

            
            #line default
            #line hidden
            
            #line 150 "..\..\Views\Shared\_Layout.cshtml"
                                                              
    }


    
            
            #line default
            #line hidden
            
            #line 157 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                  
    
            
            #line default
            #line hidden
            
            #line 158 "..\..\Views\Shared\_Layout.cshtml"
                                      


    
            
            #line default
            #line hidden
            
            #line 161 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                   
    
            
            #line default
            #line hidden
            
            #line 162 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                                                           


    
            
            #line default
            #line hidden
            
            #line 165 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                                                                   
    
            
            #line default
            #line hidden
            
            #line 166 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                                                                                                       


    
            
            #line default
            #line hidden
            
            #line 169 "..\..\Views\Shared\_Layout.cshtml"
                                                                      

            
            #line default
            #line hidden
WriteLiteral("    ");

            
            #line 170 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("head", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n</head>\r\n<body>\r\n    ");

WriteLiteral("\r\n    <a");

WriteLiteral(" href=\"#main\"");

WriteLiteral(" class=\"sr-only sr-only-focusable\"");

WriteLiteral(">Skip to main content</a>\r\n    ");

WriteLiteral("\r\n    <nav");

WriteLiteral(" class=\"navbar navbar-inverse navbar-fixed-top\"");

WriteLiteral(" role=\"navigation\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"navbar-header\"");

WriteLiteral(">\r\n                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"navbar-toggle\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-target=\".navbar-collapse\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                    <span");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                    <span");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                </button>\r\n                <a");

WriteLiteral(" class=\"navbar-brand\"");

WriteLiteral(" role=\"banner\"");

WriteAttribute("href", Tuple.Create(" href=\"", 12573), Tuple.Create("\"", 12609)
            
            #line 185 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 12580), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Home.Index())
            
            #line default
            #line hidden
, 12580), false)
);

WriteLiteral("><span");

WriteLiteral(" class=\"fa fa-star\"");

WriteLiteral("></span> ");

            
            #line 185 "..\..\Views\Shared\_Layout.cshtml"
                                                                                                                       Write(Application.Name);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"navbar-collapse collapse\"");

WriteLiteral(">\r\n                <ul");

WriteLiteral(" class=\"nav navbar-nav\"");

WriteLiteral(">\r\n                    <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 12810), Tuple.Create("\"", 12846)
            
            #line 189 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 12817), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Home.About())
            
            #line default
            #line hidden
, 12817), false)
);

WriteLiteral("><span");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" class=\"fa fa-users\"");

WriteLiteral("></span> About</a></li>\r\n                    <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 12943), Tuple.Create("\"", 12981)
            
            #line 190 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 12950), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Home.Contact())
            
            #line default
            #line hidden
, 12950), false)
);

WriteLiteral("><span");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" class=\"fa fa-phone\"");

WriteLiteral("></span> Contact</a></li>\r\n                    <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 13080), Tuple.Create("\"", 13116)
            
            #line 191 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 13087), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Home.Index())
            
            #line default
            #line hidden
, 13087), false)
);

WriteLiteral("><span");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" class=\"fa fa-rss\"");

WriteLiteral("></span> RSS</a></li>\r\n");

            
            #line 192 "..\..\Views\Shared\_Layout.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 192 "..\..\Views\Shared\_Layout.cshtml"
                     if (HttpContext.Current.IsDebuggingEnabled)
                    {
                        // if <compilation debug="true"> is set in Web.config.

            
            #line default
            #line hidden
WriteLiteral("                        <li");

WriteLiteral(" class=\"dropdown\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" role=\"button\"");

WriteLiteral(" aria-expanded=\"false\"");

WriteLiteral(" href=\"#\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral("><span");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" class=\"fa fa-cogs\"");

WriteLiteral("></span> Debug <span");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span></a>\r\n                            <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(" role=\"menu\"");

WriteLiteral(">\r\n                                <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 13738), Tuple.Create("\"", 13798)
, Tuple.Create(Tuple.Create("", 13745), Tuple.Create("/", 13745), true)
            
            #line 198 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 13746), Tuple.Create<System.Object, System.Int32>(ConfigurationManager.AppSettings["elmah.mvc.route"]
            
            #line default
            #line hidden
, 13746), false)
);

WriteLiteral("><span");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" class=\"fa fa-life-ring\"");

WriteLiteral("></span> Elmah</a></li>\r\n                                <li><a");

WriteLiteral(" href=\"/glimpse.axd\"");

WriteLiteral("><span");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" class=\"fa fa-line-chart\"");

WriteLiteral("></span> Glimpse</a></li>\r\n                                <li><a");

WriteLiteral(" href=\"/trace.axd\"");

WriteLiteral("><span");

WriteLiteral(" aria-hidden=\"true\"");

WriteLiteral(" class=\"fa fa-heart\"");

WriteLiteral("></span> Tracing</a></li>\r\n                            </ul>\r\n                   " +
"     </li>\r\n");

            
            #line 203 "..\..\Views\Shared\_Layout.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </ul>\r\n                <form");

WriteAttribute("action", Tuple.Create(" action=\"", 14269), Tuple.Create("\"", 14307)
            
            #line 205 "..\..\Views\Shared\_Layout.cshtml"
, Tuple.Create(Tuple.Create("", 14278), Tuple.Create<System.Object, System.Int32>(Url.Action(MVC.Home.Index())
            
            #line default
            #line hidden
, 14278), false)
);

WriteLiteral(" class=\"navbar-form navbar-right\"");

WriteLiteral(" method=\"get\"");

WriteLiteral(" role=\"search\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" aria-label=\"Search\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" maxlength=\"2048\"");

WriteLiteral(" name=\"query\"");

WriteLiteral(" placeholder=\"Search\"");

WriteLiteral(" title=\"Search\"");

WriteLiteral(" type=\"text\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"input-group-btn\"");

WriteLiteral(">\r\n                            <button");

WriteLiteral(" aria-label=\"Search\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" type=\"submit\"");

WriteLiteral("><span");

WriteLiteral(" class=\"fa fa-search\"");

WriteLiteral("></span></button>\r\n                        </div>\r\n                    </div>\r\n  " +
"              </form>\r\n            </div>\r\n        </div>\r\n    </nav>\r\n    ");

WriteLiteral("\r\n    <div");

WriteLiteral(" id=\"main\"");

WriteLiteral(" class=\"container body-content\"");

WriteLiteral(" role=\"main\"");

WriteLiteral(@">
        <!--[if lt IE 8]>
            <div class=""alert alert-warning"" role=""alert"">
                <p>You are using an outdated browser. Please <a class=""alert-link"" href=""http://browsehappy.com/"">upgrade your browser</a> to improve your experience.</p>
            </div>
        <![endif]-->
");

WriteLiteral("        ");

            
            #line 223 "..\..\Views\Shared\_Layout.cshtml"
   Write(RenderBody());

            
            #line default
            #line hidden
WriteLiteral("\r\n        <hr>\r\n        <footer");

WriteLiteral(" role=\"contentinfo\"");

WriteLiteral(">\r\n            <p>&copy; ");

            
            #line 226 "..\..\Views\Shared\_Layout.cshtml"
                 Write(DateTime.Now.Year);

            
            #line default
            #line hidden
WriteLiteral(" - ");

            
            #line 226 "..\..\Views\Shared\_Layout.cshtml"
                                      Write(Application.Name);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n        </footer>\r\n    </div>\r\n\r\n");

WriteLiteral("    ");

            
            #line 230 "..\..\Views\Shared\_Layout.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/bundles/jquery"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 231 "..\..\Views\Shared\_Layout.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 232 "..\..\Views\Shared\_Layout.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/bundles/jqueryvalunobtrusive"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 233 "..\..\Views\Shared\_Layout.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/bundles/bootstrap"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 234 "..\..\Views\Shared\_Layout.cshtml"
Write(System.Web.Optimization.Scripts.Render("~/bundles/site"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 235 "..\..\Views\Shared\_Layout.cshtml"
Write(RenderSection("scripts", required: false));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 236 "..\..\Views\Shared\_Layout.cshtml"
    
            
            #line default
            #line hidden
            
            #line 236 "..\..\Views\Shared\_Layout.cshtml"
      Html.RenderPartial(MVC.Shared.Views._Noty);
            
            #line default
            #line hidden
WriteLiteral("\r\n</body>\r\n</html>\r\n\r\n\r\n\r\n\r\n");

        }
    }
}
#pragma warning restore 1591

using System.Collections.Generic;
using System.Web.Optimization;
using DNTCms.Common.Constants;

namespace DNTCms.Web
{
    public class BundleConfig
    {
        #region RegisterBundles
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Enable Optimizations
            // Set EnableOptimizations to false for debugging. For more information,
            // Web.config file system.web/compilation[debug=true]
            // OR
            // BundleTable.EnableOptimizations = true;

            // Enable CDN usage. 
            // Note: that you can choose to remove the CDN if you are developing an intranet application.
            // Note: We are using Google's CDN where possible and then Microsoft if not available for better 
            //       performance (Google is more likely to have been cached by the users browser).
            // Note: that protocol (http:) is omitted from the CDN URL on purpose to allow the browser to choose the protocol.

            BundleTable.EnableOptimizations = true;
            bundles.UseCdn = true;
            AddCss(bundles);
            AddJavaScript(bundles);
        }

        #endregion

        #region AddCss
        private static void AddCss(BundleCollection bundles)
        {
            // Bootstrap - Twitter Bootstrap CSS (http://getbootstrap.com/).
            // Site - Your custom site CSS.
            // Note: No CDN support has been added here. Most likely you will want to customize your copy of bootstrap.
            bundles.Add(new StyleBundle(
                "~/Admin/css")
                .Include("~/Content/bootstrap/site.min.css")
                .Include("~/Content/admin/admin.min.css"));

            bundles.Add(new StyleBundle(
              "~/Content/css")
              .Include("~/Content/bootstrap/site.min.css")
              .Include("~/Content/bootflat/bootflat-rtl.css"));
            
            // Font Awesome - Icons using font (http://fortawesome.github.io/Font-Awesome/).
            bundles.Add(new StyleBundle(
                "~/Content/fa",
                ContentDeliveryNetwork.MaxCdn.FontAwesomeUrl)
                .Include("~/Content/fontawesome/site.min.css"));
        }
        #endregion

        #region AddJavaScript
        private static void AddJavaScript(BundleCollection bundles)
        {
            var jqueryBundle = new ScriptBundle("~/bundles/jquery", ContentDeliveryNetwork.Google.JQueryUrl)
                .Include("~/Scripts/jquery-{version}.min.js");
            bundles.Add(jqueryBundle);

            // jQuery Validate - Client side JavaScript form validation (http://jqueryvalidation.org/).
            var jqueryValidateBundle = new ScriptBundle(
                "~/bundles/jqueryval",
                ContentDeliveryNetwork.Microsoft.JQueryValidateUrl)
                .Include("~/Scripts/jquery.validate*");
            bundles.Add(jqueryValidateBundle);

            // Microsoft jQuery Validate Unobtrusive - Validation using HTML data- attributes 
            // http://stackoverflow.com/questions/11534910/what-is-jquery-unobtrusive-validation
            var jqueryValidateUnobtrusiveBundle = new ScriptBundle(
                "~/bundles/jqueryvalunobtrusive",
                ContentDeliveryNetwork.Microsoft.JQueryValidateUnobtrusiveUrl)
                .Include("~/Scripts/jquery.validate*");
            bundles.Add(jqueryValidateUnobtrusiveBundle);

            // Modernizr - Allows you to check if a particular API is available in the browser (http://modernizr.com).
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            // Note: The current version of Modernizr does not support Content Security Policy (CSP) (See FilterConfig).
            // See here for details: https://github.com/Modernizr/Modernizr/pull/1263 and 
            // http://stackoverflow.com/questions/26532234/modernizr-causes-content-security-policy-csp-violation-errors
            var modernizrBundle = new ScriptBundle(
                "~/bundles/modernizr",
                ContentDeliveryNetwork.Microsoft.ModernizrUrl)
                .Include("~/Scripts/modernizr-*");
            bundles.Add(modernizrBundle);

            // Bootstrap - Twitter Bootstrap JavaScript (http://getbootstrap.com/).
            var bootstrapBundle = new ScriptBundle(
                "~/bundles/bootstrap",
                ContentDeliveryNetwork.Microsoft.BootstrapUrl)
                .Include("~/Scripts/bootstrap.min.js");
            bundles.Add(bootstrapBundle);

            // Script bundle for the site. The fall-back scripts are for when a CDN fails, in this case we load a local
            // copy of the script instead.
            var failoverCoreBundle = new ScriptBundle("~/bundles/site")
                .Include("~/Scripts/Fallback/styles.min.js")
                .Include("~/Scripts/Fallback/scripts.min.js")
                .Include("~/Scripts/jqueryval-default.min.js")
                .Include("~/Scripts/site.min.js");
            failoverCoreBundle.Orderer = new NonOrderingBundleOrderer();
            bundles.Add(failoverCoreBundle);

            var unobtrusiveAjaxBundle = new ScriptBundle("~/bundles/ajax",
                ContentDeliveryNetwork.Microsoft.JQueryUnobtrusiveAjaxUrl
                ).Include("~/Scripts/jquery.unobtrusive-ajax.min.js");
            bundles.Add(unobtrusiveAjaxBundle);


        }
        #endregion
    }

    #region NonOrderingBundleOrderer
    class NonOrderingBundleOrderer : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
    #endregion

}

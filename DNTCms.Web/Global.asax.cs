using System;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DNTCms.Common.Extentions;
using DNTCms.ServiceLayer.Contracts.Common;
using DNTCms.Web.IocConfig;
using Elmah;
using NWebsec.Csp;
using StructureMap.Web.Pipeline;

namespace DNTCms.Web
{
    public class MvcApplication : HttpApplication
    {

        #region Application_Start
        protected void Application_Start()
        {
            try
            {
               
                ConfigureAntiForgeryTokens();

                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RoutingConfig.RegisterRoutes(RouteTable.Routes);
                AreaRegistration.RegisterAllAreas();
                WebApiConfig.Register(GlobalConfiguration.Configuration);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                ApplicationStart.Config();
            }
            catch (Exception)
            {
                HttpRuntime.UnloadAppDomain(); // سبب ری استارت برنامه و آغاز مجدد آن با درخواست بعدی می‌شود
                throw;
            }

        }
        #endregion

        #region Application_EndRequest
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            try
            {
                foreach (var task in ProjectObjectFactory.Container.GetAllInstances<IRunAfterEachRequest>())
                {
                    task.Execute();
                }
            }
            catch (Exception)
            {
                HttpContextLifecycle.DisposeAndClearAll();
            }
          
        }
        #endregion

        #region Application_BeginRequest
        private void Application_BeginRequest(object sender, EventArgs e)
        {
            foreach (var task in ProjectObjectFactory.Container.GetAllInstances<IRunOnEachRequest>())
            {
                task.Execute();
            }

        }
        #endregion

        #region ShouldIgnoreRequest
        private bool ShouldIgnoreRequest()
        {
            string[] reservedPath =
              {
                  "/__browserLink",
                  "/Scripts",
                  "/Content"
              };

            var rawUrl = Context.Request.RawUrl;
            if (reservedPath.Any(path => rawUrl.StartsWith(path, StringComparison.OrdinalIgnoreCase)))
            {
                return true;
            }

            return BundleTable.Bundles.Select(bundle => bundle.Path.TrimStart('~'))
                      .Any(bundlePath => rawUrl.StartsWith(bundlePath, StringComparison.OrdinalIgnoreCase));
        }
        #endregion
        
        #region ConfigureAntiForgeryTokens
        /// <summary>
        /// Configures the anti-forgery tokens. See 
        /// http://www.asp.net/mvc/overview/security/xsrfcsrf-prevention-in-aspnet-mvc-and-web-pages
        /// </summary>
        private static void ConfigureAntiForgeryTokens()
        {
            // Rename the Anti-Forgery cookie from "__RequestVerificationToken" to "f". This adds a little security 
            // through obscurity and also saves sending a few characters over the wire. Sadly there is no way to change 
            // the form input name which is hard coded in the @Html.AntiForgeryToken helper and the 
            // ValidationAntiforgeryTokenAttribute to  __RequestVerificationToken.
            // <input name="__RequestVerificationToken" type="hidden" value="..." />
            AntiForgeryConfig.CookieName = "f";

            // If you have enabled SSL. Uncomment this line to ensure that the Anti-Forgery 
            // cookie requires SSL to be sent across the wire. 
            // AntiForgeryConfig.RequireSsl = true;
        }

        #endregion

        /// <summary>
        /// Handles the Content Security Policy (CSP) violation errors. For more information see FilterConfig.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CspViolationReportEventArgs"/> instance containing the event data.</param>
        protected void NWebsecHttpHeaderSecurityModule_CspViolationReported(object sender, CspViolationReportEventArgs e)
        {
            var violationReport = e.ViolationReport;
            var reportDetails = violationReport.Details;
            var violationReportString =
                $"UserAgent:<{violationReport.UserAgent}>\r\nBlockedUri:<{reportDetails.BlockedUri}>\r\nColumnNumber:<{reportDetails.ColumnNumber}>\r\nDocumentUri:<{reportDetails.DocumentUri}>\r\nEffectiveDirective:<{reportDetails.EffectiveDirective}>\r\nLineNumber:<{reportDetails.LineNumber}>\r\nOriginalPolicy:<{reportDetails.OriginalPolicy}>\r\nReferrer:<{reportDetails.Referrer}>\r\nScriptSample:<{reportDetails.ScriptSample}>\r\nSourceFile:<{reportDetails.SourceFile}>\r\nStatusCode:<{reportDetails.StatusCode}>\r\nViolatedDirective:<{reportDetails.ViolatedDirective}>";
            var exception = new CspViolationException(violationReportString);

            ErrorSignal.FromCurrentContext().Raise(exception, HttpContext.Current);
        }

        #region Application_Error
        protected void Application_Error()
        {
            foreach (var task in ProjectObjectFactory.Container.GetAllInstances<IRunOnError>())
            {
                task.Execute();
            }
        }
        #endregion
    }
}

using System.Web.Mvc;

namespace DNTCms.Web.Areas.Administrator
{
    public class AdministratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Administrator";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administrator_default",
                "Administrator/{controller}/{action}/{id}",
                new { controller = MVC.Administrator.Home.Name, action = MVC.Administrator.Home.ActionNames.Index, id = UrlParameter.Optional },
                namespaces: new[] {$"{typeof (AdministratorAreaRegistration).Namespace}.Controllers"}
                );
        }
    }
}
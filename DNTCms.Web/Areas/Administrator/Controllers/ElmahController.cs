using System.Web.Mvc;
using DNTCms.Common.Controller;
using DNTCms.Common.Filters;
using DNTCms.ServiceLayer.Security;

namespace DNTCms.Web.Areas.Administrator.Controllers
{
    [RouteArea("Administrator")]
    [RoutePrefix("ErrorsLog")]
    [Mvc5Authorize(AssignableToRolePermissions.CanViewErrorLogs)]
    public partial class ElmahController : Controller
    {
        [Route("Elmah/{type?}")]
        public virtual ActionResult Index(string type)
        {
            return new ElmahResult(type);
        }
    }
}
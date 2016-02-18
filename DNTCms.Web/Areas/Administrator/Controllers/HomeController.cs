
using System.Web.Mvc;

namespace DNTCms.Web.Areas.Administrator.Controllers
{
    public partial class HomeController : Controller
    {
        //
        // GET: /Administrator/Home/
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}
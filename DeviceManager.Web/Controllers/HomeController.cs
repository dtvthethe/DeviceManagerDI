using DeviceManager.Service.Services;
using System.Linq;
using System.Web.Mvc;

namespace DeviceManager.Web.Controllers
{
    public class HomeController : Controller
    {

        RoleService roleService;

        public HomeController(RoleService _roleService)
        {
            roleService = _roleService;
        }


        public ActionResult Index()
        {

            var aa = 1;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
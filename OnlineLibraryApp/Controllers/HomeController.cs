using System.Web.Mvc;

namespace OnlineLibraryApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In eget.";

            return View();
        }
    }
}
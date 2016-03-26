using System.Web.Mvc;

namespace OnlineLibraryApp.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
        {
            return View();
        }

        public string Welcome()
        {
            return "А это метод Welcome";
        }
    }
}
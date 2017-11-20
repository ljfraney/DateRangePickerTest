using DateRangePickerTest.Models;
using System.Web.Mvc;

namespace DateRangePickerTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            var model = new TestViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Test(TestViewModel model)
        {
            //Add a breakpoint here so that you can observe the TestViewModel as it is posted.
            return View("Results", model);
        }
    }
}
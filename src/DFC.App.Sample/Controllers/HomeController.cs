using $safeprojectname$.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace $safeprojectname$.Controllers
{
    public class HomeController : Controller
    {
        public const string ThisViewCanonicalName = "home";

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

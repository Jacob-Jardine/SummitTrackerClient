using Microsoft.AspNetCore.Mvc;

namespace SummitTrackerClient.Controllers
{
    public class PeakController : Controller
    {
        public IActionResult Index(string peak)
        {
            return View();
        }
    }
}

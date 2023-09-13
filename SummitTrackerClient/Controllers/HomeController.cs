using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Azure;
using SummitTrackerClient.Models;
using SummitTrackerClient.Models.ViewModel;
using SummitTrackerClient.Services;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SummitTrackerClient.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly ISummitTrackerService _summitTrackerService;

        public HomeController(ILogger<HomeController> logger, ISummitTrackerService _summitTrackerService) {
            _logger = logger;
            this._summitTrackerService = _summitTrackerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            var model = new IndexViewModel();

            var x = await _summitTrackerService.GetPeaksDropdown();
            model.Summits = x.Summits;

            return View(x);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Index(IndexViewModel model) {
            
            return RedirectToAction("Index");
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
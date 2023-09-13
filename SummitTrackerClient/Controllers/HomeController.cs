using Microsoft.AspNetCore.Mvc;
using SummitTrackerClient.Models;
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

        public async Task<IActionResult> Index() {
            var x = await _summitTrackerService.GetMountains(); 
            return View(x);
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
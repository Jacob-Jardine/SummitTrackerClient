using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Azure;
using SummitTrackerClient.Models;
using SummitTrackerClient.Models.DataModels;
using SummitTrackerClient.Models.ViewModel;
using SummitTrackerClient.Services;
using System.Diagnostics;

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
            if (!string.IsNullOrEmpty(model.SelectedSummit))
            {
                var summitModel = new UserSummitModel();
                summitModel.SummitID = Int32.Parse(model.SelectedSummit);
                summitModel.EmailAddress = User.Claims.Where(x => x.Type == "emails").First().Value.ToString();
                _summitTrackerService.InsertUserSummit(summitModel);
            }
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
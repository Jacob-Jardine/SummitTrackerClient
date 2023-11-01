using Microsoft.AspNetCore.Mvc;
using SummitTrackerClient.Models.DataModels;
using SummitTrackerClient.Services;

namespace SummitTrackerClient.Controllers {
    public class c9660048_444e_4a0c_b0e7_0d6dad21079fController : Controller {
        private readonly ISummitTrackerService _summitTrackerService;

        public c9660048_444e_4a0c_b0e7_0d6dad21079fController (ISummitTrackerService _summitTrackerService) {
            this._summitTrackerService = _summitTrackerService;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        public IActionResult AddSummit() {
            var model = new SummitModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddSummit(SummitModel model) {
            await _summitTrackerService.AddSummit(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddGeography() {
            var model = new GeographyModel();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddGeography(GeographyModel model) {
            await _summitTrackerService.AddGeography(model);
            return RedirectToAction("Index");
        }
    }
}

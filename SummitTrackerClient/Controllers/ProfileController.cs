using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SummitTrackerClient.Models.ViewModel;
using SummitTrackerClient.Services;

namespace SummitTrackerClient.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ISummitTrackerService _summitTrackerService;

        public ProfileController(ISummitTrackerService _summitTrackerService) 
        {
            this._summitTrackerService = _summitTrackerService;
        }

        public IActionResult Index()
        {
            var model = new ProfileViewModel();

            var profileModel = _summitTrackerService.GetProfile(User.Claims.Where(x => x.Type == "emails").First().Value.ToString());
            model.profileList = profileModel;
            foreach(var item in profileModel)
            {
                model.totaltHeightMetres += item.HeightMetres;
            }

            return View(model);
        }
    }
}

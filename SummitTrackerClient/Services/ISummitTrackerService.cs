using SummitTrackerClient.Models.DataModels;
using SummitTrackerClient.Models.ViewModel;

namespace SummitTrackerClient.Services
{
    public interface ISummitTrackerService
    {
        public Task<IndexViewModel> GetPeaksDropdown();
        public Task<SummitViewModel> GetPeak();
        public Task<bool> InsertUserSummit(UserSummitModel model);

        public List<ProfileModel> GetProfile(string emailAddress);
        public Task AddSummit(SummitModel summit);
        public Task AddGeography(GeographyModel model);
    }
}

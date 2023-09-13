using SummitTrackerClient.Models.DataModels;
using SummitTrackerClient.Models.ViewModel;

namespace SummitTrackerClient.Services
{
    public interface ISummitTrackerService
    {
        public Task<IndexViewModel> GetPeaksDropdown();
        public Task<SummitViewModel> GetPeak();
        public Task<SummitViewModel> InsertUserSummit();
    }
}

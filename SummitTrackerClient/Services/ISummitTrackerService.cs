using SummitTrackerClient.Models.DataModels;
using SummitTrackerClient.Models.ViewModel;

namespace SummitTrackerClient.Services
{
    public interface ISummitTrackerService
    {
        public Task<List<SummitViewModel>> GetMountains();
        public Task<SummitViewModel> GetPeak();
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;

namespace SummitTrackerClient.Models.ViewModel {
    public class IndexViewModel {
        public List<SelectListItem> Summits {get; set;}
        public string SelectedSummit { get; set; } = string.Empty;

        public int TotalSupportedSummits { get; set; }

        public int OverallSummitsClimbed { get; set; }

        public IndexViewModel() {
            Summits = new List<SelectListItem>();
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SummitTrackerClient.Models.DataModels {
    public class GeographyModel {
        [Key]
        public int GeographyID { get; set; }
        public int SummitID { get; set; }
        public string MountainRange { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Continent { get; set; }
        public string Coordinates { get; set; }

    }
}

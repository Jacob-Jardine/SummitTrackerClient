using System.ComponentModel.DataAnnotations;

namespace SummitTrackerClient.Models.DataModels
{
    public class ImageModel
    {
        [Key]
        public int ImageID { get; set; }
        public int SummitID { get; set; }
        public string URL { get; set; }
    }
}

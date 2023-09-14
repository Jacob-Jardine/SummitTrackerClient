using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SummitTrackerClient.Models.DataModels
{
    public class UserSummitModel
    {
        [Key]
        public int UserSummitID { get; set; }

        public string EmailAddress { get; set; }
        public int SummitID { get; set; }
    }
}

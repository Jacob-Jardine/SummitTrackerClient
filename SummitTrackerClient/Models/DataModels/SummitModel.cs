using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SummitTrackerClient.Models.DataModels
{
    public class SummitModel
    {
        [Key]
        public int SummitID { get; set; }
        public string SummitName { get; set; }
        public int HeightMetres { get; set; }
        public int HeightFeet { get; set; }
    }
}

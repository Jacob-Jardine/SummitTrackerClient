using Microsoft.EntityFrameworkCore;
using SummitTrackerClient.Models.DataModels;
using System.Collections.Generic;

namespace SummitTrackerClient.Context
{
    public class SummitTrackerDbContext : DbContext
    {
        public SummitTrackerDbContext() { }
        public SummitTrackerDbContext(DbContextOptions<SummitTrackerDbContext> options) : base(options) { }
        public virtual DbSet<SummitModel> Summit { get; set; }
        public virtual DbSet<ImageModel> Image { get; set; }
    }
}

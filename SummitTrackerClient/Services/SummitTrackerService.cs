using Microsoft.EntityFrameworkCore;
using SummitTrackerClient.Context;
using SummitTrackerClient.Models.DataModels;
using SummitTrackerClient.Models.ViewModel;

namespace SummitTrackerClient.Services
{
    public class SummitTrackerService : ISummitTrackerService
    {
        private readonly SummitTrackerDbContext _context;

        public SummitTrackerService(SummitTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<List<SummitViewModel>> GetMountains()
        {
            var x = new List<SummitViewModel>();

            var query = from Summit in _context.Set<SummitModel>()
                        join Image in _context.Set<ImageModel>()
                            on Summit.SummitID equals Image.SummitID
                        where Summit.SummitName.Equals("Mount")
                            select new { Summit.SummitID, Summit.SummitName, Summit.HeightMetres, Summit.HeightFt, Image.URL };
            
            foreach(var item in query)
            {
                x.Add(new SummitViewModel { 
                    SummitID = item.SummitID, 
                    SummitName = item.SummitName,
                    HeightMetres = item.HeightMetres, 
                    HeightFt = item.HeightFt, 
                    URL = item.URL 
                });
            }

            return x;
        }

        public Task<SummitViewModel> GetPeak()
        {
            //var x = new SummitViewModel();

            //var query = from Summit in _context.Set<SummitModel>()
            //            join Image in _context.Set<ImageModel>()
            //                on Summit.SummitID equals Image.SummitID
            //            select new { Summit.SummitID, Summit.SummitName, Summit.HeightMetres, Summit.HeightFt, Image.URL };

            //foreach (var item in query)
            //{
            //    x.Add(new SummitViewModel
            //    {
            //        SummitID = item.SummitID,
            //        SummitName = item.SummitName,
            //        HeightMetres = item.HeightMetres,
            //        HeightFt = item.HeightFt,
            //        URL = item.URL
            //    });
            //}

            return null;
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IndexViewModel> GetPeaksDropdown()
        {
            var x = new IndexViewModel();

            //var query = from Summit in _context.Set<SummitModel>()
            //            join Image in _context.Set<ImageModel>()
            //                on Summit.SummitID equals Image.SummitID
            //            where Summit.SummitName.Equals("Mount")
            //                select new { Summit.SummitID, Summit.SummitName, Summit.HeightMetres, Summit.HeightFt, Image.URL };

            var query = _context.Summit.ToList();

            foreach (var item in query) {
                x.Summits.Add(new SelectListItem() { Value = $"{item.SummitID}", Text = item.SummitName });
            }
            //foreach (var item in query)
            //{
            //    x.Add(new SummitViewModel { 
            //        SummitID = item.SummitID, 
            //        SummitName = item.SummitName,
            //        HeightMetres = item.HeightMetres, 
            //        HeightFt = item.HeightFt, 
            //        URL = item.URL 
            //    });
            //}

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

        public async Task InsertUserSummit(UserSummitModel model) {

            _context.UserSummit.Add(model);
            await _context.SaveChangesAsync();
        }

        public List<ProfileModel> GetProfile(string emailAddress)
        {
            var model =new List<ProfileModel>();

            var query = from Summit in _context.Set<SummitModel>()
                        join UserSummit in _context.Set<UserSummitModel>()
                            on Summit.SummitID equals UserSummit.SummitID
                            where UserSummit.EmailAddress.Equals(emailAddress)
                        select new ProfileModel
                        { 
                            SummitName = Summit.SummitName, 
                            HeightMetres = Summit.HeightMetres
                        };

            return query.ToList();
        }
    }
}

using Microsoft.AspNet.Identity;
using shareDoor.Data;
using shareDoor.Models;
using shareDoor.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace shareDoor.Controllers
{
    [Authorize]
    public class AdsController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        CloudinaryService service = new CloudinaryService();

        public AdsController()
        {
            _ctx = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            var states = _ctx.States.ToList();
            var rental = new AdFormViewModel
            {
                States = states
            };

            return View("AdForm", rental);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertAd(AdFormViewModel vm)
        {
            var userId = User.Identity.GetUserId();

            if (string.IsNullOrEmpty(userId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Μη εγκεκριμένος χρήστης");
            }

            if (!ModelState.IsValid)
            {
                var states = _ctx.States.ToList();
                vm.States = states;
                vm.Areas = _ctx.Areas.Where(x => x.State.Id == vm.House.StateId).ToList();

                return View("Adform", vm) ;
            }

            List<HousePhoto> newPhotos = new List<HousePhoto>();
            if(vm.Files[0] !=null)
            {
                foreach (var file in vm.Files)
                {
                    var result = service.UploadImage(file);
                    var url = result.Uri.ToString();
                    HousePhoto photo = new HousePhoto
                    {
                        Url = url
                    };
                    newPhotos.Add(photo);
                }
                newPhotos[0].IsMain = true;
            }


            var houseAd = new House
            {
                Address = vm.House.Address,
                PostalCode = vm.House.PostalCode,
                Level = vm.House.Level,
                RentCost = vm.House.RentCost,
                YearConstruct = vm.House.YearConstruct,
                AreaId = vm.House.AreaId,
                StateId = vm.House.StateId,
                UserId = userId,
                Gender = vm.House.Gender,
                Pets = vm.House.Pets,
                Smoker = vm.House.Smoker,
                Description = vm.House.Description,
                SquareMeters = vm.House.SquareMeters,
                TotalRooms = vm.House.TotalRooms,
                HousePhotos = newPhotos
            };

            _ctx.Houses.Add(houseAd);
            _ctx.SaveChanges();

            return RedirectToAction("Create");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult AdsList(SearchViewModel options)
        {
            try
            {

                var houses = _ctx.Houses
                    .Include("State")
                    .Include("State.Areas")
                    .Include(x=>x.HousePhotos)
                    .Where(x => x.Availability == true && x.IsConfirmed == Confirmation.Pass)
                    .Where(x=> string.IsNullOrEmpty(options.SearchText) || x.Area.Name.ToLower().Contains(options.SearchText.ToLower()))
                    .ToList();

                return View(houses);

            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"{ex.Message}");
            }


           
        }

    }


}

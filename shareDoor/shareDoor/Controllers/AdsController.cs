using Microsoft.AspNet.Identity;
using shareDoor.Data;
using shareDoor.Models;
using shareDoor.ViewModels;
using System;
using System.Collections.Generic;
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
                vm.Areas = _ctx.Areas.Where(x => x.State.Id == vm.StateId).ToList();

                return View("Adform", vm) ;
            }

            List<HousePhoto> newPhotos = new List<HousePhoto>();
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

            var houseAd = new House
            {
                Address = vm.Address,
                PostalCode = vm.PostalCode,
                Level = vm.Level,
                RentCost = vm.RentCost,
                YearConstruct = vm.YearConstruct,
                AreaId = vm.AreaId,
                StateId = vm.StateId,
                UserId = userId,
                Gender = vm.Gender,
                Pets = vm.Pets,
                Smoker = vm.Smoker,
                Description = vm.Description,
                SquareMeters = vm.SquareMeters,
                TotalRooms = vm.TotalRooms,
                Created = DateTime.Now,
                HousePhotos = newPhotos             
            };

            _ctx.Houses.Add(houseAd);
            _ctx.SaveChanges();

            return RedirectToAction("Create");
        }


    }


}

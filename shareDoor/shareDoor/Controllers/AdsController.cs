using Microsoft.AspNet.Identity;
using shareDoor.Data;
using shareDoor.Models;
using shareDoor.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
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
            var userId = User.Identity.GetUserId();

            var user = _ctx.Users.Find(userId);

            var states = _ctx.States.ToList();
            var rental = new AdFormViewModel
            {
                States = states,
                User = user,
                Action= "Εισαγωγή Αγγελίας",
                ButtonAction = "Καταχώρηση",
                FormAction = "InsertAd"
                
                
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
                vm.ButtonAction = "Καταχώρηση";
                vm.Action = "Εισαγωγή Αγγελίας";

                return View("Adform", vm);
            }

            List<HousePhoto> newPhotos = new List<HousePhoto>();
            if (vm.Files[0] != null)
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


            var user = _ctx.Users.Find(userId);
            user.Gender = vm.User.Gender;
            user.Smoker = vm.User.Smoker;
            user.Pets = vm.User.Pets;

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

            TempData["Message"] = "Καταχώρηση";
            return RedirectToAction("GetProfile","Users");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult AdsList(SearchViewModel options)
        {
            try
            {
                var text = RemoveDiacritics(options.SearchText);
                var states = _ctx.States.ToList();
                var areas = _ctx.Areas.ToList();


                var houses = _ctx.Houses
                    .Include(x=>x.User)
                   .Include("State")
                   .Include("State.Areas")
                   .Include(x => x.HousePhotos)
                   .Where(x => x.Availability == true && x.IsConfirmed == Confirmation.Pass)
                   .Where(x => string.IsNullOrEmpty(options.SearchText) || x.Area.Name.ToLower().Contains(text.ToLower()))
                   .ToList();


                AdSearchFiltersViewModel vm = new AdSearchFiltersViewModel();
                vm.Houses = houses;
                vm.States = states;
                vm.Areas = areas;
                if (text != null)
                {
                    var area = _ctx.Areas
                           .FirstOrDefault(y => y.Name.Contains(text.ToLower()));
                    vm.AreaId = area.Id;
                    vm.StateId = area.State.Id;
                }
                else
                {
                    vm.StateId = states.First().Id;
                    vm.AreaId = states.First().Areas.First().Id;
                    
                }


                return View(vm);

            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"{ex.Message}");
            }

        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult AdsFilters(AdSearchFiltersViewModel searchVm)
        {
            try
            {
                var query = from obj in _ctx.Houses select obj;

                switch (searchVm.Pets.ToLower())
                {
                    case "yes":
                        query = query.Where(x => x.Pets == "Yes");
                        break;
                    case "no":
                        query = query.Where(x => x.Pets == "No");
                        break;
                    default:
                        break;

                }

                switch (searchVm.Smoker.ToLower())
                {
                    case "yes":
                        query = query.Where(x => x.Smoker == "Yes");
                        break;
                    case "no":
                        query = query.Where(x => x.Smoker == "No");
                        break;
                    default:
                        break;

                }

                switch (searchVm.Gender.ToLower())
                {
                    case "male":
                        query = query.Where(x => x.Gender == "Male");
                        break;
                    case "female":
                        query = query.Where(x => x.Gender == "Female");
                        break;
                    default:
                        break;
                }

                switch (searchVm.SearchRentCost.ToLower())
                {
                    case "0-100":
                        query = query.Where(x => x.RentCost >= 0 && x.RentCost <=100);
                        break;
                    case "101-200":
                        query = query.Where(x => x.RentCost >=101 && x.RentCost <=200);
                        break;
                    case "201-300":
                        query = query.Where(x => x.RentCost >=201 && x.RentCost <=300);
                        break;
                    case "301+":
                        query = query.Where(x => x.RentCost >= 301);
                        break;
                    case "default":
                        query = query.Where(x => x.RentCost >= 0);
                        break;
                    default:
                        break;
                }

                switch (searchVm.HasPhotos.ToLower())
                {
                    case "yes":
                        query = query.Where(x => x.HousePhotos.Count > 0);
                        break;
                    case "no":
                        query = query.Where(y => y.HousePhotos.Count == 0);
                        break;
                    default:
                        break;
                }

                var houses = query
                    .Include(x=>x.User)
                    .Include(x => x.HousePhotos)
                    .OrderByDescending(x => x.Created)
                    .Where(x => x.Availability == true && x.IsConfirmed == Confirmation.Pass)
                    .Where(x=>x.StateId==searchVm.StateId && x.Area.Id == searchVm.AreaId)
                    .ToList();

                var states = _ctx.States.ToList();
                var areas = _ctx.Areas.ToList();

                AdSearchFiltersViewModel vm = new AdSearchFiltersViewModel();
                vm.Houses = houses;
                vm.States = states;
                vm.Smoker = searchVm.Smoker;
                vm.Pets = searchVm.Pets;              
                vm.Gender = searchVm.Gender;
                vm.SearchRentCost = searchVm.SearchRentCost;
                vm.HasPhotos = searchVm.HasPhotos;
                vm.Areas = areas;
                vm.StateId = states.First().Id;
                vm.AreaId = states.First().Areas.First().Id;


                return View("AdsList", vm);
            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"{ex.Message}");
            }
        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult AdDetails(int Id)
        {

            try
            {
                var houseAd = _ctx.Houses
                        .Include(x => x.HousePhotos)
                        .Include(x => x.User)
                        .Include(x => x.State)
                        .Include(x => x.Area)
                        .Include(x => x.User.UserPhotos)
                        .Single(x => x.Id == Id);


                return View(houseAd);
            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"{ex.Message}");
            }
        }



        [HttpGet]
        public ActionResult EditAd(int Id)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var houseAd = _ctx.Houses
                    .Include(x=>x.State)
                    .Include(x=>x.Area)
                    .Include(x=>x.HousePhotos)
                    .Include(x=>x.User)
                    .Single(x => x.Id == Id && x.UserId == userId);


                AdFormViewModel vm = new AdFormViewModel();
                vm.House = houseAd;
                vm.Areas = houseAd.State.Areas;
                vm.House.AreaId = houseAd.AreaId;
                vm.House.Area = houseAd.Area;
                vm.House.StateId = houseAd.StateId;
                vm.Action = "Επεξεργασία Αγγελίας";
                vm.ButtonAction = "Αποθήκευση";
                vm.FormAction = "UpdateAd";
                vm.User = houseAd.User;
                vm.States = _ctx.States.ToList();



              
                return View("AdForm", vm);
            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"{ex.Message}");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAd(AdFormViewModel vm)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var houseAd = _ctx.Houses
                    .Include(x=>x.HousePhotos)
                    .Single(x => x.Id == vm.House.Id && x.UserId == userId);
                if(houseAd.IsConfirmed == Confirmation.Pass)
                {
                    houseAd.IsConfirmed = Confirmation.Pending;
                }
                houseAd.Address = vm.House.Address;
                houseAd.Description = vm.House.Description;
                houseAd.Level = vm.House.Level;
                houseAd.PostalCode = vm.House.PostalCode;
                houseAd.SquareMeters = vm.House.SquareMeters;
                houseAd.RentCost = vm.House.RentCost;
                houseAd.TotalRooms = vm.House.TotalRooms;
                houseAd.YearConstruct = vm.House.YearConstruct;
                houseAd.Smoker = vm.House.Smoker;
                houseAd.Pets = vm.House.Pets;
                houseAd.Gender = vm.House.Gender;

                var isMain = houseAd.HousePhotos.Any(x => x.IsMain == true);
                if (isMain && (vm.Files[0] != null))
                {
                    foreach (var file in vm.Files)
                    {
                        var result = service.UploadImage(file);
                        var url = result.Uri.ToString();
                        HousePhoto photo = new HousePhoto
                        {
                            Url = url,
                            IsMain = false
                        };
                        houseAd.HousePhotos.Add(photo);
                    }

                }
                else
                {
                    if (vm.Files[0] != null)
                    {
                        for (int i = 0; i < vm.Files.Length; i++)
                        {
                            var result = service.UploadImage(vm.Files[i]);
                            var url = result.Uri.ToString();
                            if (i == 0)
                            {
                                HousePhoto photo = new HousePhoto
                                {
                                    Url = url,
                                    IsMain = true
                                };
                                houseAd.HousePhotos.Add(photo);
                            }
                            else
                            {
                                HousePhoto photo = new HousePhoto
                                {
                                    Url = url,
                                    IsMain = false
                                };
                                houseAd.HousePhotos.Add(photo);
                            }

                        }
                    }
                }

                _ctx.SaveChanges();
                TempData["Message"] = "Καταχώρηση";
                return RedirectToAction("GetProfile", "Users");
            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"{ex.Message}");
            }
        }








        //Αφαιρεί τους τόνους
        private static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }

    }


}

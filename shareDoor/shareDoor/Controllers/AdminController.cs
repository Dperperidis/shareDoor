using shareDoor.Data;
using shareDoor.Models;
using shareDoor.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace shareDoor.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _ctx;


        public AdminController()
        {
            _ctx = new ApplicationDbContext();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginViewModel vm = new LoginViewModel();
            return View(vm);
        }

        public ActionResult AdminMain()
        {

            try
            {
                var houses = _ctx.Houses
                      .Include(x => x.Area)
                      .Include(x => x.State)
                      .Include(x => x.User)
                      .Where(x => x.IsConfirmed == Models.Confirmation.Pending)
                      .OrderByDescending(x=>x.Created)
                      .ToList();


                return View(houses);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"{ex.Message}");

            }

        }

        public ActionResult EditAd(int Id)
        {
           
            try
            {
                
               var house = _ctx.Houses
                          .Include(x=>x.HousePhotos)
                        .Include("State")
                       .Include("State.Areas")
                       .Single(x => x.Id == Id);

                var states = _ctx.States.ToList();

                AdFormViewModel vm = new AdFormViewModel
                {
                    States = states,                     
                    Areas = house.State.Areas,
                    Id = house.Id,
                    House= new House
                    {
                        AreaId = house.State.Areas.FirstOrDefault(x => x.Id == house.AreaId).Id,
                        StateId = house.State.Id,
                        Address = house.Address,
                        IsConfirmed = house.IsConfirmed,
                        PostalCode = house.PostalCode,
                        Gender = house.Gender,
                        Smoker = house.Smoker,
                        RentCost = house.RentCost,
                        Level = house.Level,
                        SquareMeters = house.SquareMeters,
                        Pets = house.Pets,
                        HousePhotos = house.HousePhotos,
                        TotalRooms = house.TotalRooms,
                        YearConstruct = house.YearConstruct,
                        Description = house.Description
                    }

                };


                return View(vm);
            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"{ex.Message}");
            }

        }
    }
}
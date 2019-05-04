using Microsoft.AspNet.Identity;
using PagedList;
using shareDoor.Data;
using shareDoor.Dto;
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
            var userId = User.Identity.GetUserId();
            if(userId == null)
            {
                LoginViewModel vm = new LoginViewModel();
                return View(vm);
            }
            else
            {
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("AdminMain");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }

           
            
        }

        public ActionResult AdsList( string search, int? page, ItemsPerPage itemsPerPage= ItemsPerPage.p05,SearchConfirm searchconfirm = SearchConfirm.all)
        {

            try
            {
                
                var query = from obj in _ctx.Houses select obj;
                string header= "";
                switch (searchconfirm)
                {
                    case 0:
                        query = query.Where(x => x.IsConfirmed == Confirmation.Pass);
                        header = "Έγγκεκριμένες αγγελίες ";
                        break;
                    case (SearchConfirm)1:
                        query = query.Where(x => x.IsConfirmed == Confirmation.Pending);
                        header = "Εκκρεμών αγγελίες";
                        break;
                    case (SearchConfirm)2:
                        query = query.Where(x => x.IsConfirmed == Confirmation.Cancel);
                        header = "Απορριφθέντες αγγελίες";
                        break;
                    default:
                        header = "Όλες οι αγγελίες";
                        break;
                }

                var houses = query
                      .Include(x => x.Area)
                      .Include(x => x.State)
                      .Include(x => x.User)
                      .OrderByDescending(x=>x.Created)
                      .ToList().ToPagedList(page ?? 1, (int)itemsPerPage);


                AdminSearchViewModel vm = new AdminSearchViewModel
                {
                    Houses = houses,
                    ItemsPerPage = itemsPerPage,
                    SearchConfirm = searchconfirm,
                   
                };
                ViewBag.Header = header;
                return View(vm);
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

                AlertDto alert = new AlertDto();
                switch (house.IsConfirmed)
                {
                    case (Confirmation)0:
                        alert.AlertClass = "success";
                        alert.AlertText = "Δημοσιευμένη";
                        break;
                    case (Confirmation)1:
                        alert.AlertClass = "warning";
                        alert.AlertText = "Εκκρεμών";
                        break;
                    case (Confirmation)2:
                        alert.AlertClass = "danger";
                        alert.AlertText = "Απορριφθείσα";
                        break;
                }

                AdFormViewModel vm = new AdFormViewModel
                {
                    States = states,                     
                    Areas = house.State.Areas,
                    Id = house.Id,
                    Alert = alert,
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

        public ActionResult AdminMain()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var user = _ctx.Users
                    .Include(x => x.UserPhotos)
                    .Single(x => x.Id == userId);

                ViewModelBase.NickName = user.NickName;
                ViewModelBase.UserPhoto = user.UserPhotos.FirstOrDefault(x => x.IsMain == true).Url;


                StatsViewModel vm = new StatsViewModel
                {

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
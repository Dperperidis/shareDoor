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
               
                
            };

            _ctx.Houses.Add(houseAd);
            _ctx.SaveChanges();

            return RedirectToAction("Create");
        }


    }


}

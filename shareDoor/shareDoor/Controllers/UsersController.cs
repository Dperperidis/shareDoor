using Microsoft.AspNet.Identity;
using shareDoor.Data;
using shareDoor.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shareDoor.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {

        private readonly ApplicationDbContext _ctx;

        public UsersController()
        {
            _ctx = new ApplicationDbContext();
        }


        public ActionResult GetProfile()
        {
            var userId = User.Identity.GetUserId();

            var user = _ctx.Users
                .Include("Houses")
                .Include("Houses.Area")
                .Include("Houses.State")         
                .Single(x=>x.Id == userId);



            var userVM = new UserProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.LastName,
                Houses = user.Houses
              
            };

            return View("Profile", userVM);
        }
    }
}
using shareDoor.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace shareDoor.Controllers
{
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _ctx;

        public AdminController()
        {
            _ctx = new ApplicationDbContext();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AdminMain()
        {
            try
            {
              var houses = _ctx.Houses
                    .Include(x=>x.Area)
                    .Include(x=>x.User)
                    .Where(x => x.IsConfirmed == Models.Confirmation.Pending).ToList();


                return View(houses);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"{ex.Message}");

            }


        }
    }
}
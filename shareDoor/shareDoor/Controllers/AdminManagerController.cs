using PagedList;
using shareDoor.Data;
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
    public class AdminManagerController : Controller
    {

        private readonly ApplicationDbContext _ctx;
        public AdminManagerController()
        {
            _ctx = new ApplicationDbContext();
        }


        public ActionResult UsersList(int? page,UserItemsPerPage userItemsPerPage= UserItemsPerPage.p02)
        {

            try
            {
                var users = _ctx.Users
                    .Include(x => x.UserPhotos)
                    .ToList().ToPagedList(page ?? 1, (int)userItemsPerPage);


                UserSearchViewModel vm = new UserSearchViewModel
                {
                    Users = users,
                    UserItemsPerPage = userItemsPerPage,

                };


                return View(vm);

            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"{ex.Message}");
            }


        }

        public ActionResult EditUser(string Id)
        {
            try
            {
                var user = _ctx.Users
                    .Include(x => x.UserPhotos)
                    .Include(x => x.Houses)
                    .Include("Houses.HousePhotos")
                    .Single(x => x.Id == Id);

                var roles = _ctx.Roles.ToList();

                UserEditViewModel vm = new UserEditViewModel
                {
                    User = user,
                    Roles = roles
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
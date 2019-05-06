using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using shareDoor.Data;
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
    public class PaymentsController : Controller
    {
        public ICollection<IdentityRole> Roles { get; set; }
        public IdentityUserRole UserRole { get; set; }
        private readonly ApplicationDbContext _ctx;
        public PaymentsController()
        {
            _ctx = new ApplicationDbContext();
            Roles = _ctx.Roles.ToList();
        }


        public ActionResult Payment(string price)
        {
            try
            {

                PaymentFormViewModel vm = new PaymentFormViewModel();

                TempData["Price"] = price;
                return View(vm);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"{ex.Message}");
            }

         
        }


        [HttpPost]
        public ActionResult PaymentConfirm(PaymentFormViewModel vm)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var user = _ctx.Users.Find(userId);
                var roleId = user.Roles.First().RoleId;
                var roleName = Roles.FirstOrDefault(x => x.Id == roleId).Name;


               

                if (vm.Price == "5")
                {
                    
                    System.Web.Security.Roles.RemoveUserFromRole(user.UserName, roleName);
                    System.Web.Security.Roles.AddUserToRole(user.UserName, "Silver Member");
                }
                else if(vm.Price=="8")
                {
                    System.Web.Security.Roles.RemoveUserFromRole(user.UserName, roleName);
                    System.Web.Security.Roles.AddUserToRole(user.UserName, "Gold Member");
                }
              

              
                return RedirectToAction("GetProfile","Users");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"{ex.Message}");
            }
        }
    }
}
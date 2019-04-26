using Microsoft.AspNet.Identity;
using shareDoor.Data;
using shareDoor.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace shareDoor.Controllers
{
    public class PhotosController : Controller
    {
        private readonly ApplicationDbContext _ctx;   

        public PhotosController()
        {
            _ctx = new ApplicationDbContext();
        }

        [HttpPost]
        public ActionResult SetMainUserPhoto(PhotoDto Id)
        {

            try
            {
                var userId = User.Identity.GetUserId();

                var UserPhotos = _ctx.UserPhotos.Where(x => x.UserId == userId).ToList();

                for (int i = 0; i < UserPhotos.Count; i++)
                {
                    if (UserPhotos[i].IsMain == true)
                    {
                        UserPhotos[i].IsMain = false;
                    }
                }

               UserPhotos.Single(x => x.Id == Id.photoId).IsMain = true;
                _ctx.SaveChanges();

               

            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"{ex.Message}");
            }



            return RedirectToAction("GetProfile","Users");
        }
    }
}
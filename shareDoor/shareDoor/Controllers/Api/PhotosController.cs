using Microsoft.AspNet.Identity;
using shareDoor.Data;
using shareDoor.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shareDoor.Controllers.Api
{
    [Authorize]
    public class PhotosController : ApiController
    {

        private readonly ApplicationDbContext _ctx;
        CloudinaryService service = new CloudinaryService();

        public PhotosController()
        {
            _ctx = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult SetMainUserPhoto(PhotoDto photo)
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


                UserPhotos.Single(x => x.Id == photo.photoId).IsMain = true;
                var photoToReturn = UserPhotos.Single(x => x.Id == photo.photoId);
                _ctx.SaveChanges();



                return Ok(photoToReturn);


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }




        }

        [HttpDelete]
        public IHttpActionResult DeleteUserPhoto(int Id)
        {
            try
            {
                var userId = User.Identity.GetUserId();

               var photo =_ctx.UserPhotos.Single(y => y.Id == Id && y.UserId == userId);
                if(photo.IsMain == true)
                {
                    return BadRequest("Δεν μπορείς να σβήσεις την βασική σου φωτογραφία");
                }
                _ctx.UserPhotos.Remove(photo);
                _ctx.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}

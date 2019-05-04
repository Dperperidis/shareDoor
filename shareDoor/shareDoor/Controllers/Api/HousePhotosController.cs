using Microsoft.AspNet.Identity;
using shareDoor.Data;
using shareDoor.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shareDoor.Controllers.Api
{
    [Authorize]
    public class HousePhotosController : ApiController
    {
        private readonly ApplicationDbContext _ctx;
        CloudinaryService service = new CloudinaryService();

        public HousePhotosController()
        {
            _ctx = new ApplicationDbContext();
        }


        [HttpDelete]
        public IHttpActionResult DeleteHousePhoto(int Id)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var housePhoto = _ctx.HousePhotos.Single(x => x.Id == Id && x.House.UserId == userId);              
                if (housePhoto.IsMain == true)
                {
                    return BadRequest("Δεν μπορείς να σβήσεις την βασική φωτογραφία της αγγελίας σου");
                }

                _ctx.HousePhotos.Remove(housePhoto);
                _ctx.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult SetMainHousePhoto(PhotoDto photo)
        {

            try
            {
                var userId = User.Identity.GetUserId();
                var houseEntity = _ctx.HousePhotos
                    .Include(x=>x.House)
                    .Single(x => x.Id == photo.photoId);

                var housePhotos = _ctx.HousePhotos.Where(x =>x.House.UserId == userId && x.House.Id == houseEntity.House.Id).ToList();

                for (int i = 0; i < housePhotos.Count; i++)
                {
                    if (housePhotos[i].IsMain == true)
                    {
                        housePhotos[i].IsMain = false;
                    }
                }


                housePhotos.Single(x => x.Id == photo.photoId).IsMain = true;
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

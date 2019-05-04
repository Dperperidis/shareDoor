using Microsoft.AspNet.Identity;
using shareDoor.Data;
using shareDoor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shareDoor.Controllers.Api
{
    public class AdsController : ApiController
    {
        private readonly ApplicationDbContext _ctx;

        public AdsController()
        {
            _ctx = new ApplicationDbContext();
        }

        
        public IEnumerable<Area> GetAreas(int Id)
        {
            
            var areas = _ctx.Areas
                .Where(x => x.State.Id == Id);


            return areas;
        }

        [HttpDelete]
        public IHttpActionResult DeleteHouse(int Id)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var houseAd = _ctx.Houses.Single(x => x.Id == Id && x.UserId == userId);

                _ctx.Houses.Remove(houseAd);
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

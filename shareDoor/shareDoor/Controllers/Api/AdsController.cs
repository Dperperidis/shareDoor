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

    }
}

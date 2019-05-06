using shareDoor.Data;
using shareDoor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;

namespace shareDoor.Controllers.Api
{
    public class AreasController : ApiController
    {
        private readonly ApplicationDbContext _ctx;

        public AreasController()
        {
            _ctx = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<Area> GetTotalAreas()
        {
            var areas = _ctx.Areas
                .Include(x => x.State).ToList().AsEnumerable();
              
                

            return areas;
        }
    }
}
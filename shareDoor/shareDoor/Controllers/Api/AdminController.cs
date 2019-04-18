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
    public class AdminController : ApiController
    {

        private readonly ApplicationDbContext _ctx;

        public AdminController()
        {
            _ctx = new ApplicationDbContext();
        }


        //public IEnumerable<House> GetHouses()
        //{

        //}
    }
}

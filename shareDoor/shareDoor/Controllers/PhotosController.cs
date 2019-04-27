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

    
    }
}
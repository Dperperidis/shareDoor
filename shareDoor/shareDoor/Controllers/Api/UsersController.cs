using Microsoft.AspNet.Identity;
using shareDoor.Data;
using shareDoor.Dto;
using shareDoor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shareDoor.Controllers.Api
{
    public class UsersController : ApiController
    {
        private readonly ApplicationDbContext _ctx;
        public UsersController()
        {
            _ctx = new ApplicationDbContext();
        }



        //[HttpPost]
        //public List<string> GetUserNames(UserDto dto)
        //{
        //    var userId = User.Identity.GetUserId();

        //    if (dto != null)
        //    {
        //        if (!(_ctx.Messages.Any(x => x.ReceiverId == dto.Id && x.SenderId == userId)))
        //        {
        //            MessageInfo message = new MessageInfo
        //            {
        //                Message = "",
        //                SenderId = userId,
        //                ReceiverId = dto.Id
        //            };
        //            _ctx.Messages.Add(message);
        //            _ctx.SaveChanges();
        //        }
        //    }
        //    var users = _ctx.Messages
        //        .Include(x => x.Receiver)
        //        .Where(x => x.SenderId == userId).ToList();

        //    UserDto dtoToReturn = new UserDto();

        //    foreach (var name in users)
        //    {
        //        if (!dtoToReturn.Receivers.Contains(name.Receiver.NickName))
        //        {
        //            dtoToReturn.Receivers.Add(name.Receiver.NickName);
        //        }

        //    }

        //    return dtoToReturn.Receivers;
        //}

        //[HttpGet]
        //public List<string> GetUsersToChat()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var users = _ctx.Messages
        //            .Include(x => x.Receiver)
        //            .Where(x => x.SenderId == userId).ToList();

        //    UserDto dtoToReturn = new UserDto();

        //    foreach (var name in users)
        //    {
        //        if (!dtoToReturn.Receivers.Contains(name.Receiver.NickName))
        //        {
        //            dtoToReturn.Receivers.Add(name.Receiver.NickName);
        //        }

        //    }

        //    return dtoToReturn.Receivers;
        //}




    }
}

using Microsoft.AspNet.Identity;
using shareDoor.Data;
using shareDoor.Dto;
using shareDoor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shareDoor.Controllers.Api
{
    public class MessagesController : ApiController
    {
        private readonly ApplicationDbContext _ctx;
        public MessagesController()
        {
            _ctx = new ApplicationDbContext();
        }

        [HttpPost]
        public List<string> GetMessages(UserDto dto)
        {

            var receiverId = _ctx.Users.Single(x => x.NickName == dto.Name).Id;

            var userId = User.Identity.GetUserId();
            var messages =_ctx.Messages.Where(x => x.SenderId == userId && x.ReceiverId == receiverId ||  x.SenderId == receiverId && x.ReceiverId == userId).ToList();

            var messagesToReturn = new List<string>();
            foreach(var message in messages)
            {
                messagesToReturn.Add(message.Message);
            }

            return messagesToReturn;
        }

    }
}

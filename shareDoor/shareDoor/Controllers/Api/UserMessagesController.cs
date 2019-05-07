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
    public class UserMessagesController : ApiController
    {
        private readonly ApplicationDbContext _ctx;
        public UserMessagesController()
        {
            _ctx = new ApplicationDbContext();
        }


        [HttpPost]
        public void SendMessage(MessageDto message)
        {

            var userId = User.Identity.GetUserId();
            var receiverId = _ctx.Users.Single(x => x.NickName == message.Name).Id;

            _ctx.Messages.Add(new MessageInfo {
                SenderId =userId,
                ReceiverId = receiverId,
                Message = message.Message
            });
            _ctx.SaveChanges();

        }


        [HttpGet]
        public List<string> GetMessages()
        {
            var userId = User.Identity.GetUserId();
            var messages =_ctx.Messages
                .Include(x=>x.Sender)
                .Where(x => x.ReceiverId == userId);

            var nickNames = new List<string>();

            foreach(var message in messages)
            {
                if (!nickNames.Contains(message.Sender.NickName))
                {
                    nickNames.Add(message.Sender.NickName);
                }              
            }

            return nickNames;


        }
    }
}

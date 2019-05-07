using Microsoft.AspNet.SignalR;
using shareDoor.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shareDoor.Models
{
    public class CustomerUserIdProvider : IUserIdProvider
    {
        TextManager man = new TextManager();
        public string GetUserId(IRequest request)
        {
            var userId = man.FindUserId(request.User.Identity.Name);
            return userId;
        }
    }
}
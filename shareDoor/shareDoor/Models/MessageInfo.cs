using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shareDoor.Models
{
    public class MessageInfo
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
        public string ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }
        public DateTime Created { get; set; }
        public bool IsRead { get; set; }
        public string Subject { get; set; }

        public MessageInfo()
        {
            Created = DateTime.Now;
        }
    }
}
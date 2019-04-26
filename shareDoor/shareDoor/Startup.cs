using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(shareDoor.Startup))]
namespace shareDoor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //app.MapSignalR();
        }
    }
}


//model ChatHub: Hub
// public void Send(string name, string message)
//Clients.All.broadcastMessage(name, message);

    //needs jquery 1.6.4
    //needs jquery.signalR-2.0.0.js
    //needs signalr/hubs 


    //var chat = $.connection.ChatHub;
    //chat.client.broadcastMessage= function(name, message)
    //{
       
    //}
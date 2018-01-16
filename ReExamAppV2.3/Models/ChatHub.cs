using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ReExamAppV2._3.Models
{
    public class ChatHub : Hub
    {
        public void SendMessage(string username, string timestamp, string message)
        {
            Clients.All.showMessage(username, timestamp, message);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ConnectMe.Hubs
{
    public class CarControllerHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}
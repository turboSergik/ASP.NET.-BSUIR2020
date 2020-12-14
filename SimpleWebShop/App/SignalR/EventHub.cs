using Microsoft.AspNetCore.SignalR;
using SimpleWebShop.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebShop.App.SignalR
{
    public class EventHub : Hub
    {
        private IServiceProvider _sp;
        public EventHub(IServiceProvider sp)
        {
            _sp = sp;
        }

        public Task SendEvent(Car newCar)
        {
            return Clients.All.SendAsync("needUpdateCars", newCar);
        }
    }
}

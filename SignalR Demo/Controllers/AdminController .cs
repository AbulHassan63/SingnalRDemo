using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_Demo.Hubs;
using SignalR_Demo.Models;

namespace SignalR_Demo.Controllers
{
    public class AdminController : Controller
    {
        private readonly IHubContext<NotificationHub> _notificationHubContext;
       

        public AdminController(IHubContext<NotificationHub> notificationHubContext)
        {
            _notificationHubContext = notificationHubContext;
           
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Article model)
        {
            await _notificationHubContext.Clients.All.SendAsync("sendToUser", model.articleHeading, model.articleContent);
            return View();
        }

       
    }
}

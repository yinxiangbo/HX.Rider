using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HX.Rider.Exception;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace HX.Rider.API.Controllers
{
    /// <summary>
    /// MessageController
    /// </summary>
    public class MessageController : BaseController
    {
        
        private readonly IHubContext<MessageHub> _hubContext;
        private readonly ILogger<MessageController> _logger;
        /// <summary>
        /// MessageController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="hubContext"></param>
        public MessageController(ILogger<MessageController> logger, IHubContext<MessageHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        public async Task SendMessageBySignalR()
        {
           await _hubContext.Clients.All.SendAsync("ReceiveMessage","扣款成功");
        }
    }
}
